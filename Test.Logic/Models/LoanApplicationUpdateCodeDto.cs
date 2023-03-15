using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Okaps.Logic.Models
{
    public class LoanApplicationUpdateCodeDto
    {
        //Id заявки
        public string  ApplicationId { get; set; }
        //код продукта
        public string LoanProductCode { get; set; }
    }
}
