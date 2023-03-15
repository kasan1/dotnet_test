using System;

namespace Agro.Okaps.Logic.CQRS.LoanApplication.Dtos
{
    /// <summary>
    /// Обеспечение займа
    /// </summary>
    public class ProvisionDto
    {
        public Guid? Id { get; set; }

        /// <summary>
        /// Вид обеспечения
        /// </summary>
        public Guid? TypeId { get; set; }
        public string Type { get; set; }

        public Guid? DescriptionId { get; set; }
        public string Description { get; set; }
        public decimal? Sum { get; set; }
    }
}
