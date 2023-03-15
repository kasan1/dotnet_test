using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Context;

namespace Agro.Shared.Data.Repos
{
    public class FloraCulture : BaseRepo<Context.FloraCulture>, IFloraCulture
    {
        public FloraCulture(DataContext context) : base(context)
        {
        }

    }
}
