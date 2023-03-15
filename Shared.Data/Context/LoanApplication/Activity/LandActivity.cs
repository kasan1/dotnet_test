using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Context.Dictionary;

namespace Agro.Shared.Data.Context.LoanApplications.Activity
{
    public class LandActivity : BaseActivity
    {
        /// <summary>
        /// вид земельного актива
        /// </summary>
        public Guid LandTypeId { get; set; }
        [ForeignKey(nameof(LandTypeId))]
        public DicLandType DicLandType { get; set; }

        /// <summary>
        /// вид собственности
        /// </summary>
        public Guid OwnershipTypeId { get; set; }
        [ForeignKey(nameof(OwnershipTypeId))]
        public DicOwnershipType DicOwnershipType { get; set; }

        /// <summary>
        /// площадь
        /// </summary>
        public decimal Square { get; set; }
    }
}
