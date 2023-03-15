using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Extensions;
using Agro.Shared.Data.Repos.Dictionary.LoanProduct;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Agro.Shared.Data.Repos.Dictionary.TechItems
{
    public class DicTechItemsRepo : BaseRepo<DicTechItems>, IDicTechItemsRepo
    {
        private readonly DataContext _context;
        public DicTechItemsRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DicTechProduct>> GetDicTechItems(Guid id)
        {
            var model = await _context.DicTechProducts
                .Include(s => s.DicTechModels)
                //.ThenInclude(s => s.DicCountry)
                .Where(s=>s.DicTechTypeId == id)
                .ToListAsync();

            foreach (var item in model)
            {
                foreach (var item1 in item.DicTechModels)
                {
                    //item1.DicProvider = await _context.DicProviders.FirstOrDefaultAsync(s => s.Id == item1.DicProviderId);
                }
            }

            return model;
        }

        public async Task<List<DicTechProduct>> GetProductsByAccessoryId(Guid id)
        {
            var model = await _context.DicTechProducts
                //.Include(s => s.DicTechModels)
                //.ThenInclude(s => s.DicCountry)
                .Where(s => s.DicAccessoriesId == id)
                .ToListAsync();

            //foreach (var item in model)
            //{
            //    foreach (var item1 in item.DicTechModels)
            //    {
            //        item1.DicProvider = await _context.DicProviders.FirstOrDefaultAsync(s => s.Id == item1.DicProviderId);
            //    }
            //}

            return model;
        }
        public async Task<List<DicTechModel>> GetModelByProductId(Guid id,string provider)
        {
            List<DicTechModel> model = null;
            if (!String.IsNullOrWhiteSpace(provider))
            {
                 model = await _context.DicTechModels
                     .Include(s => s.DicTechProduct)
                     //.Include(s=>s.DicCountry)
                     //.Include(s=>s.DicProvider)
                    .Where(s => s.DicTechProductId == id).Take(50)
                    .ToListAsync();
            }
            else
            {
                 model = await _context.DicTechModels
                    //.Include(s => s.DicTechModels)
                    //.ThenInclude(s => s.DicCountry)
                    .Where(s => s.DicTechProductId == id 
                                //&& (s.DicCountry.NameRu != "kz" && s.DicCountry.NameRu != "bs")
                                )
                    .ToListAsync();

            }
            //foreach (var item in model)
            //{
            //    foreach (var item1 in item.DicTechModels)
            //    {
            //        item1.DicProvider = await _context.DicProviders.FirstOrDefaultAsync(s => s.Id == item1.DicProviderId);
            //    }
            //}

            return model;
        }

        public async Task<List<DicTechModel>> GetCountryByModelId(string name)
        {
            var model = await _context.DicTechModels
                //.Include(s => s.DicTechModels)
                //.Include(s => s.DicCountry)
                .Where(s => s.NameRu == name)
                .ToListAsync();

            //foreach (var item in model)
            //{
            //    foreach (var item1 in item.DicTechModels)
            //    {
            //        item1.DicProvider = await _context.DicProviders.FirstOrDefaultAsync(s => s.Id == item1.DicProviderId);
            //    }
            //}

            return model;
        }
    }
}
