using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.LoanApplications.Activity
{
    public class FloraProductivity : BaseEntity
    {
        public Guid FloraActivityId { get; set; }
        [ForeignKey(nameof(FloraActivityId))]
        public FloraActivity FloraActivity { get; set; }
        public int Year { get; set; }
        public decimal? Value { get; set; }
    }
}
