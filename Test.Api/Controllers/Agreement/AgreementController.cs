using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agro.Okaps.Logic.CQRS.Agreement;

namespace Agro.Okaps.Api.Controllers.Agreement
{
    [AllowAnonymous]
    public class AgreementController : MediatrControllerBase
    {
        [HttpPost]
        [Route(ApiRoutes.Agreement.Create)]
        public async Task<IActionResult> Create([FromBody] Create.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}
