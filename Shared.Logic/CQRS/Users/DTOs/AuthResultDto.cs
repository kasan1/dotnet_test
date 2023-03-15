namespace Agro.Shared.Logic.CQRS.Users.DTOs
{
    public class AuthResultDto
    {
        public string DisplayName { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
