using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Repos.Dictionary.LoanProduct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.ClientLocationType
{
    public class DicClientLocationTypeRepo : BaseRepo<DicClientLocationType>, IDicClientLocationTypeRepo
    {
        public DicClientLocationTypeRepo(DataContext context) : base(context)
        {
        }
    }
}
