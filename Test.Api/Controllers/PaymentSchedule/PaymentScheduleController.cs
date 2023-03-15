using System.Threading;
using System.Threading.Tasks;
using Agro.Okaps.Logic.CQRS.PaymentSchedule;
using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Okaps.Api.Controllers.PaymentSchedule
{
    [AllowAnonymous]
    public class PaymentScheduleController : MediatrControllerBase
    {
        [HttpGet]
        [Route(ApiRoutes.PaymentSchedule.Download)]
        public async Task<IActionResult> Download([FromQuery] Download.DownloadCommand command, CancellationToken cancellationToken)
        {
            var fileData = await Mediator.Send(command, cancellationToken);
            return File(fileData.Stream, fileData.ContentType, fileData.Filename);
        }
    }
}
