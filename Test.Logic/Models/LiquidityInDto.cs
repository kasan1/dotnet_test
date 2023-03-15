using Agro.Shared.Data.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class LiquidityInDto
    {
        public Guid? Id { get; set; }
        public PledgeTypeEnum PledgeType { get; set; }
        public LiquidityTypeEnum LiquidityType { get; set; }
        public string Description { get; set; }
        public float Coefficient { get; set; }
    }
}
