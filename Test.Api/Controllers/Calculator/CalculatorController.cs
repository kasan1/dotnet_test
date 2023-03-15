using System.Threading;
using System.Threading.Tasks;
using Agro.Okaps.Logic.CQRS.Calculator;
using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Okaps.Api.Controllers
{
    [AllowAnonymous]
    public class CalculatorController : MediatrControllerBase
    {
        [HttpPost]
        [Route(ApiRoutes.Calculator.Calculate)]
        public async Task<IActionResult> Calculate(Calculate.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        [Route(ApiRoutes.Calculator.UpdateModelsRate)]
        public async Task<IActionResult> UpdateModelsRate(UpdateRate.UpdateRateCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}
