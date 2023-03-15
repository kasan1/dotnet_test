using Agro.Identity.Logic.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Identity.Logic
{
    public interface IAccountLogic
    {
        Task<AuthResult> Login(LoginInDto dto);
        Task<AuthResult> UpdateToken(string accessToken, string refToken);
        Task<Guid> Register(AdditionRegisterInDto model, bool IsPhysical);
        Task<bool> GetByIdentifier(string identifier);

        Task<ProfileDto> GetProfile(Guid userId, CancellationToken cancellationToken);
        Task<ProfileDto> UpdateProfile(Guid userId, UpdateProfileDto profileDto, CancellationToken cancellationToken);
        Task<bool> ChangePassword(Guid userId, ChangePasswordDto passwordDto, CancellationToken cancellationToken);

        Task UpdateBranchId(Guid userId, Guid branchId);
    }
}
