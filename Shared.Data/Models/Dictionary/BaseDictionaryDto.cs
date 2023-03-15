using System;
using System.ComponentModel.DataAnnotations;

namespace Agro.Shared.Data.Models.Dictionary
{
    public class BaseDictionaryDto
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }
        
        [Required]
        public string NameRu { get; set; }
        [Required]
        public string NameKk { get; set; }

        public Guid? ParentId { get; set; }
    }
}
