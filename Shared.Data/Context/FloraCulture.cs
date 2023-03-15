using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    public class FloraCulture:BaseEntity
    {
        public string zatratyNa1Ga { get; set; }
        public string normaVyseva { get; set; }
        public string Name { get; set; }
        public string Urozh5 { get; set; }

        
        public Guid? DicRegionId { get; set; }
        public DicRegion DicRegion { get; set; }
    }
}
