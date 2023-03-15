using Agro.Okaps.Logic.CQRS.Files;
using Agro.Shared.Api.Controllers;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.CQRS.Files;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Okaps.Api.Controllers.Files
{
    public class FilesController : MediatrControllerBase
    {
        [HttpGet]
        [Route(ApiRoutes.Files.List)]
        public async Task<IActionResult> GetList([FromQuery] ListByEntity.Query query, CancellationToken cancellationToken)
        {
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

        [HttpGet]
        [Route(ApiRoutes.Files.ListUL)]
        public async Task<IActionResult> GetListUL([FromRoute] Guid applicationId, [FromQuery] ListUL.ListULQuery query, CancellationToken cancellationToken)
        {
            query.LoanApplicationId = applicationId;
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.Files.ListFL)]
        public async Task<IActionResult> GetListFL([FromRoute] Guid applicationId, [FromQuery] ListFL.ListFLQuery query, CancellationToken cancellationToken)
        {
            query.LoanApplicationId = applicationId;
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
