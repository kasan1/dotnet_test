using System;
using Microsoft.AspNetCore.Http;

namespace Agro.Identity.Logic.Models
{
    public class UpdateProfileDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public IFormFile Image { get; set; }
    }
}
