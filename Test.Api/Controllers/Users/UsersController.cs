using Agro.Bpm.Logic.CQRS.Users;
using Agro.Okaps.Logic.CQRS.Users;
using Agro.Shared.Api.Controllers;
using Agro.Shared.Logic.CQRS.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Okaps.Api.Controllers.Users
{
    public class UsersController : MediatrControllerBase
    {
        [HttpPost]
        [Route(ApiRoutes.Users.Login)]
        public async Task<IActionResult> Login([FromBody] Login.LoginCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        [Route(ApiRoutes.Users.RefreshToken)]
        public async Task<IActionResult> RefreshToken(CancellationToken cancellationToken)
        {
            var command = new RefreshToken.RefreshTokenCommand
            {
                AccessToken = HttpContext.Request.Headers["X-Access-Token"].ToString(),
                RefreshToken = HttpContext.Request.Headers["X-Refresh-Token"].ToString()
            };

            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpPost]
        [Route(ApiRoutes.Users.Register)]
        public async Task<IActionResult> Register([FromBody] Register.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpPut(ApiRoutes.Users.UpdateProfile)]
        public async Task<IActionResult> UpdateProfile([FromForm] UpdateProfile.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpPut(ApiRoutes.Users.ChangePassword)]
        public async Task<IActionResult> ChangePassword(ChangePassword.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [Authorize]
        [HttpGet(ApiRoutes.Users.GetProfile)]
        public async Task<IActionResult> GetProfile(CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new Profile.Query(), cancellationToken));
        }

        [HttpPost(ApiRoutes.Users.ConfirmEmail)]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmail.Command command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }
    }
}
