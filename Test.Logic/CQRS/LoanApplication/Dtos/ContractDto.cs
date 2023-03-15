using System;
using System.Collections.Generic;

namespace Agro.Okaps.Logic.CQRS.LoanApplication.Dtos
{
    public class ContractDto:ContractBaseDto
    {
        public CalculatorDto Calculator { get; set; }
        public TechnicDto Technic { get; set; }
        public List<AccessoryDto> Accessories { get; set; } = new List<AccessoryDto>();
        public List<ProvisionDto> Provisions { get; set; } = new List<ProvisionDto>();        
    }
        
}
