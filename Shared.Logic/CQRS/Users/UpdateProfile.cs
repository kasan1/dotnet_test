using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.CQRS.Users.DTOs;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Models.User.Profile;
using Agro.Shared.Logic.Services.System.Security;
using Agro.Shared.Logic.Services.System.User.Profile;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Agro.Bpm.Logic.CQRS.Users
{
    public class UpdateProfile
    {
        public class Command : IRequest<Response<ProfileDto>>
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public DateTime? BirthDate { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public IFormFile Image { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Response<ProfileDto>>
        {
            private readonly IUserProfileService _userProfileService;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;

            public CommandHandler(IUserProfileService userProfileService,
                IUserAccessor userAccessor,
                IMapper mapper)
            {
                _userProfileService = userProfileService;
                _userAccessor = userAccessor;
                _mapper = mapper;
            }

            public async Task<Response<ProfileDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var createProfileForm = _mapper.Map<CreateProfileForm>(request);

                var profile = await _userProfileService.CreateOrUpdate(_userAccessor.GetCurrentUserId(), createProfileForm, cancellationToken);

                return Response.Success("Профиль успешно изменен", _mapper.Map<ProfileDto>(profile));
            }
        }
    }
}
