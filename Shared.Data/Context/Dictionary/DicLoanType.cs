using System.Collections.Generic;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Primitives;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicLoanType : BaseDictionaryDerived
    {
        public LoanTypeEnum Value { get; set; } = LoanTypeEnum.Default;
        public ICollection<DicLoanProduct> LoanProducts { get; set; }
    }
}