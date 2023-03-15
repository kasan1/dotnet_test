using Agro.Shared.Logic.CQRS.Common.DTOs;
using System.Collections.Generic;

namespace Agro.Shared.Logic.CQRS.ClientExtraDetails.DTOs
{
    public class UlOwnerDto : BaseIdDto
    {
        public decimal Rate { get; set; }
        public string FullName { get; set; }
        public IEnumerable<BankAccountDto> BankAccounts { get; set; } = new List<BankAccountDto>();
    }
}
