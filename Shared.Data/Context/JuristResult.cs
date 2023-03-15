using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Context
{
    public class JuristResult : BaseEntity
    {

        [ForeignKey(nameof(ApplicationId))]
        public LoanApplication LoanApplication { get; set; }
        public Guid ApplicationId { get; set; }


        [ForeignKey(nameof(WarningClassificationId))]
        public DicWarningClassification WarningClassification { get; set; }
        public Guid WarningClassificationId { get; set; }

        public bool IsFixed { get; set; }
        public string FixReason { get; set; }
        public bool IsConfirm { get; set; }
    }
}
