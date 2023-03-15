using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class OrganizationOKED : BaseEntity
    {
        public Guid OrganizationId { get; set; }
        [ForeignKey(nameof(OrganizationId))]
        public Organization Organization { get; set; }

        public Guid OkedId { get; set; }
        [ForeignKey(nameof(OkedId))]
        public DicOKED DicOKED { get; set; }
    }
}
