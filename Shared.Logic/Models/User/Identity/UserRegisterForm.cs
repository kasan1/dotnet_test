using System;
using System.Collections.Generic;
using Agro.Shared.Data.Enums.Identity;

namespace Agro.Shared.Logic.Models.User.Identity
{
    public class UserRegisterForm
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public UserAudienceType UserAudienceType { get; set; }
        public EssenceType EssenceType { get; set; }
        public Guid? AgreementId { get; set; }
        public List<Guid> Roles { get; set; } = new List<Guid>();
    }
}
