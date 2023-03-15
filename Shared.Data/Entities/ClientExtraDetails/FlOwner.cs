using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Entities.ClientExtraDetails
{
    public class FlOwner : BaseEntity
    {
        public Guid ExtraDetailsId { get; set; }
        [ForeignKey(nameof(ExtraDetailsId))]
        public ExtraDetails ExtraDetails { get; set; }

        public Guid? PersonId { get; set; }
        [ForeignKey(nameof(PersonId))]
        public Person Person { get; set; }
    }
}
