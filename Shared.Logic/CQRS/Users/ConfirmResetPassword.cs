using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.User.Identity;
using FluentValidation;
using MediatR;

namespace Agro.Shared.Logic.CQRS.Users
{
    public class ConfirmResetPassword
    {
        public class Command : IRequest<Response<Unit>>
        {
            public string UserName { get; set; }
            public string Token { get; set; }
            public string NewPassword { get; set; }
            public string ConfirmedNewPassword { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.UserName).NotEmpty();
                RuleFor(x => x.Token).NotEmpty();
                RuleFor(x => x.NewPassword).NotEmpty();
                RuleFor(x => x.ConfirmedNewPassword).NotEmpty();
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
                if (!Equals(request.NewPassword, request.ConfirmedNewPassword))
                    throw new RestException(HttpStatusCode.BadRequest, "Пароль не совпадает с подтверждением пароля");

                await _identityService.ResetPasswordAsync(request.UserName, request.Token, request.NewPassword);

                return Response.Success("Пароль успешно изменен", Unit.Value);
            }
        }
    }
}
