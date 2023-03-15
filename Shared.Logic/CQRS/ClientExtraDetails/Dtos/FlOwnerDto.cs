using System;
using Agro.Shared.Logic.CQRS.Common.DTOs;
using Agro.Shared.Logic.CQRS.ClientDetails.DTOs;

namespace Agro.Shared.Logic.CQRS.ClientExtraDetails.DTOs
{
    public class FlOwnerDto : BaseIdDto
    {
        public Guid? PersonId { get; set; }
        public string FullName { get; set; }
        public DocumentDto IdentificationDocument { get; set; }
        public AddressDto Address { get; set; }
    }
}
