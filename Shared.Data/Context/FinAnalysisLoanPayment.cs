using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    /// <summary>
    /// Платежи по кредитам
    /// </summary>
    public class FinAnalysisLoanPayment : BaseEntity
    {
        public Guid FinAnalysisId { get; set; }
        [ForeignKey(nameof(FinAnalysisId))]
        public FinAnalysis FinAnalysis { get; set; }
        /// <summary>
        /// Платежи
        /// </summary>
        public double Payments { get; set; }
        /// <summary>
        /// Валюта
        /// </summary>
        public string Currency { get; set; }
        /// <summary>
        /// Фин орг
        /// </summary>
        public string FinInstitut { get; set; }
        /// <summary>
        /// Период
        /// </summary>
        public double PeriodPayments { get; set; }
        /// <summary>
        /// Период
        /// </summary>
        public string PeriodPaymentsName { get; set; }
    }
}
