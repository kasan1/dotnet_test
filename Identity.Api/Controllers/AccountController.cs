using Agro.Identity.Logic;
using Agro.Identity.Logic.Models;
using Agro.Shared.Api.Controllers;
using Agro.Shared.Logic.Common.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agro.Identity.Api.Controllers
{
    /// <summary>
    /// Контроллер авторизации
    /// </summary>

    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly IAccountLogic _logic;
        public AccountController(IAccountLogic logic)
        {
            _logic = logic;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginInDto login)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var _ = await _logic.Login(login);
            return Ok(_);
        }

        [HttpPost("refresh")]
        public async Task<IActionResult> Refresh()
        {
            try
            {
                var _ = await _logic.UpdateToken(
                    HttpContext.Request.Headers["X-Access-Token"].ToString(),
                    HttpContext.Request.Headers["X-Refresh-Token"].ToString()
                );
                return Ok(_);
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(403);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpPost("registerPhysical")]
        public async Task<IActionResult> Register([FromBody] PhysicalRegisterInDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _logic.Register(model, true);
                return Ok(_);
            }
            catch(RestException ex)
            {
                return StatusCode((int)ex.StatusCode, ex.Message);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpPost("registerJuridical")]
        public async Task<IActionResult> Register([FromBody] JuridicalRegisterInDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _logic.Register(model, false);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpGet("{identifier}")]
        public async Task<IActionResult> GetByIdentifier([FromRoute][Required] string identifier)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _logic.GetByIdentifier(identifier);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}
