using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.CQRS.Users.DTOs;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.User.Identity;
using MediatR;

namespace Agro.Shared.Logic.CQRS.Users
{
    public class RefreshToken
    {
        public class RefreshTokenCommand : IRequest<Response<AuthResultDto>>
        {
            public string AccessToken { get; set; }
            public string RefreshToken { get; set; }
        }

        public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Response<AuthResultDto>>
        {
            private readonly IIdentityService _identityService;

            public RefreshTokenCommandHandler(IIdentityService identityService)
            {
                _identityService = identityService;
            }

            public async Task<Response<AuthResultDto>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
            {
                var loginResult = await _identityService.RefreshTokenAsync(request.AccessToken, request.RefreshToken);

                return Response.Success("Запрос выполнен успешно", new AuthResultDto
                {
                    DisplayName = loginResult.DisplayName,
                    AccessToken = loginResult.AccessToken,
                    RefreshToken = loginResult.RefreshToken,
                });
            }
        }
    }
}
