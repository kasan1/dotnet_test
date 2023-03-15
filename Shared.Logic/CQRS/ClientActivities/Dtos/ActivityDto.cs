using Agro.Shared.Logic.CQRS.Common.DTOs;
using System.Collections.Generic;

namespace Agro.Shared.Logic.CQRS.ClientActivities.DTOs
{

    public class ActivityDto : BaseIdDto
    {
        public IEnumerable<LandActivityDto> LandActivities { get; set; }
        public IEnumerable<FloraActivityDto> FloraActivities { get; set; }
        public IEnumerable<LivestockActivityDto> LivestockActivities { get; set; }
        public IEnumerable<TechnicActivityDto> TechnicActivities { get; set; }
    }
}
