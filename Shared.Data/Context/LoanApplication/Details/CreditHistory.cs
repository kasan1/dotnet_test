using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class CreditHistory : BaseEntity
    {
        public Guid PersonalityId { get; set; }
        [ForeignKey(nameof(PersonalityId))]
        public Personality Personality { get; set; }

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
