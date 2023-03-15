using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.Integrations._1C;
using Agro.Bpm.Logic.CQRS.Integrations.PKB;
using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Bpm.Api.Controllers.Integrations
{
    //[Authorize]
    public class IntegrationsController : MediatrControllerBase
    {
        [HttpPost(ApiRoutes.Integrations.PKB)]
        public async Task<IActionResult> GetPKBData([FromBody] ProcessPKB.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
        
        [HttpGet(ApiRoutes.Integrations.MonitoringReport)]
        public async Task<IActionResult> MonitoringReport([FromQuery] MonitoringReport.DownloadCommand command, CancellationToken cancellationToken)
        {
            var fileData = await Mediator.Send(command, cancellationToken);

            return File(fileData.Data.Stream, fileData.Data.ContentType, fileData.Data.Filename);
        }
    }
}
