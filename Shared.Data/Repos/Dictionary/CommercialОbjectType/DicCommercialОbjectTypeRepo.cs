using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.CommercialОbjectType
{
    public class DicCommercialObjectTypeRepo : BaseRepo<DicCommercialObjectType>, IDicCommercialObjectTypeRepo
    {
        public DicCommercialObjectTypeRepo(DataContext context) : base(context)
        {
        }
    }
}
