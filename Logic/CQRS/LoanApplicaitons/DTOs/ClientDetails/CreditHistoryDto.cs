using System;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs.ClientDetails
{
    public class CreditHistoryDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// наименование кредитной организации
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// дата выдачи
        /// </summary>
        public DateTime DateIssue { get; set; }

        /// <summary>
        /// срок погашения
        /// </summary>
        public int Period { get; set; }

        public decimal Sum { get; set; }

        /// <summary>
        /// остаток не погашенной задолженности
        /// </summary>
        public decimal Balance { get; set; }
    }
}
