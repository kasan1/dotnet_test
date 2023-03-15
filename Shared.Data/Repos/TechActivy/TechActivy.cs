using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Context;

namespace Agro.Shared.Data.Repos.LandActivy
{
    public class TechActivy : BaseRepo<Context.TechActivity>, ItechActivy
    {
        public TechActivy(DataContext context) : base(context)
        {
        }
    }
}
