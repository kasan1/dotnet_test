using System;

namespace Agro.Shared.Logic.CQRS.Common.DTOs
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
