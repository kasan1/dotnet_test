using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Agro.Shared.Logic.CQRS.Dictionary;
using System.Threading;

namespace Agro.Bpm.Api.Controllers.Dictionary
{
    public class DictionariesController : MediatrControllerBase
    {
        [HttpGet]
        [Route(ApiRoutes.Dictionary.List)]
        public async Task<IActionResult> List([FromQuery] List.Query query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}
