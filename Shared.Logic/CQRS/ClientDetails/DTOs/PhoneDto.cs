using System;

namespace Agro.Shared.Logic.CQRS.ClientDetails.DTOs
{
    public class PhoneDto
    {
        public Guid? Id { get; set; }
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
    }
}
