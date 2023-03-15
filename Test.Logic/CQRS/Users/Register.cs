using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Logic.CQRS.Users.DTOs;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Models.User.Identity;
using Agro.Shared.Logic.Models.User.Profile;
using Agro.Shared.Logic.Services.System.User.Identity;
using Agro.Shared.Logic.Services.System.User.Profile;
using AutoMapper;
using MediatR;

namespace Agro.Okaps.Logic.CQRS.Users
{
    public class Register
    {
        public class Command : IRequest<Response<AuthResultDto>>
        {
            public string Identifier { get; set; }
            public string Email { get; set; }
            public string PhoneNumber { get; set; }
            public EssenceType EssenceType { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
            public Guid AgreementId { get; set; }
            public DateTime? CertificateDateFrom { get; set; }
            public DateTime? CertificateDateTo { get; set; }

            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string MiddleName { get; set; }
            public DateTime? BirthDate { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Response<AuthResultDto>>
        {
            private readonly IIdentityService _identityService;
            private readonly IUserProfileService _userProfileService;
            private readonly IMapper _mapper;

            public CommandHandler(
                IIdentityService identityService,
                IUserProfileService userProfileService,
                IMapper mapper)
            {
                _identityService = identityService;
                _userProfileService = userProfileService;
                _mapper = mapper;
            }

            public async Task<Response<AuthResultDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var registerForm = _mapper.Map<UserRegisterForm>(request);

                registerForm.UserAudienceType = UserAudienceType.Ext;

                var authResult = await _identityService.RegisterAsync(registerForm);

                var createProfileForm = _mapper.Map<CreateProfileForm>(request);

                var profile = await _userProfileService.CreateOrUpdate(authResult.UserId, createProfileForm, cancellationToken);
                authResult.DisplayName = $"{profile.LastName} {profile.FirstName} {profile.MiddleName}".Trim();

                return Response.Success("Пользователь успешно зарегистрирован", _mapper.Map<AuthResultDto>(authResult));
            }
        }
    }
}
