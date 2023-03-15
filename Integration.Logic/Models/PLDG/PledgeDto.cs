using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Integration.Logic.Models.PLDG
{
    public class PledgeDto
    {
        public long AtsID { get; set; }
        public long GeonimID { get; set; }
        public string HouseNumber { get; set; }
        public long RealtyType { get; set; }
        public long RoomNumber { get; set; }
        public long WallMaterial { get; set; }
        public int YearBuilt { get; set; }
        public decimal TotalSquare { get; set; }
    }
}
