using System.Collections.Generic;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicProvider : BaseDictionary
    {
        public ICollection<DicCountryProvider> DicCountryProviders { get; set; }
    }
}
