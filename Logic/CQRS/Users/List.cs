using Agro.Bpm.Logic.CQRS.Users.DTOs;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Bpm.Logic.CQRS.Users
{
    public class List
    {
        public class Query : IRequest<Response<ListResponse<UserDto>>>, IPaginationFilter
        {
            public short Page { get; set; } = 1;
            public short PageLimit { get; set; } = 10;
        }

        public class QueryHandler : IRequestHandler<Query, Response<ListResponse<UserDto>>>
        {
            private readonly UserManager<AppUser> _userManager;

            public QueryHandler(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<Response<ListResponse<UserDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var usersQueryable = _userManager.Users
                    .Where(u => u.UserAudienceType == UserAudienceType.Int);

                var users = await usersQueryable
                    .Skip(request.Page * request.PageLimit)
                    .Take(request.PageLimit)
                    .Select(u => new UserDto
                    {
                        Id = u.Id,
                        UserName = u.UserName,
                        FirstName = u.Profile.FirstName,
                        LastName = u.Profile.LastName,
                        MiddleName = u.Profile.Patronymic,
                        Email = u.Email,
                        Positions = u.Branches
                            .Select(b => $"{b.Branch.Region.NameRu} - {b.Position.NameRu}")
                            .ToList()
                    })
                    .ToListAsync(cancellationToken);

                var usersList = new ListResponse<UserDto>
                {
                    List = users,
                    Count = await usersQueryable.CountAsync(cancellationToken)
                };

                return Response.Success("Список пользователей успешно загружен", usersList);
            }
        }
    }
}
