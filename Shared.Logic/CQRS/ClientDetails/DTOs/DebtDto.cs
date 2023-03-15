using System;

namespace Agro.Shared.Logic.CQRS.ClientDetails.DTOs
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
