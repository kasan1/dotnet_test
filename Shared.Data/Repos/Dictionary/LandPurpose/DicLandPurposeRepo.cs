using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.LandPurpose
{
    public class DicLandPurposeRepo : BaseRepo<DicLandPurpose>, IDicLandPurposeRepo
    {
        public DicLandPurposeRepo(DataContext context) : base(context)
        {
        }
    }
}
