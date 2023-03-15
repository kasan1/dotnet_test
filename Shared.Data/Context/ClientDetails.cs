using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    [Obsolete]
    public class ClientDetails : BaseEntity
    {
        public string OrganizationName { get; set; }
        public string JuridicalAddress { get; set; }
        public string FacticalAddress { get; set; }
        public string phoneNumber { get; set; } 
        public string Faks { get; set; }
        public string Email { get; set; }
        public string OwnershipTypeForJuristical { get; set; }
        public string MainActivityType { get; set; }
        public string BINForJuridical { get; set; }
        public string IINForIp { get; set; }
        public string NumberRegisterEvidence { get; set; }
        public string RegisterEvidenceDate { get; set; }
        public string MentorHolding { get; set; }
        public string LeaderFIO { get; set; }
        public string LeaderWorkNumber { get; set; }
        public string LeaderPhoneNumber { get; set; }
        public string LeaderHomeNumber { get; set; }
        public string LeaderBornDate { get; set; }
        public string LeaderBornPlace { get; set; }
        public string PassportNumber { get; set; }
        public string PassportCreateDate { get; set; }
        public string PassportIssuerName { get; set; }
        public string LeaderFaktAddress { get; set; }
        public string LeaderRegistrAddress { get; set; }
        public string Obrazovanie { get; set; }
        public string StazhRaboty { get; set; }
        public string StazhSelhoz { get; set; }
        public string SemeinoePolozhenie { get; set; }
        public string SuprugName { get; set; }
        public string BuhgalterFIO { get; set; }
        public string BuhgalterPhoneNumber { get; set; }
        public string BuhgalterWorkNumber { get; set; }
        public string BuhgalterHomeNumber { get; set; }
        public string BuhgalterBornDate { get; set; }
        public string BuhgalterBornPlace { get; set; }
        public string BuhgalterPassportNumber { get; set; }
        public string BuhgalterPassportCreateDate { get; set; }
        public string BuhgalterPassportIssuerName { get; set; }
        public string BuhgalterFaktAddress { get; set; }
        public string BuhgalterRegisterAddress { get; set; }

        public string BeneficiaryIdentifier { get; set; }
        public bool BeneficiaryIsResident { get; set; }
        public string BeneficiaryAddress { get; set; }
        public string BeneficiaryPassportNumber { get; set; }
        public string BeneficiaryPassportCreateDate { get; set; }
        public string BeneficiaryPassportIssuerName { get; set; }

        public string BankAccountIIN { get; set; }
        public string BankAccountBIK { get; set; }
        public string ContactLico { get; set; }
        public string ContactLicoBIK { get; set; }
        public Guid? LoanApplicationId { get; set; }
        public LoanApplication LoanApplication { get; set; }
        public virtual List<ClientCredits> ClientCreditses { get; set; }
        public virtual List<AffiliatedCompanies> AffiliatedCompanieses { get; set; }

        public ClientDetails()
        {
            AffiliatedCompanieses = new List<AffiliatedCompanies>();
            ClientCreditses = new List<ClientCredits>();
        }
    }
}
