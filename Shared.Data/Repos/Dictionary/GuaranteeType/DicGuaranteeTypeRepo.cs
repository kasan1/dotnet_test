using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.GuaranteeType
{
    public class DicGuaranteeTypeRepo : BaseRepo<DicGuaranteeType>, IDicGuaranteeTypeRepo
    {
        public DicGuaranteeTypeRepo(DataContext context) : base(context)
        {
        }
    }
}
