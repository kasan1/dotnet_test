using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Logic.Services.System.Security;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons
{
    public class Navigation
    {
        public class NavigationQuery : IRequest<Response<List<NavigationDto>>>
        {
        }

        public class NavigationQueryHandler : IRequestHandler<NavigationQuery, Response<List<NavigationDto>>>
        {
            private DataContext _dataContext;
            private readonly IUserAccessor _userAccessor;

            public NavigationQueryHandler(DataContext dataContext, IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _userAccessor = userAccessor;
            }

            public async Task<Response<List<NavigationDto>>> Handle(NavigationQuery request, CancellationToken cancellationToken)
            {
                var userId = _userAccessor.GetCurrentUserId();
                var roles = await _dataContext.UserRoles
                   .Where(x => !x.IsDeleted && x.UserId == userId &&
                                x.Role.Value != RoleType.CreditCommitteeChairman)
                   .Include(x => x.Role)
                   .ToListAsync();

                var statuses = await _dataContext.DicTaskStatuses
                    .Where(x => !x.IsDeleted)
                    .OrderBy(x => x.Sort)
                    .ToListAsync();

                var list = await _dataContext.LoanApplicationTasks
                      .Where(x => !x.IsDeleted && x.UserId == userId && !x.LoanApplication.IsDeleted)
                      .Select(x => new { x.RoleId, x.TaskStatusId, x.ApplicationId, x.CreatedDate })
                      .OrderByDescending(x => x.CreatedDate)
                        .ThenBy(x => x.ApplicationId)
                      .ToListAsync();

                var result = new List<NavigationDto> { };
                if (roles.Count > 1)
                    result.Add(new NavigationDto
                    {
                        Name = "Все задачи",
                        Items = new List<NavigationItemDto>{
                              new NavigationItemDto{
                                   Name = "Все",
                                   Value = 0
                              }
                          }
                    });
                var valueAll = 0;
                foreach (var role in roles)
                {
                    var items = new List<NavigationItemDto> {
                        new NavigationItemDto{
                             Name = "Все",
                             Value = 0
                        }
                    };
                    var hashset = new HashSet<Guid>();
                    var value = 0;
                    foreach (var status in statuses)
                    {
                        var values = list.Where(x => x.RoleId == role.RoleId && x.TaskStatusId == status.Id
                                && !hashset.Contains(x.ApplicationId)
                            )
                            .OrderByDescending(x => x.CreatedDate)
                            .Select(x => x.ApplicationId)
                            .Distinct()
                            .ToList();
                        values.ForEach(x => hashset.Add(x));
                        value += values.Count;
                        items.Add(new NavigationItemDto
                        {
                            StatusId = status.Id,
                            Name = status.GetName(),
                            Value = values.Count
                        });
                    }
                    items.First().Value = value;
                    valueAll += value;
                    result.Add(new NavigationDto
                    {
                        RoleId = role.RoleId,
                        Name = role.Role.GetName(),
                        Items = items
                    });
                }
                if (roles.Count > 1)
                    result.First().Items.First().Value = valueAll;
                
                return Response.Success("Запрос выполнен успешно", result);
            }


        }
    }
}
