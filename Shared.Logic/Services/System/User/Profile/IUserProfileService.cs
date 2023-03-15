using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.User.Profile;

namespace Agro.Shared.Logic.Services.System.User.Profile
{
    public interface IUserProfileService
    {
        Task<ProfileResult> Get(Guid userId, CancellationToken cancellationToken = default);
        Task<ProfileResult> CreateOrUpdate(Guid userId, CreateProfileForm createProfileData, CancellationToken cancellationToken = default);
    }
}
