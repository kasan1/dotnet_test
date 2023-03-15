using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.CQRS.FinAlalysis;
using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Agro.Shared.Logic.CQRS.FinancialAnalysis;
using Agro.Bpm.Logic.CQRS.Camunda.Commands;

namespace Agro.Bpm.Api.Controllers.FinAnalysis
{
#if RElEASE
    [Authorize]
#else
    [AllowAnonymous]
#endif
    public class FinAnalysisController : MediatrControllerBase
    {
        //TODO: Открыть только для окапс сервера
        [AllowAnonymous]
        [HttpGet]
        [Route(ApiRoutes.FinAnalysis.Start)]
        public async Task<IActionResult> Start([FromQuery] Start.Command command, CancellationToken cancellationToken)
        {
            await Mediator.Send(command, cancellationToken);

            await Mediator.Send(new FillTemplateFile.Command { LoanApplicationId = command.LoanApplicationId }, cancellationToken);
            
            await Mediator.Send(new StartProcess.Command { ApplicationId = command.LoanApplicationId }, cancellationToken);

            return Ok();
        }

        [HttpPost]
        [Route(ApiRoutes.FinAnalysis.FillTemplateFile)]
        public async Task<IActionResult> TemplateFile([FromQuery] FillTemplateFile.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        //TODO: Открыть только для админа
        [HttpGet]
        [Route(ApiRoutes.FinAnalysis.GkbReport)]
        public async Task<IActionResult> GkbReport([FromQuery] DownloadGkbReport.Command command, CancellationToken cancellationToken)
        {
            var fileData = await Mediator.Send(command, cancellationToken);
            return File(fileData.Data.Stream, fileData.Data.ContentType, fileData.Data.Filename);
        }
    }
}
