using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Agro.Shared.Data.Context
{
    public class ExpertiseResult: BaseEntity
    {

        /// <summary>
        /// Идентификатор заявки
        /// </summary>
        [ForeignKey(nameof(ApplicationId))]
        public LoanApplication LoanApplication { get; set; }
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }
        public Guid? UserId { get; set; }

        /// <summary>
        /// Идентификатор статуса
        /// </summary>
        [ForeignKey(nameof(ExpertiseId))]
        public DicLoanHistoryStatus DicLoanHistoryStatus { get; set; }
        public Guid ExpertiseId { get; set; }
        
        /// <summary>
        ///  Результат решения
        /// </summary>
        [ForeignKey(nameof(DecisionId))]
        public DicDecision DicDecision { get; set; }
        public Guid? DecisionId { get; set; }

        /// <summary>
        /// Комментарии
        /// </summary>
        public string Comment { get; set; }

    }
}
