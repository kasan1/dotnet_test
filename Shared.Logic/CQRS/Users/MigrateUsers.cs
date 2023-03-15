using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.User.Profile;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Agro.Shared.Logic.CQRS.Users
{
    public class MigrateUsers
    {
        public class Command : IRequest<Response<Unit>>
        { 
        }

        public class CommandHandler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly UserManager<AppUser> _userManager;

            public CommandHandler(DataContext dataContext,
                                  UserManager<AppUser> userManager)
            {
                _dataContext = dataContext;
                _userManager = userManager;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var users = await _dataContext.Users
                    .Include(x => x.UserRoles)
                        .ThenInclude(x => x.Role)
                    .ToListAsync();

                foreach (var user in users)
                {
                    if (!string.IsNullOrEmpty(user.Identifier))
                    {
                        var existingUser = await _userManager.FindByNameAsync(user.Identifier);
                        if (existingUser != null)
                        {
                            continue;
                        }

                        var newUser = new AppUser
                        {
                            Id = user.Id,
                            ConcurrencyStamp = user.Id.ToString(),
                            UserName = user.Identifier,
                            Email = user.Email,
                            PhoneNumber = user.Phone,
                            EssenceType = user.IsPhysical
                                ? EssenceType.Individual
                                : EssenceType.Legal,
                            UserAudienceType = user.Audience,
                            Profile = new UserProfile
                            {
                                FirstName = user.IsPhysical
                                ? (user.FirstName ?? "")
                                : (user.CompanyName ?? ""),
                                LastName = user.LastName,
                                Patronymic = user.MiddleName,
                                BirthDate = user.BirthDate,
                                Identifier = user.Identifier
                            }
                        };

                        var createResult = await _userManager.CreateAsync(newUser, "123456aA!");
                        
                        if (createResult.Succeeded)
                        {
                            var existingRoles = await _userManager.GetRolesAsync(newUser);
                            if (!existingRoles.Any())
                            {
                                var roleCodes = user.UserRoles.Select(x => x.Role.Code);
                                var rolesResult = await _userManager.AddToRolesAsync(newUser, roleCodes);
                            
                                if (!rolesResult.Succeeded)
                                {
                                    Console.WriteLine($"Could not add user {user.Identifier} to roles {string.Join(", ", roleCodes)}");
                                }
                            }
                        }
                    }
                }

                return Response.Success("Users migrated successfully", Unit.Value);
            }
        }
    }

}
