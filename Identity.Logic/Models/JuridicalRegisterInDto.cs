using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agro.Identity.Logic.Models
{
    public class JuridicalRegisterInDto : AdditionRegisterInDto
    {
        [Required, StringLength(12)]
        public string BIN { get; set; }
        [Required]
        public string CompanyName { get; set; }
    }
}
