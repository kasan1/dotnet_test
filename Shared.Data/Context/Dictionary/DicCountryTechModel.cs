using System;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class DicCountryTechModel : BaseEntity
    {
        public Guid DicCountryId { get; set; }
        public DicCountry DicCountry { get; set; }

        public Guid DicTechModelId { get; set; }
        public DicTechModel DicTechModel { get; set; }

        public decimal Rate { get; set; }
    }
}
