using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Logic.Common.Exceptions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Agro.Shared.Logic.Services.System.User.Branch
{
    public class UserBranchService : IUserBranchService
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;

        public UserBranchService(DataContext dataContext, UserManager<AppUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public async Task Add(Guid userId, Guid branchId, Guid? positionId)
        {
            var user = await _userManager.Users
                .Include(u => u.Branches)
                    .ThenInclude(ub => ub.Position)
                .SingleOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Указанный пользователь не найден в системе");
            }

            var branch = await _dataContext.Branches.SingleOrDefaultAsync(b => b.Id == branchId);
            if (branch == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Указанный филиал не найден в системе");
            }

            if (positionId.HasValue)
            {
                var position = await _dataContext.DicPositions.SingleOrDefaultAsync(b => b.Id == positionId);
                if (position == null)
                {
                    throw new RestException(HttpStatusCode.BadRequest, "Указанная должность не найдена в системе");
                }
            }

            if (user.Branches.Any(ub => ub.BranchId == branchId && ub.PositionId == positionId))
            {
                return;
            }

            user.Branches.Add(new UserBranch
            {
                UserId = userId,
                BranchId = branchId,
                PositionId = positionId
            });

            await _dataContext.SaveChangesAsync();
        }

        public async Task Remove(Guid userId, Guid branchId, Guid? positionId)
        {
            var user = await _userManager.Users
                .Include(u => u.Branches)
                    .ThenInclude(ub => ub.Position)
                .SingleOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                throw new RestException(HttpStatusCode.BadRequest, "Указанный пользователь не найден в системе");
            }

            var userBranch = user.Branches.SingleOrDefault(ub => ub.BranchId == branchId && ub.PositionId == positionId);
            if (userBranch != null)
            {
                _dataContext.UserBranches.Remove(userBranch);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
