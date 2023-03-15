using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Agro.Shared.Data.Context.Dictionary;

namespace Agro.Shared.Data.Repos.Dictionary.Accessories
{
    public interface IAccessoriesRepo:IBaseRepo<DicAccessories>
    {
        Task<List<DicAccessories>> GetAccessoriesByTechTypeId(string id);
    }
}
