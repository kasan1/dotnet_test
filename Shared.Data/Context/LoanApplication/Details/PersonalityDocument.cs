using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class PersonalityDocument : BaseEntity
    {
        public Guid PersonalityId { get; set; }
        [ForeignKey(nameof(PersonalityId))]
        public Personality Personality { get; set; }

        public Guid DocumentId { get; set; }
        [ForeignKey(nameof(DocumentId))]
        public Document Document { get; set; }
    }
}
