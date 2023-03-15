using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.User.Identity;
using FluentValidation;
using MediatR;

namespace Agro.Shared.Logic.CQRS.Users
{
    public class SendResetPasswordToken
    {
        public class Command : IRequest<Response<Unit>>
        {
            public string Username { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Username).NotEmpty();
            }
        }

        public class CommandHandler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly IIdentityService _identityService;

            public CommandHandler(IIdentityService identityService)
            {
                _identityService = identityService;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                await _identityService.SendResetPasswordTokenAsync(request.Username);

                return Response.Success("Сообщение отправлено на почту", Unit.Value);
            }
        }
    }
}
