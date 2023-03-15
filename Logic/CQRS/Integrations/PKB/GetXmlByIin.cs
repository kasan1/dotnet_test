using Agro.Shared.Logic.OutService.PKB;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Bpm.Logic.CQRS.Integrations.PKB
{
    public class GetXmlByIin
    {
        public class Command : IRequest<Response<Guid>>
        {
            public string Iin { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<Guid>>
        {
            private readonly IPKBLogic _pKBLogic;

            public Handler(IPKBLogic pKBLogic)
            {
                _pKBLogic = pKBLogic;
            }

            public async Task<Response<Guid>> Handle(Command request, CancellationToken cancellationToken)
            {
                var id = await _pKBLogic.GetPKBXml(request.Iin, cancellationToken); // Guid.Parse("269753ac-24e7-4040-8d02-f9fa6af6f17b"); for tests

                if (!id.HasValue)
                    throw new RestException(HttpStatusCode.NotFound, "Не удалось найти XML");

                return Response.Success("Запрос выполнен успешно", id.Value);
            }
        }
    }
}
