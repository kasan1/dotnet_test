using Agro.Shared.Api.Controllers;
using Agro.Shared.Logic.CQRS.Files;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Bpm.Api.Controllers.Files
{
    public class FilesController : MediatrControllerBase
    {
        [HttpGet]
        [Route(ApiRoutes.Files.List)]
        public async Task<IActionResult> GetList([FromQuery] ListByEntity.Query query, CancellationToken cancellationToken)
        {
            //TODO: нужно задавать значение EntityType на серверном уровне
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.Files.Download)]
        public async Task<IActionResult> Download([FromRoute] Guid fileId, CancellationToken cancellationToken)
        {
            var fileData = await Mediator.Send(new Download.DownloadQuery
            {
                FileId = fileId
            }, cancellationToken);

            return File(fileData.Data.Stream, fileData.Data.ContentType, fileData.Data.Filename);
        }

        [HttpPost]
        [Route(ApiRoutes.Files.Upload)]
        public async Task<IActionResult> Upload([FromForm] Upload.UploadCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete]
        [Route(ApiRoutes.Files.Remove)]
        public async Task<IActionResult> Remove([FromRoute] Guid fileId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new Remove.RemoveCommand { FileId = fileId }, cancellationToken));
        }

        [HttpPost]
        [Route(ApiRoutes.Files.ImportCheckingList)]
        public async Task<IActionResult> ImportCheckingList([FromForm] Logic.CQRS.FinAnalysis.Import.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}
