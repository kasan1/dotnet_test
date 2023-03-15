using System.Collections.Generic;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs
{
    public class LoanApplicationListDto
    {
        public List<LoanApplicationDto> List { get; set; } = new List<LoanApplicationDto> { };

        public long Count { get; set; }
    }
}
