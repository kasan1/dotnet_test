using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    /// <summary>
    /// Справочник типов погашения займа 
    /// </summary>
    public class DicLoanRepaymentType : BaseDictionaryDerived
    {
        public DicLoanRepaymentType()
        {
        }

        public DicLoanRepaymentType(BaseDictionary parent) : base(parent)
        {
        }
    }
}
