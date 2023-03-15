using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Models.ViewModel
{
    public class CalculatorVM
    {
        public int period
        {
            get;
            set;
        }
        public int rate { get; set; }
        public int sofinanc { get; set; }
        public decimal sum { get; set; }
    }
}
