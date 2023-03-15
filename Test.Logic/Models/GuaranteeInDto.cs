using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class GuaranteeInDto
    {
        public Guid? Id { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? ValidThrough { get; set; }
        public string Guarantor { get; set; }
        public decimal Amount { get; set; }
    }
}
