using System.Collections.Generic;
using Agro.Shared.Logic.CQRS.Dictionary.DTOs;

namespace Agro.Okaps.Logic.CQRS.LoanApplication.Dtos
{
    public class AccessoryExtraDto : TechnicBaseDto
    {
        public IEnumerable<DictionaryDto> TechProducts { get; set; }
        public IEnumerable<DictionaryDto> TechModels { get; set; }

        public IEnumerable<DictionaryDto> Countries { get; set; }
        public IEnumerable<DictionaryDto> Providers { get; set; }
    }
}
