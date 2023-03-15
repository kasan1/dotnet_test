using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.File;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Agro.Shared.Logic.CQRS.Files
{
    public class Upload
    {
        public class UploadCommand : IRequest<Response<Unit>>
        {
            public Guid EntityId { get; set; }
            public EntityType EntityType { get; set; }
            public IFormFileCollection Files { get; set; }
        }

        public class UploadCommandHandler : IRequestHandler<UploadCommand, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IFileService _fileService;
            private readonly ILogger<UploadCommandHandler> _logger;

            public UploadCommandHandler(DataContext dataContext, Delegates.FileServiceResolver fileServiceResolver, ILogger<UploadCommandHandler> logger)
            {
                _dataContext = dataContext;
                _fileService = fileServiceResolver(FileServiceTypeEnum.Database);
                _logger = logger;
            }

            public async Task<Response<Unit>> Handle(UploadCommand request, CancellationToken cancellationToken)
            {
                foreach (var file in request.Files.OrderBy(x => x.Length))
                {
                    if (file.Length > 20 * 1024 * 1024)
                        throw new RestException(HttpStatusCode.BadRequest, "Файл не должен привышать 20 МБ.");

                    await _fileService.UploadAsync(file, request.EntityType, request.EntityId);
                }

                return Response.Success("Файлы успешно загружены", Unit.Value);
            }
        }
    }
}
