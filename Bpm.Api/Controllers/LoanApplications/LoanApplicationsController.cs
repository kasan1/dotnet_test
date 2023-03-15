using Agro.Bpm.Logic.CQRS.Camunda;
using Agro.Bpm.Logic.CQRS.LoanApplicaitons;
using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Bpm.Api.Controllers.LoanApplications
{
    [Authorize]
    public class LoanApplicationsController : MediatrControllerBase
    {
        [HttpGet]
        [Route(ApiRoutes.LoanApplications.List)]
        public async Task<IActionResult> GetList([FromQuery] List.ListQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.LoanApplications.Navigation)]
        public async Task<IActionResult> GetNavigation([FromQuery] Navigation.NavigationQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.LoanApplications.Details)]
        public async Task<IActionResult> GetDetails([FromRoute] string applicationId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new Details.Query { 
                LoanApplicationTaskId = Guid.Parse(applicationId) 
            }, cancellationToken));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route(ApiRoutes.LoanApplications.CreateTask)]
        public async Task<IActionResult> CreateTask([FromBody] CreateTask.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        [Route(ApiRoutes.LoanApplications.CompleteTask)]
        public async Task<IActionResult> CompleteTask([FromForm] CompleteTask.CompleteTaskCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route(ApiRoutes.LoanApplications.ChangeStatus)]
        public async Task<IActionResult> ChangeStatus([FromBody] ChangeStatus.ChangeStatusCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.LoanApplications.ExpertiseResults)]
        public async Task<IActionResult> GetExpertiseResults([FromRoute] Guid applicationTaskId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new ExpertiseResult.Query
            {
                LoanApplicationTaskId = applicationTaskId
            }, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.LoanApplications.CommitteeResults)]
        public async Task<IActionResult> GetCommitteeResults([FromRoute] Guid applicationTaskId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new CommitteeResult.Query
            {
                LoanApplicationTaskId = applicationTaskId
            }, cancellationToken));
        }
    }
}
