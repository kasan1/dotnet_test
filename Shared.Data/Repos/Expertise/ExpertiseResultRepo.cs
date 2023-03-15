using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Expertise
{
    public class ExpertiseResultRepo : BaseRepo<Context.ExpertiseResult>, IExpertiseResultRepo
    {
        public ExpertiseResultRepo(DataContext context) : base(context)
        {
        }
    }
}

