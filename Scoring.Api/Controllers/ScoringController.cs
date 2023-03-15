using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Agro.Scoring.Logic.Scoring;
using Agro.Shared.Api.Controllers;
using Agro.Shared.Logic.OutService.PKB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Scoring.Api.Controllers
{
    [AllowAnonymous]
    public class ScoringController : BaseController
    {
        private readonly IOverdueCheckLogic _overdueCheck;
        private readonly IPKBChecksLogic _PkbChecks;
        private readonly ICheckAffilationLogic _checkAffilation;

        public ScoringController(IOverdueCheckLogic overdueCheck, IPKBChecksLogic PKBChecks, ICheckAffilationLogic checkAffilation)
        {
            _overdueCheck = overdueCheck;
            _PkbChecks = PKBChecks;
            _checkAffilation = checkAffilation;

        }

        /// <summary>
        /// проверяет просрочки за последние 24 месяца (2 года), 
        /// используется внешний сервис ГКБ, Кредитный отчет - расширенный
        /// </summary>
        /// <param name="outServiceId"></param>
        /// <returns></returns>
        [HttpGet("CallExistenceDPDPastInToYears{outServiceId}")]
        public ActionResult<object> CallExistenceDPDPastInToYears(Guid outServiceId)
        {
            return _overdueCheck.CallExistenceDPDPastInToYears(outServiceId);
        }

        /// <summary>
        /// проверка на текущие просрочки
        /// используется внешний сервис ГКБ, Кредитный отчет - расширенный
        /// </summary>
        /// <param name="outServiceId"></param>
        /// <returns></returns>
        [HttpGet("CallExistenceOfAmountDPD{outServiceId}")]
        public async Task<ActionResult<object>> CallExistenceOfAmountDPD(Guid outServiceId)
        {
            return Ok(await _overdueCheck.CallExistenceOfAmountDPD(outServiceId));
        }


        /// <summary>
        /// проверка из публичных источников 
        /// внешний сервис ПКБ,  Отчет по дополнительным источникам
        /// </summary>
        /// <param name="outServiceId"></param>
        /// <returns></returns>
        [HttpGet("CallCheckPublicSources{outServiceId}")]
        public async Task<ActionResult<object>> CallCheckPublicSources(Guid outServiceId)
        {
            return Ok( await _PkbChecks.CallCheckPublicSources(outServiceId));
        }


        /// <summary>
        /// получение кредитных обязательств из кредитного отчета
        /// используется внешний сервис ГКБ, Кредитный отчет - расширенный
        /// </summary>
        /// <param name="outServiceId"></param>
        /// <returns></returns>
        [HttpGet("CallGetAnnualPay")]
        public ActionResult<double> CallGetAnnualPay(Guid outServiceId)
        {
            return _overdueCheck.CallGetAnnualPay(outServiceId);
        }


        /// <summary>
        /// получение массива  кредитных обязательств из кредитного отчета
        /// 
        /// </summary>
        /// <param name="outServiceId"></param>
        /// <returns></returns>
        [HttpGet("GetMonthlyPayByFinInstitut")]
        public ActionResult<object> GetMonthlyPayByFinInstitut(Guid outServiceId)
        {
            return _overdueCheck.CallMonthlyPayByFinInstitut(outServiceId);
        }



    }
}
