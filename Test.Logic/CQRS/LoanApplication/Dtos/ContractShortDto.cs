using System;

namespace Agro.Okaps.Logic.CQRS.LoanApplication.Dtos
{

    public class ContractShortDto: ContractBaseDto
    {
        public string Number { get; set; }
        /// <summary>
        /// Дата договора
        /// </summary>
        public DateTime CreatedDate { get; set; }
        public CalculatorDto Calculator { get; set; }
        public string Status { get; set; }

        /// <summary>
        /// Остаток основного долга
        /// </summary>
        public decimal PrincipalDebtBalance { get; set; }

        /// <summary>
        /// Предмет лизинга
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Ссылка на файл графика платежей
        /// </summary>
        public string ScheduleUrl { get; set; }
    }
}
