using System;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs.ClientDetails
{
    public class BankAccountDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// код банка
        /// </summary>
        public string BIC { get; set; }

        /// <summary>
        /// Номер счета
        /// </summary>
        public string Number { get; set; }
    }

}
