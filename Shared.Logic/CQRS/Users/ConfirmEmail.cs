using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.User.Identity;
using FluentValidation;
using MediatR;

namespace Agro.Shared.Logic.CQRS.Users
{
    public class ConfirmEmail
    {
        public class Command : IRequest<Response<Unit>>
        {
            public string UserName { get; set; }
            public string Token { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.Token).NotEmpty();
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
                await _identityService.ConfirmEmail(request.UserName, request.Token);

                return Response.Success("Ваша электронная почта подтверждена", Unit.Value);
            }
        }
    }
}
