using System.Threading.Tasks;
using Agro.Shared.Logic.Models.User.Identity;

namespace Agro.Shared.Logic.Services.System.User.Identity
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(UserRegisterForm registerInput, bool skipPassword = false);
        Task<AuthenticationResult> LoginAsync(string username, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
        Task<AuthenticationResult> ChangePasswordAsync(string username, string currentPassword, string newPassword);
        Task ResetPasswordAsync(string username, string token, string newPassword);
        Task SendResetPasswordTokenAsync(string username);
        Task ConfirmEmail(string userName, string token);
    }
}
