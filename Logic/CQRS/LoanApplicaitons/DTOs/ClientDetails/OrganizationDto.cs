using System;
using System.Collections.Generic;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs.ClientDetails
{
    public class OrganizationDto : BaseDto
    {
        public string OrganizationType { get; set; }
        public string OwnershipForm { get; set; }
        public IEnumerable<string> OKED { get; set; }
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
    }
}
