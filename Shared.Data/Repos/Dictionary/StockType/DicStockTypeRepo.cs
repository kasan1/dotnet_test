using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.StockType
{
    public class DicStockTypeRepo : BaseRepo<DicStockType>, IDicStockTypeRepo
    {
        public DicStockTypeRepo(DataContext context) : base(context)
        {
        }
    }
}
