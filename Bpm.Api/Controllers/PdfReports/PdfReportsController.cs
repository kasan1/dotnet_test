using System;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.ReportDocuments;
using jsreport.AspNetCore;
using jsreport.Types;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Bpm.Api.Controllers.PdfReports
{
    public class PdfReportsController : Controller
    {
        private readonly IMediator _mediator;

        public PdfReportsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route(ApiRoutes.PdfReports.MinutesOfCreditCommitteeMeeting)]
        [MiddlewareFilter(typeof(JsReportPipeline))]
        public async Task<IActionResult> MinutesOfCreditCommitteeMeeting(Guid applicationId)
        {
            HttpContext.JsReportFeature().Recipe(Recipe.ChromePdf);

            var reportData = await _mediator.Send(new MinutesOfCreditCommitteeMeeting.Query() { LoanApplicationId = applicationId });

            return View("Views/PdfReports/CreditCommittee/MinutesOfCreditCommitteeMeeting.cshtml", reportData.Data);
        }
    }
}
