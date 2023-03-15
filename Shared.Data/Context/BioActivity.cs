using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    [Obsolete]
    public class BioActivity:BaseEntity
    {
        public string Name { get; set; }
        public string EdinicaForLive { get; set; }
        public string Count { get; set; }
        public string EdinicaForDead { get; set; }
        public string Type { get; set; }
        public Guid? AppActivesId { get; set; }
        public AppActives appActives { get; set; }
    }
}
