using System.Collections.Generic;

namespace Agro.Okaps.Logic.CQRS.Dictionary.Dtos
{
    public class ListResponse
    {
        public IEnumerable<DictionaryDto> List { get; set; }
        public long Count { get; set; }
    }
}
