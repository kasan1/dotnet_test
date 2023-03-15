using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.AgriculturalMachineryPurpose
{
    public class DicAgriculturalMachineryPurposeRepo : BaseRepo<DicAgriculturalMachineryPurpose>, IDicAgriculturalMachineryPurposeRepo
    {
        public DicAgriculturalMachineryPurposeRepo(DataContext context) : base(context)
        {
        }
    }
}
