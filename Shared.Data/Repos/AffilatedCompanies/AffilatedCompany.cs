using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Context;

namespace Agro.Shared.Data.Repos.AffilatedCompanies
{
    public class AffilatedCompany:BaseRepo<Context.AffiliatedCompanies>
    {
        public AffilatedCompany(DataContext context) : base(context)
        {
        }
    }
}
