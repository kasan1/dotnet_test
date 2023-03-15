using System;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs.ClientDetails
{
    public class DocumentDto
    {
        public Guid? Id { get; set; }
        public string Number { get; set; }
        public string Issuer { get; set; }
        public DateTime DateIssue { get; set; }
    }
}
