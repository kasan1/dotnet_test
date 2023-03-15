using System;

namespace Agro.Okaps.Logic.CQRS.LoanApplication.Dtos
{
    public class ContractBaseDto
    {
        public Guid? Id { get; set; }
        public Guid? LoanApplicationId { get; set; }
    }
}
