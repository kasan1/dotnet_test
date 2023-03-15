using Agro.Shared.Logic.CQRS.Common.DTOs;
using System;
using System.Collections.Generic;

namespace Agro.Shared.Logic.CQRS.ClientDetails.DTOs
{
    public class OrganizationDto : PersonalityBaseDto
    {
        public Guid? OwnershipFormId { get; set; }

        /// <summary>
        /// Налоговый режим
        /// </summary>
        public Guid? TaxTreatmentId { get; set; }

        /// <summary>
        /// Организационно-правовая форма
        /// </summary>
        public Guid? LegalFormId { get; set; }

        /// <summary>
        /// Субъект Предпринимательства
        /// </summary>
        public Guid? SubjectOfEntrepreneurId { get; set; }

        public IEnumerable<Guid> OKED { get; set; }
        public DocumentDto RegistrationDocument { get; set; }
        public string Parent { get; set; }
        public IEnumerable<BankAccountDto> BankAccounts { get; set; } = new List<BankAccountDto>();

        /// <summary>
        /// доля в уставном капитале
        /// </summary>
        public decimal? ShareInCapital { get; set; }

        /// <summary>
        /// задолженности
        /// </summary>
        public IEnumerable<DebtDto> Debts { get; set; } = new List<DebtDto>();

        public bool IsAffiliated { get; set; }

        /// <summary>
        /// Аффилированные компании
        /// </summary>
        public IEnumerable<OrganizationDto> AffiliatedOrganizations { get; set; } = new List<OrganizationDto>();

        public IEnumerable<CreditHistoryDto> CreditHistory { get; set; } = new List<CreditHistoryDto>();

        public DateTime? RegisteredDate { get; set; }

        public PersonDto Head { get; set; }
    }

    public class OwnerOrganizationDto
    {
        public Guid? Id { get; set; }
        public Guid? PersonalityId { get; set; }
        public string FullName { get; set; }
        public IEnumerable<BankAccountDto> BankAccounts { get; set; } = new List<BankAccountDto>();
    }
}
