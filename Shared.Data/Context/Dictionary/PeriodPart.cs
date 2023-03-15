using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class PeriodPart
    {
        public Guid Id { get; set; }
        public Guid? DicTechTypeId { get; set; }
        public DicTechType DicTechType { get; set; }
        public Guid? DicCountryId { get; set; }
        public DicCountry DicCountry { get; set; }
        public Guid? DicProviderId { get; set; }
        public DicProvider DicProvider { get; set; }
        public decimal Sum { get; set; }
        public int minDuration { get; set; }
        public int maxDuration { get; set; }

    }
}
