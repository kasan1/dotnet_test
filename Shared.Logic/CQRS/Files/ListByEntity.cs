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
    public class ListByEntity
    {
        public class Query : IRequest<Response<List<FileDto>>>
        {
            public Guid EntityId { get; set; }
            public EntityType EntityType { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<List<FileDto>>>
        {
            private readonly IFileService _fileService;

            public QueryHandler(Delegates.FileServiceResolver fileServiceResolver)
            {
                _fileService = fileServiceResolver(FileServiceTypeEnum.Database);
            }

            public async Task<Response<List<FileDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var files = await _fileService.GetEntityFiles(request.EntityType, request.EntityId);

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
