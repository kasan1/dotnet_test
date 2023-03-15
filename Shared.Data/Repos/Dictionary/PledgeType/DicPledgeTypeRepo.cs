using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.PledgeType
{
    public class DicPledgeTypeRepo : BaseRepo<DicPledgeType>, IDicPledgeTypeRepo
    {

        public DicPledgeTypeRepo(DataContext context) : base(context)
        {
        }
    }
}
