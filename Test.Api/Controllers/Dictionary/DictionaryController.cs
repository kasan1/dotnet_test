using System.Threading;
using System.Threading.Tasks;
using Agro.Okaps.Logic.CQRS.Dictionary;
using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Okaps.Api.Controllers
{
    [AllowAnonymous]
    public class DictionaryController : MediatrControllerBase
    {
        [HttpGet]
        [Route(ApiRoutes.Dictionary.ListTechTypes)]
        public async Task<IActionResult> ListTechTypes([FromQuery] ListTechTypes.ListQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.Dictionary.ListTechProducts)]
        public async Task<IActionResult> ListTechProducts([FromQuery] ListTechProducts.ListQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.Dictionary.ListTechModels)]
        public async Task<IActionResult> ListTechModels([FromQuery] ListTechModels.ListQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.Dictionary.ListCountries)]
        public async Task<IActionResult> ListCountries([FromQuery] ListCountries.ListQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.Dictionary.ListProviders)]
        public async Task<IActionResult> ListProviders([FromQuery] ListProviders.ListQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }


        [HttpGet]
        [Route(ApiRoutes.Dictionary.List)]
        public async Task<IActionResult> List([FromRoute]string code, [FromQuery] Shared.Logic.CQRS.Dictionary.List.Query query, CancellationToken cancellationToken)
        {
            query.Code = code;
            return Ok(await Mediator.Send(query, cancellationToken));
        }
    }
}