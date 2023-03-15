using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Primitives;

namespace Agro.Shared.Data.Context.LoanApplications
{
    public class DetailsPersonality : BaseEntity
    {
        public PersonalityTypeEnum PersonalityType { get; set; } = PersonalityTypeEnum.Default;

        public Guid DetailsId { get; set; }
        [ForeignKey(nameof(DetailsId))]
        public Details Details { get; set; }

        public Guid PersonalityId { get; set; }
        [ForeignKey(nameof(PersonalityId))]
        public Personality Personality { get; set; }
    }
}
