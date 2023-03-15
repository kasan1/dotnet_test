using Agro.Bpm.Logic.CQRS.ReportDocuments.Word;
using Agro.Shared.Api.Controllers;
using Agro.Shared.Logic.CQRS.Files;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Bpm.Api.Controllers.WordReports
{
    public class WordReportsController : MediatrControllerBase
    {
        [HttpGet]
        [Route(ApiRoutes.WordReports.MinutesOfCreditCommitteeMeeting)]
        public async Task<IActionResult> Download([FromRoute] Guid applicationId, CancellationToken cancellationToken)
        {
            var fileData = await Mediator.Send(new MinutesOfCreditCommitteeMeetingWordProtocol.Query
            {
                LoanApplicationId = applicationId
            }, cancellationToken);

            return File(fileData.Data.Stream, fileData.Data.ContentType, fileData.Data.Filename);
        }
    }
}
