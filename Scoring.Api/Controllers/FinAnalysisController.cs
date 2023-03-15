using Agro.Scoring.Logic.FinAnalysis;
using Agro.Scoring.Logic.Scoring.GKB;
using Agro.Shared.Api.Controllers;
using Agro.Shared.Data.Repos.FinAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Scoring.Api.Controllers
{
    [AllowAnonymous]
    public class FinAnalysisController : BaseController
    {
        private readonly IFinAnalysisLogic _logic;
        private readonly IFinAnalysisQueueTaskRepo _taskRepo;
        private readonly IGKBOverdueCheckLogic _overdueCheckLogic;
        public FinAnalysisController(
            IFinAnalysisLogic logic, 
            IFinAnalysisQueueTaskRepo taskRepo,
            IGKBOverdueCheckLogic overdueCheckLogic)
        {
            _logic = logic;
            _taskRepo = taskRepo;
            _overdueCheckLogic = overdueCheckLogic;
        }

        /// <summary>
        /// Финансовый анализ
        /// </summary>
        /// <returns></returns>
        [HttpPost("{applicationId}")]
        public async Task<IActionResult> Start(Guid applicationId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                await _logic.Start(applicationId);

                return NoContent();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        [HttpGet(nameof(Start))]
        public async Task<IActionResult> Start([FromQuery][Required]string applicationId)
        {
            try
            {
                await _taskRepo.Add(new Shared.Data.Context.FinAnalysisQueueTask { 
                    ApplicationId = Guid.Parse(applicationId) ,
                    Status = Shared.Data.Primitives.QueueTaskType.New
                });
                return NoContent();
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}
