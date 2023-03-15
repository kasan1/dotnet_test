using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class BankAccount: BaseEntity
    {
        /// <summary>
        /// код банка
        /// </summary>
        public string BIC { get; set; }

        /// <summary>
        /// Номер счета
        /// </summary>
        public string Number { get; set; }

        public Guid PersonalityId { get; set; }
        [ForeignKey(nameof(PersonalityId))]
        public Personality Personality { get; set; }

        public string Get() => $"{BIC} {Number}";
    }
}
