using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Agro.Identity.Logic.Models
{
    public class AdditionRegisterInDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        [Required, MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
