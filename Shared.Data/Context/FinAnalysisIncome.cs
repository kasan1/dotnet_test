using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    /// <summary>
    /// Доходы заявителя
    /// </summary>
    public class FinAnalysisIncome : BaseEntity
    {
        /// <summary>
        /// Финанализ
        /// </summary>
        public Guid FinAnalysisId { get; set; }
        [ForeignKey(nameof(FinAnalysisId))]
        public FinAnalysis FinAnalysis { get; set; }

        /// <summary>
        /// Наименование организации
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        /// Дата
        /// </summary>
        public DateTime? Date { get; set; }
    }
}
