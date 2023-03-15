using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Camunda;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Agro.Bpm.Logic.CQRS.Camunda.Commands
{
    public class StartProcess
    {

        public class Command : IRequest<Response<string>>
        {
            public Guid ApplicationId { get; set; }
            public Guid UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<string>>
        {
            private readonly DataContext _dataContext;
            private readonly IProcessLogic _processLogic;
            private readonly ILogger<StartProcess> _logger;

            public Handler(DataContext dataContext, IProcessLogic processLogic, ILogger<StartProcess> logger)
            {
                _dataContext = dataContext;
                _processLogic = processLogic;
                _logger = logger;
            }

            public async Task<Response<string>> Handle(Command request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"Запуск БПМ процесса для заявки {request.ApplicationId}.");

                var application = await _dataContext.LoanApplications
                    .Include(x => x.DicLoanType)
                    .Include(x => x.DicLoanHistoryStatus)
                    .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.ApplicationId);

                if (application == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Заявка не найдена");

                if (application.DicLoanHistoryStatus.Code != "FinancialAnalysis")
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Процесс запускасается после фин. анализа");

                var finAnalysis = await _dataContext.FinAnalyses.FirstOrDefaultAsync(x => !x.IsDeleted && x.LoanApplicationId == request.ApplicationId);
                if (finAnalysis == null || finAnalysis.Status == PolicyRules.RejectStatuses.ServiceUnavailable)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Фин. анализ не проведен");

                var countOfCommitteeMembers = await (from ub in _dataContext.UserBranches
                                                     join ur in _dataContext.UserRoles on ub.UserId equals ur.UserId
                                                     where ub.BranchId == application.BranchId & ur.Role.Value == Shared.Data.Enums.Identity.RoleType.CreditCommittee
                                                     select ur.Role.Code)
                                                  .Distinct()
                                                  .CountAsync(cancellationToken);

                var processId = await _processLogic.StartProcessAsync(new Shared.Logic.Models.LoanApplicationInDto
                {
                    ApplicationId = request.ApplicationId,
                    NeedComplianceChecking = finAnalysis.Status != PolicyRules.RejectStatuses.Correct,
                    LoanType = application.DicLoanType.Value,
                    CountOfCommitteeMembers = countOfCommitteeMembers
                });

                application.ProcessInstanceId = Guid.Parse(processId);
                await _dataContext.SaveChangesAsync();

                _logger.LogInformation($"БПМ процесс успешно запущен для заявки {request.ApplicationId}.");

                return Response.Success("Запрос выполнен успешно", processId);
            }
        }

    }
}
