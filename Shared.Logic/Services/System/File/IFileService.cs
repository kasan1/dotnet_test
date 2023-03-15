using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.Models.System;
using Microsoft.AspNetCore.Http;

namespace Agro.Shared.Logic.Services.System.File
{
    /// <summary>
    /// Service to work with files in the system
    /// </summary>
    public interface IFileService
    {
        
        /// <summary>
        /// Get list of files meta data by entity id
        /// </summary>
        /// <param name="entityTypeEnum">Entity Type Enum</param>
        /// <param name="entityId">Entity Id</param>
        /// <returns>List of <see cref="FileMetaData"/></returns>
        Task<List<FileMetaData>> GetEntityFiles(EntityType entityTypeEnum, Guid entityId);

        /// <summary>
        /// Get list of files meta data by entity ids
        /// </summary>
        /// <param name="entityTypeEnum">Entity Type Enum</param>
        /// <param name="entityIds">Entities Ids</param>
        /// <returns>List of <see cref="FileMetaData"/></returns>
        Task<List<FileMetaData>> GetEntitiesFiles(List<EntityType> entityTypes, IEnumerable<Guid> entityIds, CancellationToken cancellation);

        /// <summary>
        /// Get file as stream by file id
        /// </summary>
        /// <param name="fileId">File id</param>
        /// <returns>Returns <see cref="FileDownloadStreamResult"/> instance</returns>
        Task<DownloadFileResult> DownloadAsync(Guid fileId);

        /// <summary>
        /// Uploads file
        /// </summary>
        /// <param name="formFile">Represents file sent with the HttpRequest</param>
        /// <returns>Represents asynchronous operation</returns>
        Task<FileMetaData> UploadAsync(IFormFile formFile, EntityType entityTypeEnum, Guid entityId);

        /// <summary>
        /// Removes file by file id
        /// </summary>
        /// <param name="fileId">File id</param>
        /// <returns>Represents asynchronous operation</returns>
        Task RemoveAsync(Guid fileId);
    }
}
