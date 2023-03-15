using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class CreditCommitteeResultInNok
    {
        public Guid ApplicationId { get; set; }
        public Guid ApplicationTaskId { get; set; }
        public bool Accept { get; set; }
    }
}
