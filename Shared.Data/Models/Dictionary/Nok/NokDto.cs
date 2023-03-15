using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Models.Dictionary.Nok
{
    public class NokDto : BaseDictionaryDto
    {
        public Guid BranchId { get; set; }
        public bool CooperationAgreement { get; set; }
        public int Rating { get; set; }
    }
}
