using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class Calculator : BaseEntity
    {
        public decimal Rate { get; set; }
        public decimal CoFinancing { get; set; }

        public decimal GetCoFinancingValue()
        {
            return Sum * CoFinancing / 100;
        }
        public int Period{ get; set; }  
        public decimal Sum { get; set; }  

        public Guid? ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public Contract Contract { get; set; }

    }
}
