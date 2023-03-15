using System;
using Agro.Shared.Logic.CQRS.Files.DTOs;

namespace Agro.Shared.Logic.CQRS.Users.DTOs
{
    public class ProfileDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Identifier { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public FileDto Image { get; set; }
        public DateTime? CertificateStartDate { get; set; }
        public DateTime? CertificateEndDate { get; set; }
    }
}
