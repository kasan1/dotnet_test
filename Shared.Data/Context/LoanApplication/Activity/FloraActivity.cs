using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agro.Shared.Data.Context.LoanApplications.Activity
{
    public class FloraActivity : BaseActivity
    {
        /// <summary>
        /// вид культуры
        /// </summary>
        public Guid FloraCultureId { get; set; }
        [ForeignKey(nameof(FloraCultureId))]
        public FloraCulture FloraCulture { get; set; }

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


        public virtual ICollection<FloraProductivity> Productivities { get; set; }
    }
}
