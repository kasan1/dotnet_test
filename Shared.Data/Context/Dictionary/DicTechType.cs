using System;
using System.Collections.Generic;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicTechType : BaseDictionary
    { 
        public Guid DicLoanProductId { get; set; }
        public DicLoanProduct DicLoanProduct { get; set; }
        public DicTechType Parent { get; set; }
        public Guid? ParentId { get; set; }
        public string TechTypeCode { get; set; }
        public ICollection<DicAccessories> DicAccessorieses { get; set; }
        public DicTechType()
        {
            DicAccessorieses = new List<DicAccessories>();
        }
    }
}