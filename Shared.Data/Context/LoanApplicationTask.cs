using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Data.Primitives;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Context
{
    public class LoanApplicationTask : BaseEntity
    {
        /// <summary>
        /// Идентификатор заявки
        /// </summary>
        [ForeignKey(nameof(ApplicationId))]
        public LoanApplication LoanApplication { get; set; }
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// Идентификатор статуса
        /// </summary>
        [ForeignKey(nameof(StatusId))]
        public DicLoanHistoryStatus DicLoanHistoryStatus { get; set; }
        public Guid StatusId { get; set; }

        /// <summary>
        /// Идентификатор роли
        /// </summary>
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
        public Guid? RoleId { get; set; }

        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }
        public Guid? UserId { get; set; }

        /// <summary>
        ///  Дата назначения пользователю
        /// </summary>
        public DateTime? AppointmentDate { get; set; }

        /// <summary>
        ///  Дата планового завершения
        /// </summary>
        public DateTime? PlanEndDate { get; set; }

        /// <summary>
        ///  Дата фактического завершения
        /// </summary>
        public DateTime? FactEndDate { get; set; }

        /// <summary>
        ///  Результат решения
        /// </summary>
        [ForeignKey(nameof(DecisionId))]
        public DicDecision DicDecision { get; set; }
        public Guid? DecisionId { get; set; }

        /// <summary>
        /// Комментарии (только для задач с заключением)
        /// </summary>
        public string Comment { get; set; }


        /// <summary>
        /// Идентификатор статуса задачи
        /// </summary>
        [ForeignKey(nameof(TaskStatusId))]
        public DicTaskStatus DicTaskStatus { get; set; }
        public Guid? TaskStatusId { get; set; }

        public ApplicationTypeEnum Status { get; set; }

    }
}
