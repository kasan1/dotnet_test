using System;
using System.Collections.Generic;
using System.Text;
using Agro.Shared.Data.Entities.Base;

namespace Agro.Shared.Data.Context
{
    [Obsolete]
    public class FloraActivities:BaseEntity
    {
        public string CultureName { get; set; }
        public string PlanningPosevSquare { get; set; }
        public string NormaPoseva { get; set; }
        public string PriceRealization { get; set; }

        public string Zatraty { get; set; }
        public string Urozh1 { get; set; }
        public string Urozh2 { get; set; }
        public string Urozh3 { get; set; }
        public string Urozh5 { get; set; }
        public string order { get; set; }
        public Guid? AppActivesId { get; set; }
        public AppActives appActives { get; set; }
    }
}
