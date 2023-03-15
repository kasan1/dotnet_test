using System;

namespace Agro.Okaps.Logic.CQRS.Dictionary.Dtos
{
    public class DictionaryDto
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}
