using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.Nok
{
    public class DicNokRepo : BaseRepo<DicNok>, IDicNokRepo
    {
        public DicNokRepo(DataContext context) : base(context)
        {
        }
    }
}
