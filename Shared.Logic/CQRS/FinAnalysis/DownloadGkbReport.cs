using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.GKB;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Models.System;
using MediatR;

namespace Agro.Shared.Logic.CQRS.FinAlalysis
{
    public class DownloadGkbReport
    {
        public class Command : IRequest<Response<DownloadFileResult>>
        {
            public string Identifier { get; set; }

            public bool IsFL { get; set; }
        }

        public class QueryHandler : IRequestHandler<Command, Response<DownloadFileResult>>
        {
            private readonly IGKBLogic _gkbLogic;

            public QueryHandler(IGKBLogic gkbLogic)
            {
                _gkbLogic = gkbLogic;
            }

            public async Task<Response<DownloadFileResult>> Handle(Command request, CancellationToken cancellationToken)
            {
                var data = await _gkbLogic.GetGKBFile(request.Identifier, request.IsFL, cancellationToken);

                return Response.Success("Запрос выполнен успешно", new DownloadFileResult
                {
                    ContentType = "application/pdf",
                    Filename = $"gkb-{request.Identifier}-{DateTime.Now:dd-MM-yyyy_HH-mm}.pdf",
                    Stream = new MemoryStream(data)
                });
            }
        }
    }
}
