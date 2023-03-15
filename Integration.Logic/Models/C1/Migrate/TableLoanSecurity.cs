using System;
namespace Agro.Integration.Logic.Models.C1.Migrate
{
    public class TableLoanSecurity
    {
        public string Pledger { get; set; }
        public string AssessedValue { get; set; }
        public string CollateralValue { get; set; }
        public string ASONValue { get; set; }
        public string Liquidity { get; set; }
        public string BailType { get; set; }
        public string FactRegion { get; set; }
        public string FactIndex { get; set; }
        public string FactDistrict { get; set; }
        public string FactStreet { get; set; }
        public string FactStreetKz { get; set; }
        public string FactHouseNumber { get; set; }
        public string FactFlatNumber { get; set; }
        public string UnitLoanSecurity { get; set; }
        public string Inspection { get; set; }
    }
}