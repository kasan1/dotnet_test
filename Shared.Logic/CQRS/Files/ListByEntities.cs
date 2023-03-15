using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.CQRS.Files.DTOs;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.File;
using MediatR;

namespace Agro.Shared.Logic.CQRS.Files
{
    public class ListByEntities
    {
        public class ListQuery : IRequest<Response<List<FileDto>>>
        {
            public List<Guid> EntityIds { get; set; }
            public List<EntityType> EntityTypes { get; set; }
        }

        public class ListQueryHandler : IRequestHandler<ListQuery, Response<List<FileDto>>>
        {
            private readonly IFileService _fileService;

            public ListQueryHandler(Delegates.FileServiceResolver fileServiceResolver)
            {
                _fileService = fileServiceResolver(FileServiceTypeEnum.Database);
            }

            public async Task<Response<List<FileDto>>> Handle(ListQuery request, CancellationToken cancellationToken)
            {
                var files = await _fileService.GetEntitiesFiles(request.EntityTypes, request.EntityIds, cancellationToken);

                var result = new List<FileDto>();

                if (!files.Any())
                    return Response.Success("Запрос выполнен успешно", result);

                foreach (var file in files)
                {
                    result.Add(new FileDto
                    {
                        Id = file.Id,
                        Filename = !string.IsNullOrEmpty(file.Filename) ? file.Filename : file.Id.ToString(),
                        Url = $"api/files/{file.Id}"
                    });
                }

                return Response.Success("Запрос выполнен успешно", result);
            }
        }
    }
}
