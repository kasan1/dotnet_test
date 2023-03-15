using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Entities.ClientExtraDetails
{
    public class License : BaseEntity
    {
        public Guid ExtraDetailsId { get; set; }
        [ForeignKey(nameof(ExtraDetailsId))]
        public ExtraDetails ExtraDetails { get; set; }

        public Guid DocumentId { get; set; }
        [ForeignKey(nameof(DocumentId))]
        public Document Document { get; set; }

        public string Essence { get; set; }
    }
}
