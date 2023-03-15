using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.CommercialОbjectName
{
    public class DicCommercialObjectNameRepo : BaseRepo<DicCommercialObjectName>, IDicCommercialObjectNameRepo
    {
        public DicCommercialObjectNameRepo(DataContext context) : base(context)
        {
        }
    }
}
