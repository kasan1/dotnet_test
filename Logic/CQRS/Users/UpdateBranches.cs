using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.Users.DTOs;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.User.Branch;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.Users
{
    public class UpdateBranches
    {
        public class Command : IRequest<Response<Unit>>
        {
            public Guid UserId { get; set; }
            public List<UserBranchDto> Branches { get; set; } = new List<UserBranchDto>();
        }

        public class CommandHandler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IUserBranchService _userBranchService;

            public CommandHandler(DataContext dataContext, IUserBranchService userBranchService)
            {
                _dataContext = dataContext;
                _userBranchService = userBranchService;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var userBranches = await _dataContext.UserBranches
                    .Where(ub => ub.UserId == request.UserId)
                    .Select(ub => new
                    {
                        ub.BranchId,
                        ub.PositionId
                    })
                    .ToListAsync();

                foreach (var branch in request.Branches)
                {
                    foreach (var branchId in branch.BranchIds)
                    {
                        await _userBranchService.Add(request.UserId, branchId, branch.PositionId);
                    }
                }

                var userBranchesToRemove = userBranches.Where(ub => !request.Branches.Any(b => b.BranchIds.Contains(ub.BranchId) && b.PositionId == ub.PositionId));
                foreach (var branch in userBranchesToRemove)
                {
                    await _userBranchService.Remove(request.UserId, branch.BranchId, branch.PositionId);
                }

                return Response.Success("Филиал(ы) успешно добавлен(ы)", Unit.Value);
            }
        }
    }
}
