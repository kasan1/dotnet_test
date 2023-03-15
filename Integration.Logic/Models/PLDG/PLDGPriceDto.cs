using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Integration.Logic.Models.PLDG
{
    public class PLDGPriceDto
    {
        /// <summary>
        /// Тип цены от ОСОН
        /// </summary>
        public PriceType PriceType { get; set; }

        /// <summary>
        /// Цена за квадрат от ОСОН, если PriceType=1
        /// </summary>
        public decimal SquarePrice { get; set; }

        /// <summary>
        /// Рыночная стоимость
        /// </summary>
        public decimal TotalSum { get; set; }
    }
}
