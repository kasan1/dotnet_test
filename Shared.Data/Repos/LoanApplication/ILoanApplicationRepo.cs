using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.LoanApplication
{
    public interface ILoanApplicationRepo : IBaseRepo<Context.LoanApplication>
    {
        string GetRegnumberSeq(string branchCode);
        Context.LoanApplication GetLoanApplicationWithFullInfo(Guid branchCode);
    }
}
