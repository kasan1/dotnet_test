using System;
using System.Threading.Tasks;

namespace Agro.Shared.Logic.Services.System.User.Branch
{
    public interface IUserBranchService
    {
        Task Add(Guid userId, Guid branchId, Guid? positionId);
        Task Remove(Guid userId, Guid branchId, Guid? positionId);
    }
}
