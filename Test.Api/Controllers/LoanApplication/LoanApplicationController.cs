using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Okaps.Logic.CQRS.LoanApplication;
using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Okaps.Api.Controllers.LoanApplication
{
#if RELEASE
    [Authorize]
#endif
    public class LoanApplicationController : MediatrControllerBase
    {
        [HttpGet]
        [Route(ApiRoutes.LoanApplication.List)]
        public async Task<IActionResult> List([FromQuery] List.Query query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpPost]
        [Route(ApiRoutes.LoanApplication.Post)]
        public async Task<IActionResult> Create([FromBody] Create.CreateCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPut]
        [Route(ApiRoutes.LoanApplication.Update)]
        public async Task<IActionResult> Update([FromBody] Update.UpdateCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete]
        [Route(ApiRoutes.LoanApplication.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new Delete.DeleteCommand()
            {
                LoanApplicationId = applicationId
            }, cancellationToken));
        }

        [HttpPost]
        [Route(ApiRoutes.LoanApplication.Sign)]
        public async Task<IActionResult> Sign([FromRoute] Guid applicationId, [FromBody] Sign.SignCommand command, CancellationToken cancellationToken)
        {
            command.LoanApplicationId = applicationId;
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.LoanApplication.GetContracts)]
        public async Task<IActionResult> GetContracts([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new Contracts.ContractsQuery { ApplicationId = applicationId }, cancellationToken));
        }


        [HttpPost]
        [Route(ApiRoutes.LoanApplication.PostDetails)]
        public async Task<IActionResult> PostDetails([FromRoute] Guid applicationId, [FromBody] Shared.Logic.CQRS.ClientDetails.CreateOrUpdate.Command command, CancellationToken cancellationToken)
        {
            command.LoanApplicationId = applicationId;
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpDelete]
        [Route(ApiRoutes.LoanApplication.DeleteDetails)]
        public async Task<IActionResult> DeleteDetails([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new Logic.CQRS.ClientDetails.Delete.DeleteDetailsCommand { LoanApplicationId = applicationId }, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.LoanApplication.GetDetails)]
        public async Task<IActionResult> GetDetails([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new Shared.Logic.CQRS.ClientDetails.Details.Query { LoanApplicationId = applicationId }, cancellationToken));
        }

        [HttpPost]
        [Route(ApiRoutes.LoanApplication.PostActivities)]
        public async Task<IActionResult> PostActivities([FromRoute] Guid applicationId, [FromBody] Shared.Logic.CQRS.ClientActivities.Create.CreateActivityCommand command, CancellationToken cancellationToken)
        {
            command.LoanApplicationId = applicationId;
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.LoanApplication.GetActivities)]
        public async Task<IActionResult> GetActivities([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new Shared.Logic.CQRS.ClientActivities.Get.GetActivitiesQuery { LoanApplicationId = applicationId }, cancellationToken));
        }

        /// <summary>
        /// Получить файл заявления
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        [Route(ApiRoutes.LoanApplication.GetFile)]
        public async Task<IActionResult> GetFile([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            var fileData = await Mediator.Send(new GetDocument.GetDocumentCommand
            {
                LoanApplicationId = applicationId
            }, cancellationToken);

            return File(fileData.Stream, fileData.ContentType, fileData.Filename);
        }

        /// <summary>
        /// Получить файл анкеты
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        [Route(ApiRoutes.LoanApplication.GetDetailsFile)]
        public async Task<IActionResult> GetDetailsFile([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            var fileData = await Mediator.Send(new Logic.CQRS.ClientDetails.GetAnketaFile.Command
            {
                LoanApplicationId = applicationId
            }, cancellationToken);

            return File(fileData.Stream, fileData.ContentType, fileData.Filename);
        }

        [HttpPost]
        [Route(ApiRoutes.LoanApplication.PostExtraDetails)]
        public async Task<IActionResult> PostExtraDetails([FromRoute] Guid applicationId, [FromBody] Shared.Logic.CQRS.ClientExtraDetails.CreateOrUpdate.Command command, CancellationToken cancellationToken)
        {
            command.LoanApplicationId = applicationId;
            return Ok(await Mediator.Send(command, cancellationToken));
        }


        [HttpGet]
        [Route(ApiRoutes.LoanApplication.GetExtraDetails)]
        public async Task<IActionResult> GetExtraDetails([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new Shared.Logic.CQRS.ClientExtraDetails.Details.Query { LoanApplicationId = applicationId }, cancellationToken));
        }


        [HttpGet]
        [Route(ApiRoutes.LoanApplication.GetFiles)]
        public async Task<IActionResult> GetAllFiles(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new AllFiles.Query(), cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.LoanApplication.GetAllContracts)]
        public async Task<IActionResult> GetAllContracts(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new AllContracts.Query(), cancellationToken));
        }

    }
}
