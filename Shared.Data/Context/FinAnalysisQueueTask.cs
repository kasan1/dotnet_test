using Agro.Shared.Data.Entities.Base;
using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Agro.Shared.Data.Context
{
    /// <summary>
    /// Очередь для Фин анализа
    /// </summary>
    public class FinAnalysisQueueTask : BaseEntity
    {
        /// <summary>
        /// Заявление
        /// </summary>
        public Guid ApplicationId { get; set; }
        [ForeignKey(nameof(ApplicationId))]
        public LoanApplication LoanApplication { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public QueueTaskType Status { get; set; }
        /// <summary>
        /// Ошибка в случае возникновения
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
