using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.LoanApplicationTask
{
    public class LoanApplicationTaskRepo: BaseRepo<Context.LoanApplicationTask>, ILoanApplicationTaskRepo
    {
        public LoanApplicationTaskRepo(DataContext context) : base(context)
        {
        }
    }
}
