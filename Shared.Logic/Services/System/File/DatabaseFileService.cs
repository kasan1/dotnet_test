using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.System;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Agro.Shared.Logic.Services.System.File
{
    public class DatabaseFileService : IFileService
    {
        private readonly DataContext _dataContext;

        public DatabaseFileService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<DownloadFileResult> DownloadAsync(Guid fileId)
        {
            var file = await _dataContext.Files
                    .FindAsync(fileId);

            if (file == null)
                throw new RestException(HttpStatusCode.NotFound, "File not found");

            return new DownloadFileResult
            {
                Filename = file.Filename,
                ContentType = file.ContentType,
                Stream = new MemoryStream(file.Content)
            };
        }

        public async Task<List<FileMetaData>> GetEntitiesFiles(List<EntityType> entityTypes, IEnumerable<Guid> entityIds, CancellationToken cancellation)
        {
            var entityTypeIds = await _dataContext.EntityTypes
                .Where(x => entityTypes.Contains(x.EntityTypeId))
                .Select(x => x.Id)
                .ToListAsync(cancellation);

            if (!entityTypeIds.Any())
                throw new ArgumentException(nameof(entityTypes));

            var files = await _dataContext.Files
                .Where(x => entityIds.Contains(x.EntityId) && entityTypeIds.Contains(x.EntityTypeId))
                .OrderBy(x => x.EntityId).ThenBy(x => x.CreatedDate)
                .Select(x => new FileMetaData
                {
                    Id = x.Id,
                    EntityId = x.EntityId,
                    Filename = x.Filename,
                    ContentType = x.ContentType,
                    Path = x.Path,
                    Size = x.Length
                })
                .ToListAsync(cancellation);
            return files;
        }

        public async Task<List<FileMetaData>> GetEntityFiles(EntityType entityTypeEnum, Guid entityId)
        {
            var entityType = await _dataContext.EntityTypes
                    .FirstOrDefaultAsync(x => x.EntityTypeId == entityTypeEnum);
            if (entityType == null)
                throw new ArgumentException(nameof(entityTypeEnum));

            var files = await _dataContext.Files
                .Where(x => x.EntityId == entityId && x.EntityTypeId == entityType.Id)
                .Select(x => new FileMetaData
                {
                    Id = x.Id,
                    Filename = x.Filename,
                    ContentType = x.ContentType,
                    Path = x.Path,
                    Size = x.Length
                })
                .ToListAsync();

            return files;
        }

        public async Task RemoveAsync(Guid fileId)
        {
            var file = await _dataContext.Files
                    .FindAsync(fileId);

            if (file != null)
            {
                _dataContext.Files.Remove(file);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<FileMetaData> UploadAsync(IFormFile formFile, EntityType entityTypeEnum, Guid entityId)
        {
            var entityType = await _dataContext.EntityTypes
                .FirstOrDefaultAsync(x => x.EntityTypeId == entityTypeEnum);
            if (entityType == null)
                throw new ArgumentException(nameof(entityTypeEnum));

            Guid fileUniqueName = Guid.NewGuid();
            string filePath = Path.Combine($"api/files/{fileUniqueName}");

            using var stream = new MemoryStream();
            await formFile.CopyToAsync(stream);

            var file = new Data.Entities.System.File
            {
                Id = fileUniqueName,
                EntityId = entityId,
                EntityTypeId = entityType.Id,
                Filename = formFile.FileName,
                ContentType = formFile.ContentType,
                Length = formFile.Length,
                Path = filePath,
                Content = stream.ToArray()
            };

            await _dataContext.Files.AddAsync(file);
            await _dataContext.SaveChangesAsync();

            return new FileMetaData
            {
                Id = file.Id,
                ContentType = file.ContentType,
                Filename = file.Filename,
                Path = file.Path,
                Size = file.Length
            };
        }
    }
}
