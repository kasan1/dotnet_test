using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class CreditCommitteeDecisionOutDto
    {
        public Guid UserId { get; set; }
        public Guid ApplicationId { get; set; }
        public string FullName { get; set; }
        public bool Accept { get; set; }
    }
}
