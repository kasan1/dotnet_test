using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Camunda;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Agro.Shared.Logic.CQRS.Notifications;
using Agro.Shared.Logic.Common.Exceptions;
using System.Net;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons
{
    public class ChangeStatus
    {
        public class ChangeStatusCommand : IRequest<Response<Unit>>
        {
            public Guid LoanApplicationId { get; set; }

            public string StatusCode { get; set; }
        }

        public class Handler : IRequestHandler<ChangeStatusCommand, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IProcessLogic _processLogic;
            private readonly IMediator _mediator;

            public Handler(DataContext dataContext, IProcessLogic processLogic, IMediator mediator)
            {
                _dataContext = dataContext;
                _processLogic = processLogic;
                _mediator = mediator;
            }

            public async Task<Response<Unit>> Handle(ChangeStatusCommand request, CancellationToken cancellationToken)
            {
                var loanApplication = await _dataContext.LoanApplications.FirstOrDefaultAsync(x => x.Id == request.LoanApplicationId && !x.IsDeleted);
                if (loanApplication == null)
                    throw new RestException(HttpStatusCode.NotFound, $"{request.LoanApplicationId} not found");

                var previousProcessStatus = await _dataContext.DicLoanHistoryStatuses.FirstOrDefaultAsync(x => x.Id == loanApplication.StatusId && !x.IsDeleted);
                if (previousProcessStatus == null)
                    throw new RestException(HttpStatusCode.NotFound, $"Process status not found");

                var processStatus = await _dataContext.DicLoanHistoryStatuses
                    .Include(x => x.DicApplicationStatus)
                    .FirstOrDefaultAsync(x => x.Code == request.StatusCode && !x.IsDeleted);
                if (processStatus == null)
                    throw new RestException(HttpStatusCode.NotFound, $"Process status {request.StatusCode} not found");

                loanApplication.StatusId = processStatus.Id;

                if (processStatus.Code == "Reject")
                {
                    var tasks = await _dataContext.LoanApplicationTasks
                        .Include(x => x.Role)
                        .Where(x => !x.IsDeleted && x.ApplicationId == request.LoanApplicationId)
                        .ToListAsync();

                    tasks.ForEach(x => x.IsDeleted = true);

                    try
                    {
                        await _processLogic.DeleteProcessAsync(loanApplication.ProcessInstanceId.Value);
                    }
                    catch
                    {
                        //TODO: send email notification
                    }
                }

                if (processStatus.StatusId.HasValue && previousProcessStatus.StatusId != processStatus.StatusId)
                {
                    var createNotificationCommand = new Create.CreateNotificationCommand
                    {
                        UserId = loanApplication.UserId
                    };
                    createNotificationCommand.SetValues(loanApplication.RegNumber, processStatus.DicApplicationStatus.NameRu, processStatus.DicApplicationStatus.NameKk);
                    await _mediator.Send(createNotificationCommand, cancellationToken);
                }

                await _dataContext.SaveChangesAsync(cancellationToken);

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }
    }
}
