using System;
using System.Collections.Generic;

namespace Agro.Bpm.Logic.CQRS.Integrations._1C.DTOs
{
    public class Contract
    {
        /// <summary>
        /// Идентификатор Договора
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Идентификатор Заявки
        /// </summary>
        public Guid ApplicationId { get; set; }

        /// <summary>
        /// № договора
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Тип
        /// </summary>
        public Guid AgreementType { get; set; }

        /// <summary>
        /// Код валюты
        /// </summary>
        public string Currency { get; set; } = "KZT";

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        public Calculator Calculator { get; set; }

        public Technic Technic { get; set; }

        /// <summary>
        /// комплектующие
        /// </summary>
        public List<Technic> Accessories { get; set; } = new List<Technic>();
    }
}
