using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Agro.Shared.Logic.Models
{
    public class DocInformationsInDto
    {
        public ICollection<DocInformationInDto> Items { get; set; } = new HashSet<DocInformationInDto>();
    }

    public class DocInformationInDto
    {
        public Guid ApplicationId { get; set; }
        public string Code { get; set; }
        public bool IsOriginal { get; set; }
        public int PageCount { get; set; }

        [MaxLength(50)]
        public string PageInterval { get; set; }
    }
}