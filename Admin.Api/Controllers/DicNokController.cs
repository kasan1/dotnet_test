using Agro.Shared.Api.Controllers;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Models.Dictionary;
using Agro.Shared.Data.Models.Dictionary.Nok;
using Agro.Shared.Data.Repos.Dictionary.Nok;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agro.Admin.Api.Controllers
{
    public class DicNokController : BaseController
    {
        private readonly IDicNokRepo _repo;
        public DicNokController(IDicNokRepo repo)
        {
            _repo = repo;
        }

        [HttpGet(nameof(GetNok))]
        public async Task<IActionResult> GetNok([FromQuery][Required] Guid branchId)
        {
            try
            {
                var _ = await _repo.GetQueryable(x => !x.IsDeleted && x.BranchId == branchId)
                    .AsNoTracking()
                    .Select(x => new
                    {
                        x.Id,
                        x.NameRu,
                        x.NameKk,
                        x.CooperationAgreement
                    })
                    .ToListAsync();
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpPost(nameof(AddNok))]
        public async Task<IActionResult> AddNok([FromBody][Required] NokDto model)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _repo.Add(new DicNok
                {
                    BranchId = model.BranchId,
                    NameRu = model.NameRu,
                    NameKk = model.NameKk,
                    Rating = model.Rating,
                    CooperationAgreement = model.CooperationAgreement
                });
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }


        [HttpPut(nameof(UpdateNok))]
        public async Task<IActionResult> UpdateNok([FromBody][Required] NokDto model)
        {
            try
            {
                if (model.Id != default)
                {
                    var _nok = await _repo.GetQueryable(x => x.Id == model.Id).FirstOrDefaultAsync();
                    if(_nok != default)
                    {
                        _nok.NameRu = model.NameRu;
                        _nok.NameKk = model.NameKk;
                        _nok.Rating = model.Rating;
                        _nok.BranchId = model.BranchId;
                        _nok.CooperationAgreement = model.CooperationAgreement;
                        await _repo.Update(_nok);
                    }
                    
                }
                return NoContent();                
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }


        [HttpDelete(nameof(DeleteNok))]
        public async Task<IActionResult> DeleteNok([FromQuery][Required] Guid id)
        {
            try
            {
                var _ = await _repo.GetQueryable(x => x.Id == id).FirstOrDefaultAsync();
                if(_ != default)
                    await _repo.Delete(_);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}
