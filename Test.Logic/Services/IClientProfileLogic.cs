using Agro.Okaps.Logic.Models;
using Agro.Shared.Data.Context;
using System;
using System.Threading.Tasks;

namespace Agro.Okaps.Logic
{
    public interface IClientProfileLogic
    {
        Task<Guid> AddClientProfile(ClientProfileInDto model);
        Task<object> GetClientProfileByID(Guid UserId);
        Task UpdateClientProfile(ClientProfileInDto model);
        Task UpdateClientProfileInfo(ClientProfileInDto model);
        Task<bool> CheckExistsByUserId(Guid userId);

        Task<object> GetBranchAdressByClientId(Guid UserId);
    }
}