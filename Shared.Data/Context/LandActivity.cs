using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    [Obsolete]
    public class LandActivities:BaseEntity
    {
        public string LandName { get; set; }
        public string LandSquare { get; set; }
        public string LandType { get; set; }
        public Guid? AppActivesId { get; set; }
        public AppActives appActives { get; set; }

    }
}
