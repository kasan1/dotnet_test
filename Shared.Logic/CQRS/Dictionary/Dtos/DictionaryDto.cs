using System;

namespace Agro.Shared.Logic.CQRS.Dictionary.DTOs
{
    public class DictionaryDto
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
    }
}
