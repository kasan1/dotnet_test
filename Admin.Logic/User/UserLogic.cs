using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Data.Repos.Role;
using Agro.Shared.Data.Repos.User;
using Agro.Shared.Data.Repos.UserRole;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Admin.Logic.User
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserRoleRepo _userRoleRepo;
        private readonly IRoleRepo _roleRepo;

        public UserLogic(IUserRoleRepo userRoleRepo, IRoleRepo roleRepo)
        {
            _userRoleRepo = userRoleRepo;
            _roleRepo = roleRepo;
        }


        public async Task<object> UserRoles(Guid userId)
        {
            var _ = await _userRoleRepo.GetQueryable(x => !x.IsDeleted && x.UserId == userId)
                .AsNoTracking()
                .Include(x => x.Role)
                .Select(x => new
                {
                    x.Id,
                    x.Role.Value,
                })
                .ToListAsync();
            return _;
        }

        public async Task<object> AddRoleToUser(Guid userId, RoleType roleEnum)
        {           
            var role = await _roleRepo.GetQueryable(x => x.Value == roleEnum).FirstAsync();
            UserRole userRole = new UserRole();
            userRole.UserId = userId;
            userRole.RoleId = role.Id;
            await _userRoleRepo.Add(userRole);
            return true;
        }

        public async Task<List<UserRole>> GetUsersByRoleBranch(RoleType roleEnum, Guid BranchId)
        {
            //var _ = await _userRoleRepo.GetQueryable(x => !x.IsDeleted)
            //    .Include(x => x.Role)
            //    .Include(x => x.User)
            //    .Where(x => x.Role.Value == roleEnum && x.User.Branches.Any(xx => xx.BranchId == BranchId) && !x.User.IsDeleted)
            //    .ToListAsync();
            //return _;
            throw new NotImplementedException();
        }
        
    }
}
