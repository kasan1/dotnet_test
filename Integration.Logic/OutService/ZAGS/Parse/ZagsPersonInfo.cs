using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Integration.Logic.OutService.ZAGS.Parse
{
    public class ZagsPersonInfo
    {
        /// <summary>
        /// Женат или был женат
        /// </summary>
        public bool? IsMarriage { get; set; } = null;

        /// <summary>
        /// Разведен
        /// </summary>
        public bool? IsDivorce { get; set; } = null;

        /// <summary>
        /// Кол-во членов семьи
        /// </summary>
        public int FamilyCount { get; set; } = 0;

        /// <summary>
        /// Дети младше 18 лет
        /// </summary>
        public int ChildrenUnder18YearsOld { get; set; } = 0;
    }
}
