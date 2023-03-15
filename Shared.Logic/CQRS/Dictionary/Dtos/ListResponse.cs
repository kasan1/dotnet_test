using System.Collections.Generic;

namespace Agro.Shared.Logic.CQRS.Dictionary.DTOs
{
    public class ListResponse
    {
        public IEnumerable<DictionaryDto> List { get; set; }
        public long Count { get; set; }
    }
}
