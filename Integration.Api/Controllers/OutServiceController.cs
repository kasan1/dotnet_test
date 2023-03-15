using Agro.Integration.Logic.OutService.ASP;
using Agro.Integration.Logic.OutService.GBDFL;
using Agro.Integration.Logic.OutService.GBDUL;
using Agro.Integration.Logic.OutService.GCVP;
using Agro.Integration.Logic.OutService.GKB;
using Agro.Shared.Logic.OutService.PKB;
using Agro.Integration.Logic.OutService.ZAGS;
using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agro.Integration.Api.Controllers
{
    [AllowAnonymous]
    public class OutServiceController : BaseController
    {
        private readonly IPKBLogic _PKBlogic;
        private readonly IGBDFLLogic _GBDFLLogic;
        private readonly IGBDULLogic _GBDULLogic;
        private readonly IZAGSLogic _ZAGSLogic;
        private readonly IGCVPLogic _GCVPLogic;
        private readonly IASPLogic _ASPLogic;
        private readonly IGKBLogic _GKBLogic;
        public OutServiceController( 
            IGBDFLLogic GBDFLLogic, 
            IGBDULLogic GBDULLogic, 
            IZAGSLogic ZAGSLogic,
            IGCVPLogic GCVPLogic,
            IASPLogic ASPLogic,
            IGKBLogic GKBLogic)
        {
            _GBDFLLogic = GBDFLLogic;
            _GBDULLogic = GBDULLogic;
            _ZAGSLogic = ZAGSLogic;
            _GCVPLogic = GCVPLogic;
            _ASPLogic = ASPLogic;
            _GKBLogic = GKBLogic;
        }

        /// <summary>
        /// ПКБ
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetPKBInfo))]
        public async Task<IActionResult> GetPKBInfo([FromQuery][Required]string iin)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _PKBlogic.GetPKBXml(iin);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
        /// <summary>
        /// Получени информации о ИП
        /// </summary>
        /// <param name="iin"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetIpInfoByPKB))]
        public async Task<IActionResult> GetIpInfoByPKB([FromQuery][Required] string iin)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _GKBLogic.GetCreditReportTypes(iin);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }



        /// <summary>
        /// ГБД ФЛ
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetGBDFLInfo))]
        public async Task<IActionResult> GetGBDFLInfo([FromQuery][Required]string iin)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _GBDFLLogic.GetGBDFL(iin);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetGBDFLInfoByIIN))]
        public async Task<IActionResult> GetGBDFLInfoByIIN([FromQuery][Required]string iin)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _GBDFLLogic.GetGBDFLByIIN(iin);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetGBDByApplicationId))]
        public async Task<IActionResult> GetGBDByApplicationId([FromQuery][Required] string ApplicationId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _GBDFLLogic.GetGBDByApplicationId(ApplicationId);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// ГБД ЮЛ
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetGBDULInfo))]
        public async Task<IActionResult> GetGBDULInfo([FromQuery][Required]string bin)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _GBDULLogic.GetGBDUL(bin);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// ЗАГС
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetZAGSInfo))]
        public async Task<IActionResult> GetZAGSInfo([FromQuery][Required]string iin)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _ZAGSLogic.GetZAGS(iin);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpGet(nameof(GetZAGSInfoByIIN))]
        public async Task<IActionResult> GetZAGSInfoByIIN([FromQuery][Required]string iin)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _ZAGSLogic.GetZAGSByIin(iin);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// ГЦВП
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetGCVPInfo))]
        public async Task<IActionResult> GetGCVPInfo([FromQuery][Required]string iin)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _GCVPLogic.GetGCVP(iin);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// АСП
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetASPInfo))]
        public async Task<IActionResult> GetASPInfo([FromQuery][Required]string iin)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _ASPLogic.GetASP(iin);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// ГКБ
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetGKBCreditReportTypes))]
        public async Task<IActionResult> GetGKBCreditReportTypes([FromQuery][Required]string iin)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _GKBLogic.GetCreditReportTypes(iin);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// ГКБ
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetGKBXInfo))]
        public async Task<IActionResult> GetGKBXInfo([FromQuery][Required]string iin, [FromQuery][Required]string reportName)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _GKBLogic.GetGKBX(iin, reportName);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpGet(nameof(GetGKBNew))]
        public async Task<IActionResult> GetGKBNew(string iin, string reportName, bool isFL = true)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _GKBLogic.GetGKBNew(iin, reportName, isFL);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}
