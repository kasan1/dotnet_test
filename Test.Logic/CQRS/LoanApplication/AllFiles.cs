using Agro.Okaps.Logic.CQRS.LoanApplication.Dtos;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.File;
using Agro.Shared.Logic.Services.System.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Okaps.Logic.CQRS.LoanApplication
{
    public class AllFiles
    {
        public class Query : IRequest<Response<List<FileDto>>>
        {
        }

        public class Handler : IRequestHandler<Query, Response<List<FileDto>>>
        {
            private readonly DataContext _dataContext;
            private readonly IUserAccessor _userAccessor;
            private readonly IFileService _fileService;

            public Handler(
                DataContext dataContext,
                Delegates.FileServiceResolver fileServiceResolver,
                IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _userAccessor = userAccessor;
                _fileService = fileServiceResolver(FileServiceTypeEnum.Database);
            }

            public async Task<Response<List<FileDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var aplications = await _dataContext.LoanApplications
                    .Where(x => !x.IsDeleted & x.UserId == _userAccessor.GetCurrentUserId())
                    .Select(x => new { x.Id, x.RegNumber, x.CreatedDate }).ToListAsync(cancellationToken);

                var aplicationsIds = aplications.Select(x => x.Id);

                // Use exclude filter instead
                var entityType = await _dataContext.EntityTypes.FirstOrDefaultAsync(x => x.EntityTypeId == EntityType.Personality);
                var list = await _fileService.GetEntitiesFiles(new List<EntityType> { entityType.EntityTypeId }, aplicationsIds, cancellationToken);
                
                var result = new List<FileDto>();
                foreach (var file in list)
                {
                    var application = aplications.FirstOrDefault(x => x.Id == file.EntityId);
                    result.Add(new FileDto
                    {
                        DocumentType = entityType.Description,
                        ApplicationNumber = application.RegNumber,
                        ApplicationDate = application.CreatedDate,
                        Url = $"api/files/{file.Id}",
                        Filename = file.Filename,
                        Id = file.Id
                    });
                }

                return Response.Success("Запрос выполнен успешно", result);
            }
        }
    }
}
