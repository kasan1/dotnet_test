using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class NotificationInDto
    {
        public Guid ApplicationId { get; set; }
        public string SubjectKz { get; set; }
        public string SubjectRu { get; set; }
        public string BodyKz { get; set; }
        public string BodyRu { get; set; }
        public NotificationStatusEnum  StatusCode { get; set; }
        public string Type { get; set; }
        public string TaskCode { get; set; }
        public bool IsRead { get; set; }
        public string Error{ get; set; }
    }
}
