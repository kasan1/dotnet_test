using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.CQRS.Users.DTOs;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.User.Identity;
using AutoMapper;
using MediatR;

namespace Agro.Bpm.Logic.CQRS.Users
{
    public class Login
    {
        public class LoginCommand : IRequest<Response<AuthResultDto>>
        {
            public string Login { get; set; }
            public string Password { get; set; }
        }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, Response<AuthResultDto>>
        {
            private readonly IIdentityService _identityService;
            private readonly IMapper _mapper;

            public LoginCommandHandler(IIdentityService identityService, IMapper mapper)
            {
                _identityService = identityService;
                _mapper = mapper;
            }

            public async Task<Response<AuthResultDto>> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var authResult = await _identityService.LoginAsync(request.Login, request.Password);

                return Response.Success("Запрос выполнен успешно", _mapper.Map<AuthResultDto>(authResult));
            }
        }
    }
}
