using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Admin.Logic.User
{
    public interface IUserLogic
    {
        Task<object> UserRoles(Guid userId);
        Task<object> AddRoleToUser(Guid userId, RoleType roleEnum);
        Task<List<UserRole>> GetUsersByRoleBranch(RoleType roleEnum, Guid BranchId);
    }
}
