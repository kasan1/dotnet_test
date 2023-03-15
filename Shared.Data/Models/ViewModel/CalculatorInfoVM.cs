using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Models.ViewModel
{
    public class CalculatorInfoVM
    {
        public int Rate { get; set; }
        public decimal maxPercent { get; set; }
        public decimal minPercent { get; set; }
        public int maxDuration { get; set; }
        public int minDuration { get; set; }

    }
}
