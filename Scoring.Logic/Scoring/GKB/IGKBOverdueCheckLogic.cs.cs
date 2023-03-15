using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Agro.Shared.Data.Context.PolicyRules;

namespace Agro.Scoring.Logic.Scoring.GKB
{
    public interface IGKBOverdueCheckLogic
    {
        Task<List<MonthlyPay>> CallMonthlyPayByFinInstitut(Guid id);
    }
}
