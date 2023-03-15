using System;
using System.Net;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Agro.Shared.Logic.Models.System;
using System.Collections.Generic;
using System.Linq;
using IoFile = System.IO.File;
using Agro.Shared.Data.Enums.System;
using System.Threading;

namespace Agro.Shared.Logic.Services.System.File
{
    public class LocalFileService : IFileService
    {
        private readonly DataContext _dataContext;
        private const string _uploadFolder = "Uploads";

        public LocalFileService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<DownloadFileResult> DownloadAsync(Guid fileId)
        {
            var file = await _dataContext.Files
                    .FindAsync(fileId);

            if (file == null)
                throw new RestException(HttpStatusCode.NotFound, "File not found");

            var fs = IoFile.OpenRead(file.Path);
            fs.Position = 0;

            return new DownloadFileResult
            {
                Filename = file.Filename,
                ContentType = file.ContentType,
                Stream = fs
            };
        }

        public async Task RemoveAsync(Guid fileId)
        {
            var file = await _dataContext.Files
                    .FindAsync(fileId);

            // TODO: File cleaner journal

            if (file != null)
            {
                if (IoFile.Exists(file.Path))
                    IoFile.Delete(file.Path);

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
            string webRootPath = Environment.CurrentDirectory;
            string folderPath = Path.Combine(webRootPath, _uploadFolder, entityTypeEnum.ToString());
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, fileUniqueName.ToString() + Path.GetExtension(formFile.FileName));

            // Save file
            using var stream = new FileStream(filePath, FileMode.Create);
            formFile.CopyTo(stream);

            // Create and save meta data
            var file = new Data.Entities.System.File
            {
                Id = fileUniqueName,
                EntityId = entityId,
                EntityTypeId = entityType.Id,
                Filename = formFile.FileName,
                ContentType = formFile.ContentType,
                Length = formFile.Length,
                Path = filePath
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
            }; ;
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

        public async Task<List<FileMetaData>> GetEntitiesFiles(List<EntityType> entityTypes, IEnumerable<Guid> entityIds, CancellationToken cancellation)
        {
            var entityTypesIds = await _dataContext.EntityTypes
                    .Where(x => entityTypes.Contains(x.EntityTypeId))
                    .Select(x => x.Id)
                    .ToListAsync(cancellation);

            if (!entityTypesIds.Any())
                throw new ArgumentException(nameof(entityTypes));

            var files = await _dataContext.Files
                .Where(x => entityIds.Contains(x.EntityId) && entityTypesIds.Contains(x.EntityTypeId))
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
    }
}
