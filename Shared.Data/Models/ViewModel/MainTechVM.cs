using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Models.ViewModel
{
    public class MainTechVM
    {
        public int id { get; set; }
        public decimal price { get; set; }
        public string model { get; set; }
        public string manufacturer { get; set; }
        public string provider { get; set; }
        public int Count { get; set; }

    }
}
