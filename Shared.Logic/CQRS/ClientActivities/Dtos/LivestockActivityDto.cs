using Agro.Shared.Logic.CQRS.Common.DTOs;
using System;
namespace Agro.Shared.Logic.CQRS.ClientActivities.DTOs
{
    public class LivestockActivityDto : BaseIdDto
    {
        /// <summary>
        /// вид скота
        /// </summary>
        public Guid LivestockTypeId { get; set; }
        public string LivestockType { get; set; }
        public Guid? LivestockTypeParentId { get; set; }

        public int Count { get; set; }

        /// <summary>
        /// убойный вес
        /// </summary>
        public decimal SlaughterWeight { get; set; }

        /// <summary>
        /// живой вес
        /// </summary>
        public decimal LiveWeight { get; set; }

        /// <summary>
        /// цена в убойном вес
        /// </summary>
        public decimal SlaughterPrice { get; set; }

        /// <summary>
        /// цена в живом весе
        /// </summary>
        public decimal LivePrice { get; set; }
    }
}
