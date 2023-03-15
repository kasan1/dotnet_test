using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Repos.Dictionary.LoanProduct;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.Dictionary.LoanRepaymentType
{
    public class DicLoanRepaymentTypeRepo : BaseRepo<DicLoanRepaymentType>, IDicLoanRepaymentTypeRepo
    {
        public DicLoanRepaymentTypeRepo(DataContext context) : base(context)
        {
        }
    }
}
