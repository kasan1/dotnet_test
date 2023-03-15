using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Context.Dictionary;

namespace Agro.Shared.Data.Context.LoanApplications.Activity
{
    public class LivestockActivity : BaseActivity
    {
        /// <summary>
        /// вид скота
        /// </summary>
        public Guid LivestockTypeId { get; set; }
        [ForeignKey(nameof(LivestockTypeId))]
        public DicLivestockType DicLivestockType { get; set; }

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
