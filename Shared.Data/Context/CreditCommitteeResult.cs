using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Identity;

namespace Agro.Shared.Data.Context
{
    public class CreditCommitteeResult : BaseEntity
    {
        public Guid ApplicationId { get; set; }

        [ForeignKey(nameof(ApplicationId))]
        public LoanApplication LoanApplication { get; set; }

        public Guid UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }

        public bool Accept { get; set; }
    }
}
