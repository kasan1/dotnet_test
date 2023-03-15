using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Context;

namespace Agro.Shared.Data.Repos.LandActivy
{
    public class BioActivy : BaseRepo<Context.BioActivity>, IBioActivy
    {
        public BioActivy(DataContext context) : base(context)
        {
        }
    }
}
