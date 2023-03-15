using System;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs.ClientDetails
{
    public class PhoneDto
    {
        public Guid? Id { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
    }
}
