using System.Collections.Generic;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    /// <summary>
    /// Справочник: Страны
    /// </summary>
    public class DicCountry : BaseDictionary
    {
        public ICollection<DicCountryTechModel> DicCountryTechModels { get; set; }
        public ICollection<DicCountryProvider> DicCountryProviders { get; set; }
    }
}
