using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Identity;

namespace Agro.Shared.Data.Context
{
    public class Comment : BaseEntity
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

        public string Text { get; set; }

        /// <summary>
        /// автор коммента
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }
        public Guid? UserId { get; set; }
    }
}
