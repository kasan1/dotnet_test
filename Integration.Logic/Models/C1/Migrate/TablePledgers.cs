using System;
using Newtonsoft.Json;

namespace Agro.Integration.Logic.Models.C1.Migrate
{
    public class TablePledgers
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string PledgerPartnerType { get; set; }
        public string IsIp { get; set; }
        public string PledgerIin { get; set; }
        public string PledgerName { get; set; }
        public string PledgerResidencyCountry { get; set; }
        public string PledgerCommunicationTypeSBVU { get; set; }
        public string PledgerGender { get; set; }
        public string PledgerBirthday { get; set; }
        public string PledgerDocumentType { get; set; }
        public string PledgerDocumentNumber { get; set; }
        public string PledgerDocumentIssueDate { get; set; }
        public string PledgerDocumentIssuedBy { get; set; }
        public string PledgerPrimaryLanguage { get; set; }
        public string PledgerMotherland { get; set; }
        public string PledgerFactRegion { get; set; }
        public string PledgerFactIndex { get; set; }
        public string PledgerFactDistrict { get; set; }
        public string PledgerFactStreet { get; set; }
        public string PledgerFactStreetKz { get; set; }
        public string PledgerFactHouseNumber { get; set; }
        public string PledgerFactFlatNumber { get; set; }
        public string PledgerJurIndex { get; set; }
        public string PledgerJurDistrict { get; set; }
        public string PledgerJurStreet { get; set; }
        public string PledgerJurStreetKz { get; set; }
        public string PledgerJurHouseNumber { get; set; }
        public string PledgerJurFlatNumber { get; set; }
        public string PledgerJurRegion { get; set; }
        public string PledgerMobilePhone { get; set; }
        public string PledgerPhone { get; set; }
        public string PledgerRodPadej { get; set; }
        public string PledgerRodPadejKz { get; set; }
        public string PledgerKBE { get; set; }
    }
}