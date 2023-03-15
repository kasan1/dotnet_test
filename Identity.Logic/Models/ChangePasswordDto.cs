namespace Agro.Identity.Logic.Models
{
    public class ChangePasswordDto
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmedNewPassword { get; set; }
    }
}
