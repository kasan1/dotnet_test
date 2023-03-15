using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class LoanApplicationContracts : BaseEntity
    {
        [ForeignKey(nameof(LoanApplicationId))]
        public LoanApplication LoanApplication { get; set; }
        public Guid? LoanApplicationId { get; set; }
    }
}
