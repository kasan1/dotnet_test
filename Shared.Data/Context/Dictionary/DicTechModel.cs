using System;
using System.Collections.Generic;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicTechModel: BaseDictionary
    {
        public ICollection<DicCountryTechModel> DicCountryTechModels { get; set; }
        public ICollection<DicCountryProvider> DicCountryProviders { get; set; }
        public Guid DicTechProductId { get; set; }
        public DicTechProduct DicTechProduct { get; set; }
    }
}
