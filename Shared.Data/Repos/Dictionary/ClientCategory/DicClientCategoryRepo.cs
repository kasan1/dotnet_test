using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.ClientCategory
{
    public class DicClientCategoryRepo : BaseRepo<DicClientCategory>, IDicClientCategoryRepo
    {
        public DicClientCategoryRepo(DataContext context) : base(context)
        {
        }
    }
}
