using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class JuristCommentInDto
    {
        public Guid? ApplicationId { get; set; }
        public string Text { get; set; }
        public string ClientCommentVnd { get; set; }
        public bool ClientResultVnd { get; set; }
        public string ClientCommentRk { get; set; }
        public bool ClientResultRk { get; set; }
        public Guid? ApplicationTaskId { get; set; }
        public ICollection<LegalCommentInDto> Chargees { get; set; } = new HashSet<LegalCommentInDto>();
        public ICollection<LegalCommentInDto> Pledges { get; set; } = new HashSet<LegalCommentInDto>();
    }

    public class JuristCommentOutDto : JuristCommentInDto
    {
    }
}
