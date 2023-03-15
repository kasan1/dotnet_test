using Agro.Shared.Data.Primitives;
using System;
using System.ComponentModel.DataAnnotations;


namespace Agro.Shared.Logic.Models
{
    public class LoanApplicationInDto
    {
        public Guid ApplicationId { get; set; }

        [Required]
        public string ProductCode { get; set; }

        public bool NeedComplianceChecking { get; set; }
        public int CountOfCommitteeMembers { get; set; } = 5;

        public LoanTypeEnum LoanType { get; set; }

    }
}
