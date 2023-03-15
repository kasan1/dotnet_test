using Agro.Shared.Logic.CQRS.Common.DTOs;

namespace Agro.Shared.Logic.CQRS.ClientExtraDetails.DTOs
{
    public class LicenseDto : BaseIdDto
    {
        public DocumentDto Document { get; set; }
        public string Essence { get; set; }
    }
}
