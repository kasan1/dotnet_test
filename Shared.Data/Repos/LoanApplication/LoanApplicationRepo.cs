using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Agro.Shared.Data.Repos.LoanApplication
{
    public class LoanApplicationRepo : BaseRepo<Context.LoanApplication>, ILoanApplicationRepo
    {
        private readonly DataContext _context;
        public LoanApplicationRepo(DataContext context) : base(context)
        {
            _context = context;
        }
        public string GetRegnumberSeq(string branchCode)
        {
            var connection = ContextBase.Database.GetDbConnection();
            connection.Open();
            using (var cmd = connection.CreateCommand())
            {
                cmd.CommandText = "SELECT NEXT VALUE FOR dbo.seqRegnumber" + branchCode + ";";
                var obj = cmd.ExecuteScalar();
                return obj.ToString();
            }
        }

        public Context.LoanApplication GetLoanApplicationWithFullInfo(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
