using System;
using System.ComponentModel.DataAnnotations.Schema;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class SelectedTechnicBase: BaseEntity
    {
        public Guid ContractId { get; set; }
        [ForeignKey(nameof(ContractId))]
        public Contract Contract { get; set; }

        public Guid TechModelId { get; set; }
        [ForeignKey(nameof(TechModelId))]
        public DicTechModel DicTechModel { get; set; }

        public Guid CountryId { get; set; }
        [ForeignKey(nameof(CountryId))]
        public DicCountry DicCountry { get; set; }

        public Guid ProviderId { get; set; }
        [ForeignKey(nameof(ProviderId))]
        public DicProvider DicProvider { get; set; }

        public decimal Price { get; set; }

        public short Count { get; set; }
    }

    public class SelectedTechnic : SelectedTechnicBase
    {
    }
}
