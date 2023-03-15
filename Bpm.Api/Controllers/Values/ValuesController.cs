using Agro.Bpm.Logic.CQRS.Camunda.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.Integrations.PKB;
using Agro.Bpm.Logic.CQRS.RoleControls;
using Microsoft.AspNetCore.Authorization;
using Agro.Shared.Api.Controllers;
using Agro.Shared.Logic.CQRS.Users;
using Agro.Shared.Logic.Extensions;
using Agro.Shared.Data.Context;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Agro.Bpm.Api.Controllers.Values
{
#if DEBUG
    [AllowAnonymous]
#endif
    public class ValuesController : MediatrControllerBase
    {

        private readonly DataContext _dataContext;
        public ValuesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPkbData([FromQuery] GetXmlByIin.Command query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPkbFile([FromQuery] UploadFileByIin.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetPkbXml([FromQuery] GetXmlByIin.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> StartProcess([FromQuery] StartProcess.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetConrols([FromQuery] Controls.Query query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetHash(string pwd, CancellationToken cancellationToken)
        {
            var alg = System.Security.Cryptography.SHA512.Create();
            alg.ComputeHash(System.Text.Encoding.UTF8.GetBytes(pwd));
            return Ok(System.Convert.ToBase64String(alg.Hash));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateRoleControls(Create.CreateCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> FinAnalysis(Shared.Logic.CQRS.FinAlalysis.Start.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> MigrateUsers(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new MigrateUsers.Command(), cancellationToken));
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<IActionResult> GetAllTasks([FromQuery]Logic.CQRS.LoanApplicaitons.TaskList.ListQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateNotification([FromBody] Shared.Logic.CQRS.Notifications.Create.CreateNotificationCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SendTo1C([FromBody] Logic.CQRS.Integrations._1C.Send.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetContractsByUserId([FromBody] Logic.CQRS.Integrations._1C.GetContracts.Command command, CancellationToken cancellationToken)
        {   
            return Ok(await Mediator.Send(command, cancellationToken));
        }


        [HttpPost]
        [Route("[action]")]
        public IActionResult ToCyrillic(string text)
        {
            return Ok(text.ToCyrillic());
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult ToLatin(string text)
        {
            return Ok(text.ToLatin());
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CheckingList(string name, string identifier, CancellationToken cancellation)
        {
            return Ok(await _dataContext.CheckingList
                       .Where(x =>
                            x.Identifier == identifier ||
                            x.Fullname.ToLower().Trim() == name.ToLower().Trim() ||
                            x.Fullname.ToLower().Trim() == name.ToCyrillic().ToLower().Trim() ||
                            x.Fullname.ToLower().Trim() == name.ToLatin().ToLower().Trim()

                       ).ToListAsync(cancellation));
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreditCommitteeMembersCount(Guid branchId, CancellationToken cancellation)
        {
            var countOfCommitteeMembers = await (from ub in _dataContext.UserBranches
                                                 join ur in _dataContext.UserRoles on ub.UserId equals ur.UserId
                                                 where ub.BranchId == branchId & ur.Role.Value == Shared.Data.Enums.Identity.RoleType.CreditCommittee
                                                 select ur.Role.Code)
                                                    .Distinct()
                                                    .CountAsync(cancellation);

            return Ok(countOfCommitteeMembers);
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CompleteAllTasks([FromForm]Logic.CQRS.Camunda.CompleteAllTasks.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

    }
}
