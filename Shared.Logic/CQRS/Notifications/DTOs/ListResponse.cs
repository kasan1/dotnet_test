using System.Collections.Generic;

namespace Agro.Shared.Logic.CQRS.Notifications.DTOs
{
    public class ListResponse
    {
        public IEnumerable<NotificationDto> List { get; set; }
        public long Count { get; set; }
    }
}
