using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Agro.Shared.Api.Controllers;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Extensions;
using Agro.Shared.Data.Models.Dictionary;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.Dictionary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Agro.Admin.Api.Controllers
{
    [AllowAnonymous]
    public class DictionaryController : BaseController
    {
        private readonly IDictionaryLogic _logic;
        
        public DictionaryController(IDictionaryLogic logic)
        {
            _logic = logic;
        }

        [HttpGet("GetDictionaryList")]
        public ActionResult<Dictionary<int, string>> GetDictionaryList()
        {
            return Ok(EnumExtHelper.GetEnumDictionary<DictionaryType>());
        }

        [HttpGet("GetDictionaryItems/{dictionaryName}")]
        public async Task<IActionResult> GetDictionaryItems([Required] string dictionaryName)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                switch ((DictionaryType)Enum.Parse(typeof(DictionaryType), dictionaryName))
                {
                    case DictionaryType.DicClientLocationType:
                        return Ok(await _logic.DictionaryRepo<DicClientLocationType>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicClientSegment:
                        return Ok(await _logic.DictionaryRepo<DicClientSegment>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicClientType:
                        return Ok(await _logic.DictionaryRepo<DicClientType>()
                            .GetQueryable(null).AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicLoanProduct:
                        return Ok(await _logic.DictionaryRepo<DicLoanProduct>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicLoanRepaymentType:
                        return Ok(await _logic.DictionaryRepo<DicLoanRepaymentType>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicAgriculturalMachineryPurpose:
                        return Ok(await _logic.DictionaryRepo<DicAgriculturalMachineryPurpose>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicEquipmentPurpose:
                        return Ok(await _logic.DictionaryRepo<DicEquipmentPurpose>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicLandPurpose:
                        return Ok(await _logic.DictionaryRepo<DicLandPurpose>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicCommercialObjectName:
                        return Ok(await _logic.DictionaryRepo<DicCommercialObjectName>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicCommercialObjectPurpose:
                        return Ok(await _logic.DictionaryRepo<DicCommercialObjectPurpose>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicCommercialObjectType:
                        return Ok(await _logic.DictionaryRepo<DicCommercialObjectType>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicStockType:
                        return Ok(await _logic.DictionaryRepo<DicStockType>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicTransportBodyType:
                        return Ok(await _logic.DictionaryRepo<DicTransportBodyType>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicTransportFuel:
                        return Ok(await _logic.DictionaryRepo<DicTransportFuel>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicTransportSteeringWheel:
                        return Ok(await _logic.DictionaryRepo<DicTransportSteeringWheel>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicTransportType:
                        return Ok(await _logic.DictionaryRepo<DicTransportType>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicWallMaterial:
                        return Ok(await _logic.DictionaryRepo<DicWallMaterial>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicGuaranteeType:
                        return Ok(await _logic.DictionaryRepo<DicGuaranteeType>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicFileType:
                        return Ok(await _logic.DictionaryRepo<DicFileType>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicDocumentType:
                        return Ok(await _logic.DictionaryRepo<DicDocumentType>()
                            .GetQueryable().AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicDocClassification:
                        return Ok(await _logic.DictionaryRepo<DicDocClassification>()
                            .GetQueryable(null).AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicNok:
                        return Ok(await _logic.DictionaryRepo<DicNok>()
                            .GetQueryable(null).AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicFirstDocType:
                        return Ok(await _logic.DictionaryRepo<DicFirstDocType>()
                            .GetQueryable(null).AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicPledgeType:
                        return Ok(await _logic.DictionaryRepo<DicPledgeType>()
                            .GetQueryable(null).AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                    case DictionaryType.DicClientCategory:
                        return Ok(await _logic.DictionaryRepo<DicClientCategory>()
                            .GetQueryable(null).AsNoTracking().Select(x => x.ToDto()).ToListAsync());
                        
                    default:
                        throw new Exception("not handled DictionaryType");
                }

            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpPost("Add/{dictionaryName}")]
        public async Task<IActionResult> Add([FromBody] BaseDictionaryDto model, [Required] string dictionaryName)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                switch ((DictionaryType)Enum.Parse(typeof(DictionaryType), dictionaryName))
                {
                    case DictionaryType.DicClientLocationType:
                        return Ok(await _logic.Add(new DicClientLocationType(model.ToEntity())));
                    case DictionaryType.DicClientSegment:
                        return Ok(await _logic.Add(new DicClientSegment(model.ToEntity())));
                    case DictionaryType.DicClientType:
                        return Ok(await _logic.Add(new DicClientType(model.ToEntity())));
                    case DictionaryType.DicLoanProduct:
                        return Ok(await _logic.Add(new DicLoanProduct(model.ToEntity())));
                    case DictionaryType.DicLoanRepaymentType:
                        return Ok(await _logic.Add(new DicLoanRepaymentType(model.ToEntity())));
                    default:
                        throw new Exception("not handled DictionaryType");
                }
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

        [HttpPost("Update/{dictionaryName}")]
        public async Task<IActionResult> Update([FromBody] BaseDictionaryDto model, [Required] string dictionaryName)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest(ModelState);
                switch ((DictionaryType)Enum.Parse(typeof(DictionaryType), dictionaryName))
                {
                    case DictionaryType.DicClientLocationType:
                        await _logic.Update(new DicClientLocationType(model.ToEntity()));
                        break;
                    case DictionaryType.DicClientSegment:
                        await _logic.Update(new DicClientSegment(model.ToEntity()));
                        break;
                    case DictionaryType.DicClientType:
                        await _logic.Update(new DicClientType(model.ToEntity()));
                        break;
                    case DictionaryType.DicLoanProduct:
                        await _logic.Update(new DicLoanProduct(model.ToEntity()));
                        break;
                    case DictionaryType.DicLoanRepaymentType:
                        await _logic.Update(new DicLoanRepaymentType(model.ToEntity()));
                        break;
                    default:
                        throw new Exception("not handled DictionaryType");
                }
                return new JsonResult("Success!");
            }
            catch (Exception e)
            {
                return ExceptionResult(e);
            }
        }

    }
}
