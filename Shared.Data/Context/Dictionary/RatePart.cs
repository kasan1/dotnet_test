using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Context.Dictionary
{
    public class RatePart
    {
        public Guid? Id { get; set; }
        public Guid? DicCountryId { get; set; }
        public DicCountry dicCountry { get; set; }
        public int Rate { get; set; }
        public Guid? DicTechTypeId { get; set; }
        public DicTechType DicTechType { get; set; }
    }
}
