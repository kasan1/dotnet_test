using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.Security;
using Agro.Shared.Logic.Services.System.User.Identity;
using FluentValidation;
using MediatR;

namespace Agro.Shared.Logic.CQRS.Users
{
    public class ChangePassword
    {
        public class Command : IRequest<Response<Unit>>
        {
            public string OldPassword { get; set; }
            public string NewPassword { get; set; }
            public string ConfirmedNewPassword { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.OldPassword).NotEmpty();
                RuleFor(x => x.NewPassword).NotEmpty();
                RuleFor(x => x.ConfirmedNewPassword).NotEmpty();
            }
        }

        public class CommandHandler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly IIdentityService _identityService;
            private readonly IUserAccessor _userAccessor;

            public CommandHandler(IIdentityService identityService, IUserAccessor userAccessor)
            {
                _identityService = identityService;
                _userAccessor = userAccessor;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                await _identityService.ChangePasswordAsync(_userAccessor.GetCurrentUsername(), 
                    request.OldPassword,
                    request.NewPassword);

                return Response.Success("Пароль успешно изменен", Unit.Value);
            }
        }
    }
}
