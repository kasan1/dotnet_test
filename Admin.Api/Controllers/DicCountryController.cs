using Agro.Shared.Api.Controllers;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Models.Dictionary;
using Agro.Shared.Data.Repos.Dictionary.Country;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agro.Admin.Api.Controllers
{
    /// <summary>
    /// Справочник стран
    /// </summary>
    public class DicCountryController : BaseController
    {
        private readonly IDicCountryRepo _repo;
        public DicCountryController(IDicCountryRepo repo)
        {
            _repo = repo;
        }

        /// <summary>
        /// Получение списка
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var _ = await _repo.GetQueryable(x => !x.IsDeleted)
                    .AsNoTracking()
                    .Select(x => new BaseDictionaryDto { 
                        Id = x.Id,
                        Code = x.Code,
                        NameRu = x.NameRu,
                        NameKk = x.NameKk
                    })
                    .ToListAsync();
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}
