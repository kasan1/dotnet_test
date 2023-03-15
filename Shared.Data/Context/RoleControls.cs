using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    [Table(nameof(RoleControls))]
    public class RoleControls : BaseDictionary
    {
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
        public Guid RoleId { get; set; }
        public DicLoanHistoryStatus LoanHistoryStatus { get; set; }
        public Guid LoanHistoryStatusId { get; set; }
    }
}
