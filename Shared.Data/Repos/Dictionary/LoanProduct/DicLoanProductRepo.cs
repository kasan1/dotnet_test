using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Extensions;
using Agro.Shared.Data.Repos.Dictionary.LoanProduct;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Shared.Data.Repos.Dictionary.LoanProduct
{
    public class DicLoanProductRepo : BaseRepo<DicLoanProduct>, IDicLoanProductRepo
    {
        public DicLoanProductRepo(DataContext context) : base(context)
        {
        }
    }
}
