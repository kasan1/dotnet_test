using System;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs.ClientDetails
{
    public class DebtDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// код банка
        /// </summary>
        public string BIC { get; set; }

        public decimal Debt { get; set; }
    }

}
