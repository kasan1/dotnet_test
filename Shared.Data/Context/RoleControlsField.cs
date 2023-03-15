using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    [Table(nameof(RoleControlsField) + "s")]
    public class RoleControlsField : BaseDictionary
    {
        [ForeignKey(nameof(RoleControlId))]
        public RoleControls RoleControls { get; set; }
        public Guid RoleControlId { get; set; }
    }
}
