using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Context
{
    public class LoanApplication : BaseEntity
    {
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AppUser User { get; set; }

        /// <summary>
        /// Тип продукта 
        /// </summary>
        public Guid? LoanProductId { get; set; }

        [ForeignKey(nameof(LoanProductId))]
        public DicLoanProduct DicLoanProducts { get; set; }

        public Guid? DicLoanTypeId { get; set; }

        [ForeignKey(nameof(DicLoanTypeId))]
        public DicLoanType DicLoanType { get; set; }

        public Guid? BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }

        /// <summary>
        /// Номер заявки
        /// </summary>
        public string RegNumber { get; set; }

        /// <summary>
        /// Camunda processID
        /// </summary>
        public Guid? ProcessInstanceId { get; set; }

        /// <summary>
        /// Текущий статус
        /// </summary>        
        public ApplicationTypeEnum Status { get; set; }

        /// <summary>
        /// Идентификатор статуса
        /// </summary>
        [ForeignKey(nameof(StatusId))]
        public DicLoanHistoryStatus DicLoanHistoryStatus { get; set; }
        public Guid? StatusId { get; set; }

        ///// <summary>
        ///// Вид деятельности
        ///// </summary>        
        //public Guid? ActivityTypeId { get; set; }
        //[ForeignKey(nameof(ActivityTypeId))]
        //public DicActivityType DicActivityType { get; set; }


        /// <summary>
        /// Сегмент клиента
        /// </summary>        
        public Guid? ClientSegmentId { get; set; }
        [ForeignKey(nameof(ClientSegmentId))]
        public DicClientSegment DicClientSegment { get; set; }

        public string ProjectDescription { get; set; }
        //[DefaultValue(true)]
        //public bool WithFood { get; set; }

        public string CliLegalCommentVnd { get; set; }
        public bool CliLegalResultVnd { get; set; }
        public string CliLegalCommentRk { get; set; }
        public bool CliLegalResultRk { get; set; }

        /// <summary>
        ///комментарии юриста по заявке
        /// </summary>
        public string JuristComment { get; set; }

        /// <summary>
        /// комментарии залогодателя по заявке
        /// </summary>
        public string PledgeComment { get; set; }

        public string BankAccount { get; set; }
        
        public virtual List<LoanApplications.Details> ClientDetailsNew { get; set; }
        public virtual List<LoanApplications.Activity.Activity> Activities { get; set; }
        
        public virtual ICollection<LoanApplicationTask> LoanApplicationTasks { get; set; }
                
        public void SetRegNumber()
        {
            RegNumber = DateTime.Now.ToString("yyyyMMddHHmmssffff");
        }
    }
}
