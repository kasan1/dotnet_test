using System;
using System.Collections.Generic;

namespace Agro.Shared.Logic.Models.Calculator
{
    public class CalculatorInput
    {
        public Guid TechTypeId { get; set; }
        public Guid TechSubTypeId { get; set; }
        public Guid CountryId { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public List<SubjectAccessories> Accessories { get; set; } = new List<SubjectAccessories>();
    }

    public class SubjectAccessories
    {
        public decimal Price { get; set; }
        public short Count { get; set; }
    }

    public class RateInput
    {
        public string DicCountryCode { get; set; }
        public string DicTechTypeCode { get; set; }
        public string DicTechSubTypeCode { get; set; }
    }
}
