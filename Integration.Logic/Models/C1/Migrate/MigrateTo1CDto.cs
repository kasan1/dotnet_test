using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Integration.Logic.Models.C1.Migrate
{
    public class MigrateTo1CDto
    {
        public string BpmNumber { get; set; }
        public string KKDecisionNumber { get; set; }
        public string AuthorizedOrgan { get; set; }
        public string Beggar { get; set; }
        public string ManyChildren { get; set; }
        public string PartnerType { get; set; }
        public string IPForm { get; set; }
        public string Iin { get; set; }
        public string Name { get; set; }
        public string EmployedCount { get; set; }
        public string FirmName { get; set; }
        public string OPF { get; set; }
        public string ResidencyCountry { get; set; }
        public string KBE { get; set; }
        public string Industry { get; set; }
        public string DecisionsFileId { get; set; }
        public string CommunicationTypeSBVU { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentIssueDate { get; set; }
        public string DocumentIssuedBy { get; set; }
        public string PrimaryLanguage { get; set; }
        public string Motherland { get; set; }
        public string FactRegion { get; set; }
        public string FactIndex { get; set; }
        public string FactDistrict { get; set; }
        public string FactStreet { get; set; }
        public string FactStreetKz { get; set; }
        public string FactHouseNumber { get; set; }
        public string FactFlatNumber { get; set; }
        public string JurRegion { get; set; }
        public string JurIndex { get; set; }
        public string JurDistrict { get; set; }
        public string JurStreet { get; set; }
        public string JurStreetKz { get; set; }
        public string JurHouseNumber { get; set; }
        public string JurFlatNumber { get; set; }
        public string MobilePhone { get; set; }
        public string Phone { get; set; }
        public string RodPadej { get; set; }
        public string RodPadejKz { get; set; }
        public string StateRegistrationCertificateNumber { get; set; }
        public string StateRegistrationCertificateSeries { get; set; }
        public string StateRegistrationCertificateDate { get; set; }
        public string Bank { get; set; }
        public string MainBankAccount { get; set; }
        public string NDSCertificateSeries { get; set; }
        public string NDSCertificateNumber { get; set; }
        public string NDSCertificateDate { get; set; }
        public string Organization { get; set; }
        public string LendingProgram { get; set; }
        public string FinancingSource { get; set; }
        public string Sum { get; set; }
        public string DurationMonths { get; set; }
        public string GracePeriodRepaymentOfMainDebt { get; set; }
        public string GracePeriodPaymentsRewards { get; set; }
        public string FrequencyRepaymentPrincipalDebt { get; set; }
        public string RedemptionFrequency { get; set; }
        public string PenaltyCalculationMethod { get; set; }
        public string PenaltySizeForIntendedUse { get; set; }
        public string DevelopmentTerm { get; set; }
        public string DevelopmentTermUnit { get; set; }
        public string ManagerIin { get; set; }
        public string DevelopmentForm { get; set; }
        public string BorrowerCategory { get; set; }
        public string CertificateType { get; set; }
        public DateTime CertificateReceiptDate { get; set; }
        public virtual List<TableBorrowerDocument> TableBorrowerDocuments { get; set; }
        public virtual List<TableLoanSecurity> TableLoanSecurity { get; set; }
        public virtual List<TableIntendedUse> TableIntendedUse { get; set; }
        public virtual List<TableProperty> TableProperties { get; set; }
        public virtual List<TableSpecialConditions> TableSpecialConditions { get; set; }
        public virtual List<TableTitleDocument> TableTitleDocuments { get; set; }
        public virtual List<TableBailProperty> TableBailProperties { get; set; }
        public virtual List<TablePledgers> TablePledgers { get; set; }
        public virtual List<TableLiterals> TableLiterals { get; set; }
    }
}
