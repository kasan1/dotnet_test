using System.Collections.Generic;
using Agro.Shared.Logic.CQRS.Common.DTOs;

namespace Agro.Shared.Logic.CQRS.ClientExtraDetails.DTOs
{
    public class ExtraDetailsDto : BaseIdDto
    {
        public bool? IsReadOnly { get; set; }
        public IEnumerable<UlOwnerDto> UlOwners { get; set; }
        public IEnumerable<FlOwnerDto> FlOwners { get; set; }
        public IEnumerable<LicenseDto> Licenses { get; set; }
        public DocumentDto VatCertificate { get; set; }
    }
}
