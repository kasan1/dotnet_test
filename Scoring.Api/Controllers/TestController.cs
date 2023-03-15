using Agro.Scoring.Logic.Scoring.GKB;
using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agro.Scoring.Api.Controllers
{
    [AllowAnonymous]
    public class TestController : BaseController
    {
        private readonly IGKBOverdueCheckLogic _logic;
        public TestController(IGKBOverdueCheckLogic logic)
        {
            _logic = logic;
        }



        [HttpGet(nameof(GetMonthlyPayByFinInstitut))]
        public async Task<IActionResult> GetMonthlyPayByFinInstitut(Guid outServiceId)
        {
            try
            {
                var _ = await _logic.CallMonthlyPayByFinInstitut(outServiceId);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

    }
}
