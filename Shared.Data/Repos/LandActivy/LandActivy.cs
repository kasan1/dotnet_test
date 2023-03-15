using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Context;

namespace Agro.Shared.Data.Repos.LandActivy
{
    public class LandActivy:BaseRepo<Context.LandActivities>,ILandActivy
    {
        public LandActivy(DataContext context) : base(context)
        {
        }
    }
}
