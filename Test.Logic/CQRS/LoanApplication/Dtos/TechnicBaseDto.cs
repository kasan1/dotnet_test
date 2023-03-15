using System;
namespace Agro.Okaps.Logic.CQRS.LoanApplication.Dtos
{
    public class TechnicBaseDto
    {
        public Guid? Id { get; set; }
        public Guid TechProductId { get; set; }
        public string TechProduct { get; set; }

        public Guid TechModelId { get; set; }
        public string TechModel { get; set; }
        public Guid CountryId { get; set; }
        public Guid ProviderId { get; set; }
        public string Provider { get; set; }
        public decimal Price { get; set; }
        public short Count { get; set; }
    }
}
