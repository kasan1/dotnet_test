using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Repos.Dictionary.LoanProduct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.ClientSegment
{
    public class DicClientSegmentRepo : BaseRepo<DicClientSegment>, IDicClientSegmentRepo
    {
        public DicClientSegmentRepo(DataContext context) : base(context)
        {
        }
    }
}
