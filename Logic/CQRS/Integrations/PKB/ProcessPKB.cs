using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Agro.Integration.Logic.Models.PKB;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.Security;
using MediatR;

namespace Agro.Bpm.Logic.CQRS.Integrations.PKB
{
    public class ProcessPKB
    {
        public class Command : IRequest<Response<Unit>>
        {
            public string Iin { get; set; }
            public Guid LoanApplicationId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IMediator _mediator;
            private readonly IUserAccessor _userAccessor;
            private const string _subjectFoundText = "Субъект найден";

            public Handler(DataContext dataContext, IMediator mediator, IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _mediator = mediator;
                _userAccessor = userAccessor;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var xmlResponse = await _mediator.Send(new GetXmlByIin.Command() { Iin = request.Iin }, cancellationToken);

                var pkbData = await _dataContext.OutServices
                    .FindAsync(xmlResponse.Data);

                if (pkbData == null)
                    throw new RestException(HttpStatusCode.NotFound, "Не удалось получить информацию из ПКБ");

                var serializer = new XmlSerializer(typeof(PKBResponse.ROOT));

                using var reader = new StringReader(pkbData.ResponseContent);

                var pkbResponse = (PKBResponse.ROOT)serializer.Deserialize(reader);

                // TODO: Translate into locals
                if (pkbResponse.Bankruptcy.Status.Value.Contains(_subjectFoundText, StringComparison.InvariantCultureIgnoreCase))
                    throw new RestException(HttpStatusCode.BadRequest, @"Отказано в выдаче займа по экспресс лизингу в связи 
                        с наличием Заявителя в списке банкротов, в отношении которых решения суда о признании 
                        их банкротами вступили в законную силу");

                if (pkbResponse.TerrorList.Status.Value.Contains(_subjectFoundText, StringComparison.InvariantCultureIgnoreCase))
                    throw new RestException(HttpStatusCode.BadRequest, @"Отказано в выдаче займа по экспресс лизингу в связи 
                        с наличием Заявителя в списке организаций и лиц, связанных с финансированием терроризма и экстремизма");

                await _mediator.Send(new UploadFileByIin.Command() { 
                    Iin = request.Iin, 
                    LoanApplicationId = request.LoanApplicationId
                }, cancellationToken);

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }
    }
}
