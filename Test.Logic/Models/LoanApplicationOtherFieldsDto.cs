using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class LoanApplicationOtherFieldsDto
    {
        public Guid ApplicationId { get; set; }
        public string ProjectDescription { get; set; }
        public string PurposeDescription { get; set; }
        public Guid? ActivityTypeId { get; set; }
        public bool WithFood { get; set; }
        public Guid? LoanPurposeId { get; set; }
    }
}

