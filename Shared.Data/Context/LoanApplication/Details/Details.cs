using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.LoanApplications
{
    public class Details : BaseEntity
    {
        public bool HasBeneficiary { get; set; }

        public Guid LoanApplicationId { get; set; }
        [ForeignKey(nameof(LoanApplicationId))]
        public LoanApplication LoanApplication { get; set; }

        public virtual ICollection<DetailsPersonality> DetailsPersonalities { get; set; }
    }
}
