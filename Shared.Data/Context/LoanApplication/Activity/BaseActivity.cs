using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.LoanApplications.Activity
{
    public class BaseActivity : BaseEntity
    {
        public Guid ActivityId { get; set; }
        [ForeignKey(nameof(ActivityId))]
        public Activity Activity { get; set; }
    }
}
