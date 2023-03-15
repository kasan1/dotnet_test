using System;
using Agro.Shared.Data.Enums.Identity;

namespace Agro.Okaps.Logic.CQRS.Users.DTOs
{
    public class RegisterUserDto
    {
        public string Identifier { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public EssenceType EssenceType { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Middlename { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
