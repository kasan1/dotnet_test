using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.LoanApplicationHistory
{
    public class LoanApplicationHistoryRepo:BaseRepo<Context.LoanApplicationHistory>,ILoanApplicationHistory
    {
        public LoanApplicationHistoryRepo(DataContext context) : base(context)
        {
        }
    }
}
