using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Agro.Shared.Data.Repos;

namespace Agro.Shared.Data.Repos.Dictionary.TechItems
{
    public interface IDicTechItemsRepo : IBaseRepo<DicTechItems>
    {
        Task<List<DicTechProduct>> GetDicTechItems(Guid id);
        Task<List<DicTechProduct>> GetProductsByAccessoryId(Guid id);
        Task<List<DicTechModel>> GetModelByProductId(Guid id, string provider);
        Task<List<DicTechModel>> GetCountryByModelId(string name);
    }
}
