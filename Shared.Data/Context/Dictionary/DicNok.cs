using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    /// <summary>
    /// Список НОК
    /// </summary>
    public class DicNok : BaseDictionary
    {
        /// <summary>
        /// Рейтинг
        /// </summary>
        public int Rating { get; set; }

        /// <summary>
        /// Оргструктура
        /// </summary>
        public Guid? BranchId { get; set; }
        [ForeignKey(nameof(BranchId))]
        public Branch Branch { get; set; }

        /// <summary>
        /// Соглашение о сотрудничестве
        /// </summary>
        public bool CooperationAgreement { get; set; } = false;
    }
}
