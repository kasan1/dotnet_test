using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Branch
{
    public class BranchRepo : BaseRepo<Context.Branch>, IBranchRepo
    {
        public BranchRepo(DataContext context) : base(context)
        {
        }
    }
}
