using System;

namespace Agro.Shared.Logic.CQRS.Notifications.DTOs
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LoanApplicationId { get; set; }

        public bool IsRead { get; set; }
    }
}
