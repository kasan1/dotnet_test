using System;

namespace Agro.Shared.Logic.CQRS.ClientDetails.DTOs
{
    public class AddressDto
    {
        public Guid? Id { get; set; }
        public string Fact { get; set; }
        public string Register { get; set; }
    }
}
