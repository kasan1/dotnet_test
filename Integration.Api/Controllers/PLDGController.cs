using Agro.Integration.Logic.Models.PLDG;
using Agro.Integration.Logic.OutService.PLDG;
using Agro.Shared.Api.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agro.Integration.Api.Controllers
{
    [AllowAnonymous]
    public class PLDGController : BaseController
    {
        private readonly IPLDGLogic _logic;
        public PLDGController(IPLDGLogic logic)
        {
            _logic = logic;
        }

        /// <summary>
        /// Список улиц
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetGeonim))]
        public async Task<IActionResult> GetGeonim([FromQuery][Required]long id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _logic.GetGeonim(id);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Получение регионов 1 = получить корневой элемент
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAts))]
        public async Task<IActionResult> GetAts([FromQuery][Required]long id)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _logic.GetAts(id);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Получение типов регионов
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAtsTypes))]
        public async Task<IActionResult> GetAtsTypes()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _logic.GetAtsTypes();
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Проверка корректности
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(IsGeonimExist))]
        public async Task<IActionResult> IsGeonimExist([FromQuery][Required]long atsId, [FromQuery][Required]long geonimId)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _logic.IsGeonimExist(atsId, geonimId);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Стоимость недвижимости
        /// </summary>
        /// <param name="pledge"></param>
        /// <returns></returns>
        [HttpPost(nameof(GetPropertyPrice))]
        public async Task<IActionResult> GetPropertyPrice([FromBody][Required] PledgeDto pledge)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _logic.GetPropertyPrice(pledge);
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Виды материалов
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetWallMaterials))]
        public async Task<IActionResult> GetWallMaterials()
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                var _ = await _logic.GetWallMaterials();
                return Ok(_);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        /// <summary>
        /// Тип недвижимости
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetRealtyType))]
        public IActionResult GetRealtyType()
        {
            try
            {
                var enumVals = new List<object>();
                foreach (var i in Enum.GetValues(typeof(RealtyTypeEnum)))
                {
                    enumVals.Add(new
                    {
                        key = i.GetHashCode(),
                        value = i.ToString()
                    });
                }
                return Ok(enumVals);
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }
    }
}
