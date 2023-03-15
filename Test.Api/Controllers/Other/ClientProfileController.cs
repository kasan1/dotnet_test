using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agro.Okaps.Logic;
using Agro.Okaps.Logic.Models;
using Agro.Shared.Api.Controllers;
using Agro.Shared.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Okaps.Api.Controllers
{
    [AllowAnonymous]
    public class ClientProfileController : BaseController
    {

        private readonly IClientProfileLogic _logic;

        public ClientProfileController(IClientProfileLogic logic)
        {
            _logic = logic;
        }



        [HttpPost("AddClientProfile")]
        public async Task<IActionResult> AddClientProfile([FromBody] ClientProfileInDto cliProfile)
        {
            try
            {
                var _ = await _logic.AddClientProfile(cliProfile);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        //[HttpGet("GetCurrentUserProfile")]
        //public async Task<IActionResult> GetClientProfileById()
        //{
        //    try
        //    {
        //        var _ = await _logic.GetClientProfileByID(CurrentUserId);
        //        return Ok(_);
        //    }
        //    catch (Exception e)
        //    {
        //        return ExceptionResult(e);
        //    }
        //}

        //[HttpGet("GetClientProfile/{UserId}")]
        //public async Task<IActionResult> GetClientProfileById(Guid UserId)
        //{
        //    try
        //    {
        //        var _ = await _logic.GetClientProfileByID(UserId);
        //        return Ok(_);
        //    }
        //    catch (Exception e)
        //    {
        //        return ExceptionResult(e);
        //    }
        //}

        [HttpPost("UpdateClientProfile")]
        public async Task UpdateClientProfile([FromBody] ClientProfileInDto cliProfile)
        {
            try
            {
                await _logic.UpdateClientProfile(cliProfile);

            }
            catch (Exception e)
            {

            }
        }

        [HttpGet("GetBranchAdressByClientId/{ClientId}")]
        public async Task<object> GetBranchAdressByClientId(Guid ClientId)
        {
            try
            {
                var res = await _logic.GetBranchAdressByClientId(ClientId);
                return res;
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        //[HttpGet("GetBranchAdressCurrentUser")]
        //public async Task<object> GetBranchAdressCurrentUser()
        //{
        //    try
        //    {
        //        var res = await _logic.GetBranchAdressByClientId(CurrentUserId);
        //        return res;
        //    }
        //    catch (Exception e)
        //    {
        //        return ExceptionResult(e);
        //    }
        //}
    }
}
