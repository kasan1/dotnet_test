using Agro.Shared.Logic.CQRS.Common.DTOs;
using System;

namespace Agro.Shared.Logic.CQRS.ClientActivities.DTOs
{
    public class FloraActivityDto : BaseIdDto
    {
        /// <summary>
        /// вид культуры
        /// </summary>
        public Guid CultureId { get; set; }
        public string Culture { get; set; }

        /// <summary>
        /// планируемая площадь
        /// </summary>
        public decimal PlannedSquare { get; set; }

        /// <summary>
        /// цена реализации
        /// </summary>
        public decimal PriceRealization { get; set; }

        /// <summary>
        /// норма посева
        /// </summary>
        public decimal? SeedingRate { get; set; }

        /// <summary>
        /// затраты
        /// </summary>
        public decimal? Cost { get; set; }

        public decimal? ProductivityCurrentYear { get; set; }
        public decimal? ProductivityLastYear { get; set; }
        public decimal? ProductivityBeforeLastYear { get; set; }

    }
}
