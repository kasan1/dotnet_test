using System;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs.ClientDetails
{
    public class AddressDto
    {
        public Guid? Id { get; set; }
        public string Fact { get; set; }
        public string Register { get; set; }
    }
}
