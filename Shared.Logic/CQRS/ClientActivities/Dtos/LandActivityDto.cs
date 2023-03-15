using Agro.Shared.Logic.CQRS.Common.DTOs;
using System;
namespace Agro.Shared.Logic.CQRS.ClientActivities.DTOs
{
    public class LandActivityDto : BaseIdDto
    {
        /// <summary>
        /// вид земельного актива
        /// </summary>
        public Guid LandTypeId { get; set; }
        public string LandType { get; set; }
        public string LandTypeCode { get; set; }

        /// <summary>
        /// вид собственности
        /// </summary>
        public Guid OwnershipTypeId { get; set; }
        public string OwnershipType { get; set; }

        /// <summary>
        /// площадь
        /// </summary>
        public decimal Square { get; set; }
    }
}
