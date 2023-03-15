using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Models.Dictionary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agro.Shared.Data.Repos.Dictionary.TechType
{
    public interface IDicTechTypeRepo : IBaseRepo<DicTechType>
    {
        Task<List<BaseDictionaryDto>> GetTechTypesByProductCode(string code);
        Task<List<BaseDictionaryDto>> GetProductsByTypeId(Guid Id);
        Task<List<BaseDictionaryDto>> GetModelsByProductId(Guid Id);
        Task<List<BaseDictionaryDto>> GetManufacturersByModelId(Guid Id);
        Task<List<BaseDictionaryDto>> GetSuppliersByModelId(Guid Id);

    }
}
