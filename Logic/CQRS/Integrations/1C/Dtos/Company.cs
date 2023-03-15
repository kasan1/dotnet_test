using Agro.Shared.Logic.CQRS.Common.DTOs;
using System;
using System.Collections.Generic;

namespace Agro.Bpm.Logic.CQRS.Integrations._1C.DTOs
{
    public class Company
    {
        /// <summary>
        ///  Идентификатор записи
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// ИИН/БИН
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Признак резидентства
        /// </summary>
        public bool IsResident { get; set; }

        /// <summary>
        /// Признак ФЛ
        /// </summary>
        public bool IsPhysical { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// ОПФ
        /// </summary>
        public Guid? FormOfLegal { get; set; }

        /// <summary>
        /// связь с обществом
        /// </summary>
        public Guid RelationWithCompany { get; set; }

        /// <summary>
        /// тип связи с обществом
        /// </summary>
        public Guid TypeOfRelationWithCompany { get; set; }
        /// <summary>
        /// налоговый режим
        /// </summary>
        public string TaxTreatment { get; set; }

        /// <summary>
        /// субъект предпринимательства
        /// </summary>
        public string SubjectOfEntrepreneur { get; set; }
	
        public DocumentDto RegistrationDocument { get; set; }
        public Address Address { get; set; }
        public List<ListItem> Oked { get; set; } = new List<ListItem>();

        public Person Head { get; set; }
        public List<Person> Contacts { get; set; } = new List<Person>();

        public List<BankAccountDto> BankAccounts { get; set; } = new List<BankAccountDto>();
    }
}
