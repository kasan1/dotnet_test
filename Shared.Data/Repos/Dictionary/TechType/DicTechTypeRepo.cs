using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Agro.Shared.Data.Models.Dictionary;
using System;

namespace Agro.Shared.Data.Repos.Dictionary.TechType
{
    public class DicTechTypeRepo : BaseRepo<DicTechType>, IDicTechTypeRepo
    {   private readonly DataContext _context;
        public DicTechTypeRepo(DataContext context) : base(context)
        {            _context = context;

        }
        public async Task<List<BaseDictionaryDto>> GetTechTypesByProductCode(string code)
        {
            return await _context.DicTechTypes.Where(x => x.DicLoanProduct.Code == code)
                .Select(x => new BaseDictionaryDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    NameRu = x.NameRu,
                    NameKk = x.NameKk,
                    ParentId = x.ParentId
                })
                .ToListAsync();
        }

        public async Task<List<BaseDictionaryDto>> GetProductsByTypeId(Guid Id)
        {
            return await _context.DicTechProducts.Where(x => x.DicTechTypeId == Id)
                .Select(x => new BaseDictionaryDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    NameRu = x.NameRu,
                    NameKk = x.NameKk
                })
                .ToListAsync();
        }

        public async Task<List<BaseDictionaryDto>> GetModelsByProductId(Guid Id)
        {
            return await _context.DicTechModels.Where(x => x.DicTechProductId == Id)
                .Select(x => new BaseDictionaryDto
                {
                    Id = x.Id,
                    Code = x.Code,
                    NameRu = x.NameRu,
                    NameKk = x.NameKk
                })
                .ToListAsync();
        }

        public async Task<List<BaseDictionaryDto>> GetManufacturersByModelId(Guid Id)
        {
            // TODO: Fix to take manufactures
            //return await _context.DicTechModels.Where(x => x.Id == Id)
            //    .Select(x => new BaseDictionaryDto
            //    {
            //        Id = x.DicCountry.Id,
            //        Code = x.DicCountry.Code,
            //        NameRu = x.DicCountry.NameRu,
            //        NameKk = x.DicCountry.NameKk
            //    })
            //    .ToListAsync();
            return null;
        }

        public async Task<List<BaseDictionaryDto>> GetSuppliersByModelId(Guid Id)
        {
            // TODO: Fix to take supplier
            //return await _context.DicTechModels.Where(x => x.Id == Id)
            //    .Select(x => new BaseDictionaryDto
            //    {
            //        Id = x.DicProvider.Id,
            //        Code = x.DicProvider.Code,
            //        NameRu = x.DicProvider.NameRu,
            //        NameKk = x.DicProvider.NameKk
            //    })
            //    .ToListAsync();
            return null;
        }
    }
}
