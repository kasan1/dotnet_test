using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.CQRS.Notifications;
using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Okaps.Api.Controllers.Notifications
{
#if RELEASE
    [Authorize]
#else
    [AllowAnonymous]
#endif
    public class NotificationsController : MediatrControllerBase
    {
        [HttpGet]
        [Route(ApiRoutes.Notifications.List)]
        public async Task<IActionResult> List([FromQuery] List.Query query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
