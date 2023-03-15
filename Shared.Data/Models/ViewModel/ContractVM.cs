using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Models.ViewModel
{
    public class ContractVM
    {
        public string code { get; set; }
        public string selectedDate { get; set; }
        public List<MainTechVM> MainTechVms { get; set; }
        public List<ComplectTechVM> ComplectTechVM { get; set; }
        public CalculatorVM CalculatorVms { get; set; }

    }
}
