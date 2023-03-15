using Agro.Shared.Logic.CQRS.Common.DTOs;
using System;

namespace Agro.Shared.Logic.CQRS.ClientDetails.DTOs
{
    public class PersonalityBaseDto
    {
        public Guid? Id { get; set; }
        public Guid? PersonalityId { get; set; }
        public string Identifier { get; set; }
        public string FullName { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public PhoneDto Phone { get; set; }
        public AddressDto Address { get; set; }
        public DocumentDto IdentificationDocument { get; set; }
        public WorkExperienceDto WorkExperience { get; set; }
        public Guid? RegionId { get; set; }
    }
}
