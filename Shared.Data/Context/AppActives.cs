using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    [Obsolete]
    public class AppActives:BaseEntity
    {
        public Guid? LoanApplicationId { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public virtual List<LandActivities> LandActivities { get; set; }
        public virtual List<BioActivity> BioActivities { get; set; }
        public virtual List<FloraActivities> FloraActivities { get; set; }
        public virtual List<TechActivity> TechActivities { get; set; }

        public AppActives()
        {
            FloraActivities = new List<FloraActivities>();
            BioActivities = new List<BioActivity>();
            TechActivities = new List<TechActivity>();
            LandActivities = new List<LandActivities>();
        }
    }
}
