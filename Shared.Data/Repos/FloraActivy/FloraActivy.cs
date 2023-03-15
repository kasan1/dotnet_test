using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Context;

namespace Agro.Shared.Data.Repos.LandActivy
{
    public class FloraActivy : BaseRepo<Context.FloraActivities>, IfloraActivy
    {
        public FloraActivy(DataContext context) : base(context)
        {
        }
    }
}
