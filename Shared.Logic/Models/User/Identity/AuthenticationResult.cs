using System;

namespace Agro.Shared.Logic.Models.User.Identity
{
    public class AuthenticationResult
    {
        public Guid UserId { get; set; }
        public string DisplayName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
