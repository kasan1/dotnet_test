using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Models.System;
using Agro.Shared.Logic.Services.System.File;
using MediatR;

namespace Agro.Shared.Logic.CQRS.Files
{
    public class Download
    {
        public class DownloadQuery : IRequest<Response<DownloadFileResult>>
        {
            public Guid FileId { get; set; }
        }

        public class DownloadQueryHandler : IRequestHandler<DownloadQuery, Response<DownloadFileResult>>
        {
            private readonly IFileService _fileService;

            public DownloadQueryHandler(Delegates.FileServiceResolver fileServiceResolver)
            {
                _fileService = fileServiceResolver(FileServiceTypeEnum.Database); 
            }

            public async Task<Response<DownloadFileResult>> Handle(DownloadQuery request, CancellationToken cancellationToken)
            {
                var file = await _fileService.DownloadAsync(request.FileId);

                return Response.Success("Запрос выполнен успешно", file);
            }
        }
    }
}
