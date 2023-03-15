using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.Users.DTOs;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Logic.CQRS.Users.DTOs;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Models.User.Identity;
using Agro.Shared.Logic.Models.User.Profile;
using Agro.Shared.Logic.Services.System.User.Branch;
using Agro.Shared.Logic.Services.System.User.Identity;
using Agro.Shared.Logic.Services.System.User.Profile;
using AutoMapper;
using MediatR;

namespace Agro.Bpm.Logic.CQRS.Users
{
    public class Register
    {
        public class Command : IRequest<Response<AuthResultDto>>
        {
            public string Identifier { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public string Email { get; set; }
            public List<UserBranchDto> Branches { get; set; } = new List<UserBranchDto>();
            public List<Guid> Roles { get; set; } = new List<Guid>();
        }

        public class CommandHandler : IRequestHandler<Command, Response<AuthResultDto>>
        {
            private readonly IIdentityService _identityService;
            private readonly IUserProfileService _userProfileService;
            private readonly IUserBranchService _userBranchService;
            private readonly IMapper _mapper;

            public CommandHandler(IIdentityService identityService, 
                IUserProfileService userProfileService, 
                IUserBranchService userBranchService, 
                IMapper mapper)
            {
                _identityService = identityService;
                _userProfileService = userProfileService;
                _userBranchService = userBranchService;
                _mapper = mapper;
            }

            public async Task<Response<AuthResultDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var registerForm = _mapper.Map<UserRegisterForm>(request);
                registerForm.UserAudienceType = UserAudienceType.Int;
                registerForm.EssenceType = EssenceType.Individual;

                var authResult = await _identityService.RegisterAsync(registerForm, true);

                var createProfileForm = _mapper.Map<CreateProfileForm>(request);

                var profile = await _userProfileService.CreateOrUpdate(authResult.UserId, createProfileForm, cancellationToken);
                authResult.DisplayName = $"{profile.LastName} {profile.FirstName} {profile.MiddleName}".Trim();

                foreach (var branch in request.Branches)
                {
                    foreach (var branchId in branch.BranchIds)
                    {
                        await _userBranchService.Add(authResult.UserId, branchId, branch.PositionId);
                    }
                }

                return Response.Success("Пользователь успешно зарегистрирован", _mapper.Map<AuthResultDto>(authResult));
            }
        }
    }
}
