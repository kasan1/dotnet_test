using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.OutService
{
    public class OutServiceRepo : BaseRepo<Context.OutService>, IOutServiceRepo
    {
        public OutServiceRepo(DataContext context) : base(context)
        {
        }
    }
}
