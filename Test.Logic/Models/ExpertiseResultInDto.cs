using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class ExpertiseResultInDto
    {
        public Guid UserId { get; set; }
        public Guid  ApplicationId { get; set; }
        public string ExpertiseCode { get; set; }
        public string DecisionsCode { get; set; }
        public string Comment { get; set; }
    }
}
