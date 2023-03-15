using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using MediatR;
using Agro.Shared.Logic.Models.Common;
using Microsoft.EntityFrameworkCore;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Data.Primitives;
using System.Net;
using System.Net.Http;
using Microsoft.Extensions.Options;
using Agro.Shared.Data;
using Microsoft.Extensions.Logging;

namespace Agro.Okaps.Logic.CQRS.LoanApplication
{
    public class Sign
    {
        public class SignCommand : IRequest<Response<Unit>>
        {
            public string Xml { get; set; }
            public Guid LoanApplicationId { get; set; }
        }

        public class CommandHandler : IRequestHandler<SignCommand, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IMediator _mediator;
            private readonly ILogger<Sign> _logger;
            private string _bpmFinAnalysisUrl;

            public CommandHandler(
                IOptions<AppSettings> options,
                DataContext dataContext,
                IMediator mediator,
                ILogger<Sign> logger)
            {
                _dataContext = dataContext;
                _mediator = mediator;
                _logger = logger;
                _bpmFinAnalysisUrl = options.Value.Bpm.FinAnalysisUrl;
            }

            public async Task<Response<Unit>> Handle(SignCommand request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications
                    .Include(x => x.User)
                    .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId, cancellationToken);
                if (application == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                if (application.Status != ApplicationTypeEnum.Temp)
                    throw new RestException(HttpStatusCode.BadRequest, "Заявка уже в работе, вы не можете вносить изменения");

                var status = await _dataContext.DicLoanHistoryStatuses.FirstOrDefaultAsync(x => x.Code == "FinancialAnalysis", cancellationToken);
                if (status == null)
                    throw new RestException(HttpStatusCode.NotFound, "Статус FinancialAnalysis не найден");

                await _mediator.Send(new Shared.Logic.CQRS.Kalkan.Check.Command
                {
                    SignedXml = request.Xml,
                    Identifier = application.User.UserName
                });

                application.Status = ApplicationTypeEnum.CMNew;
                application.StatusId = status.Id;

                await _dataContext.SaveChangesAsync(cancellationToken);

                _bpmFinAnalysisUrl += application.Id;
                new Thread(() =>
                {
                    Thread.CurrentThread.IsBackground = true;
                    new HttpClient().GetAsync(_bpmFinAnalysisUrl);
                    _logger.LogInformation($"GET {_bpmFinAnalysisUrl}");
                }).Start();
                

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }
    }
}
