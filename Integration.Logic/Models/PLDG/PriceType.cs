using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Integration.Logic.Models.PLDG
{
    /// <summary>
    /// Тип цены от ОСОН
    /// </summary>
    public enum PriceType
    {
        /// <summary>
        /// Сумма исходя из стоимости за кв.м.
        /// </summary>
        MultiplySquare = 1,

        /// <summary>
        /// Общая сумма
        /// </summary>
        All = 2,

        /// <summary>
        /// Не вернул цену, в соответствие с бизнес логикой необходимо сохранить залог и установить возможность продолжить.
        /// Не смотря на то, что продолжить можно только с ценой залога более 1.3млн
        /// </summary>
        NoResult = 3,
    }
}
