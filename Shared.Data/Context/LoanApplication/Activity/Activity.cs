using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.LoanApplications.Activity
{
    public class Activity : BaseEntity
    {
        public Guid LoanApplicationId { get; set; }
        [ForeignKey(nameof(LoanApplicationId))]
        public LoanApplication LoanApplication { get; set; }

        public virtual ICollection<FloraActivity> FloraActivities { get; set; }
        public virtual ICollection<LivestockActivity> LivestockActivities { get; set; }
        public virtual ICollection<LandActivity> LandActivities { get; set; }
        public virtual ICollection<TechnicActivity> TechnicActivities { get; set; }
    }
}
