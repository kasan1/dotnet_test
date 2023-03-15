using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.Country
{
    public class DicCountryRepo : BaseRepo<DicCountry>, IDicCountryRepo
    {
        public DicCountryRepo(DataContext context) : base(context)
        {
        }
    }
}
