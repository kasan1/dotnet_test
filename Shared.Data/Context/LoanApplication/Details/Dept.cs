using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class Dept : BaseEntity
    {
        public Guid PersonalityId { get; set; }
        [ForeignKey(nameof(PersonalityId))]
        public Personality Personality { get; set; }

        public string BIC { get; set; }

        public decimal Value { get; set; }
    }
}
