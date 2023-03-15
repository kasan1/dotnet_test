using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class SofinancPart
    {
        public Guid Id { get; set; }
        public Guid? DicTechTypeId { get; set; }
        public DicTechType DicTechType { get; set; }
        public Guid? DicCountryId { get; set; }
        public DicCountry DicCountry { get; set; }
        public decimal minPercent { get; set; }
        public decimal maxPercent { get; set; }
    }
}
