using System;

namespace Agro.Bpm.Logic.CQRS.Integrations._1C.DTOs
{
    public class Technic
    {
        public Guid ContractId { get; set; }
        public string  Type { get; set; }
        public string Model { get; set; }

        /// <summary>
        /// страна производства
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// поставщик
        /// </summary>
        public string Provider { get; set; }

        public short Count { get; set; }


        /// <summary>
        /// цена за единицу 
        /// </summary>
        public decimal Price { get; set; }
        
    }
}
