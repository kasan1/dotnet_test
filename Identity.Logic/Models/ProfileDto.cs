using System;
using Agro.Shared.Logic.CQRS.Files.DTOs;

namespace Agro.Identity.Logic.Models
{
    public class ProfileDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public FileDto Image { get; set; }
    }
}
