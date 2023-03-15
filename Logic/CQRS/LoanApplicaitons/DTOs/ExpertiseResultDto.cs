using System.Collections.Generic;
using Agro.Shared.Logic.CQRS.Files.DTOs;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs
{
    public class ExpertiseResultDto
    {
        public string RoleName { get; set; }
        public string Comment { get; set; }
        public List<FileDto> Files { get; set; }
    }
}
