using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class LegalCommentInDto
    {
        public Guid? Id { get; set; }
        public string Description { get; set; }
        public string LegalCommentVnd { get; set; }
        public bool LegalResultVnd { get; set; }
        public string LegalCommentRk { get; set; }
        public bool LegalResultRk { get; set; }
        public decimal? ExpertiseSum { get; set; }
    }
}
