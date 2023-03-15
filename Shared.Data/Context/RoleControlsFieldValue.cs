using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class RoleControlsFieldValue : BaseEntity
    {
        /// <summary>
        /// Идентификатор заявки
        /// </summary>
        [ForeignKey(nameof(ApplicationId))]
        public LoanApplication LoanApplication { get; set; }
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// пункт 
        /// </summary>
        [ForeignKey(nameof(RoleControlsFieldId))]
        public RoleControlsField RoleControlsField { get; set; }
        public Guid RoleControlsFieldId { get; set; }

        public bool Value { get; set; }
    }
}
