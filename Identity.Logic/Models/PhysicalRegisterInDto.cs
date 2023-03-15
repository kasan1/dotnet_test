using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agro.Identity.Logic.Models
{
    public class PhysicalRegisterInDto : AdditionRegisterInDto
    {
        [Required, StringLength(12)]
        public string IIN { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
    }
}
