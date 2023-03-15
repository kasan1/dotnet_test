using System;
using System.Collections.Generic;
using Agro.Shared.Logic.Models.Calculator;

namespace Agro.Okaps.Logic.CQRS.LoanApplication.Dtos
{
    public class ContractExtraDto : ContractBaseDto
    {
        public CalculatorDto Calculator { get; set; }
        public CalculatorResult CalculatorResult { get; set; }
        public TechnicExtraDto Technic { get; set; }
        public IEnumerable<AccessoryExtraDto> Accessories { get; set; }
        public bool HasProvisions { get; set; }
        public IEnumerable<ProvisionDto> Provisions { get; set; }
    }
}
