using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class NotificationEventInDto
    {
        public string  TaskCode { get; set; }
        public Guid LoanApplicationId { get; set; }
        public string CommentRu { get; set; }
        public string CommentKz { get; set; }
        public string CommentRu2 { get; set; }
        public string CommentKz2 { get; set; }
        public string Error { get; set; }
        public NotificationStatusEnum StatusCode { get; set; }
    }
}
