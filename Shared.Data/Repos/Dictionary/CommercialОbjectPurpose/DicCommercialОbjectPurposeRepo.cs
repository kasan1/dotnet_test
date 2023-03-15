using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.CommercialОbjectPurpose
{
    public class DicCommercialObjectPurposeRepo : BaseRepo<DicCommercialObjectPurpose>, IDicCommercialObjectPurposeRepo
    {
        public DicCommercialObjectPurposeRepo(DataContext context) : base(context)
        {
        }
    }
}
