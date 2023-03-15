using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Entities.ClientExtraDetails
{
    public class UlOwner : BaseEntity
    {
        public Guid ExtraDetailsId { get; set; }
        [ForeignKey(nameof(ExtraDetailsId))]
        public ExtraDetails ExtraDetails { get; set; }
        public decimal Rate { get; set; }
        public Guid? OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }
    }
}
