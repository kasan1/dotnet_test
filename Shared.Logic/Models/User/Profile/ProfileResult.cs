using System;
using Agro.Shared.Logic.Models.System;

namespace Agro.Shared.Logic.Models.User.Profile
{
    public class ProfileResult
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Identifier { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public FileMetaData Image { get; set; }
        public DateTime? CertificateStartDate { get; set; }
        public DateTime? CertificateEndDate { get; set; }
    }
}
