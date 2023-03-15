using System;
using System.Collections.Generic;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    /// <summary>
    /// Справочник продуктов кредитования 
    /// </summary>
    public class DicLoanProduct : BaseDictionaryDerived
    {
        /// <summary>
        /// Тип продукта 
        /// </summary>
        public Guid? DicLoanTypeId { get; set; }

        public DicLoanType DicLoanType { get; set; }
        public  ICollection<DicTechType> TechTypes { get; set; }
        public  ICollection<LoanApplication> LoanApplications { get; set; }
        public DicLoanProduct()
        {
            TechTypes = new HashSet<DicTechType>();
            LoanApplications = new HashSet<LoanApplication>();
        }

        public DicLoanProduct(BaseDictionary parent) : base(parent)
        {
        }
    }
}
