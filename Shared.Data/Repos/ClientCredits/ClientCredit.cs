using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Context;

namespace Agro.Shared.Data.Repos.ClientCredits
{
    public class ClientCredit:BaseRepo<Context.ClientCredits>
    {
        public ClientCredit(DataContext context) : base(context)
        {
        }
    }
}
