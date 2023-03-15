using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using System;
using Microsoft.AspNetCore.Identity;
using Agro.Shared.Data.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Agro.Shared.Logic.Common.Exceptions;
using System.Net;
using Agro.Shared.Data.Entities.Notifications;
using Agro.Shared.Logic.Services.Sender;
using System.Collections.Generic;
using Agro.Shared.Logic.Services.Sender.Operations;

namespace Agro.Shared.Logic.CQRS.Notifications
{
    public class Create
    {
        public class CreateNotificationCommand : IRequest<Response<Unit>>
        {
            public Guid? LoanApplicationTaskId { get; set; }

            /// <summary>
            /// Получатель
            /// </summary>
            public Guid UserId { get; set; }

            public string TitleKk { get; set; }
            public string TitleRu { get; set; }
            public string BodyKk { get; set; }
            public string BodyRu { get; set; }
            public void SetValues(string appNumber, string statusRu, string statusKk)
            {
                TitleRu = $"Статус заявки {appNumber}";
                TitleKk = $"{appNumber} өтінімінің мәртебесі";

                BodyRu = $"Статус Вашей заявки {appNumber} изменился на \"{statusRu}\"";
                BodyKk = $"Сіздің {appNumber} өтініміңіздің мәртебесі \"{statusKk}\" болып өзгерді";
            }

        }

        public class Handler : IRequestHandler<CreateNotificationCommand, Response<Unit>>
        {
            private readonly Data.Context.DataContext _dataContext;
            private readonly UserManager<AppUser> _userManager;
            private readonly ISenderService _emailSenderService;

            public Handler(Data.Context.DataContext dataContext, 
                UserManager<AppUser> userManager,
                 ISenderService emailSenderService)
            {
                _dataContext = dataContext;
                _userManager = userManager;
                _emailSenderService = emailSenderService;
            }

            public async Task<Response<Unit>> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
            {
                var user = await _userManager.Users.SingleOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);

                if (user == null)
                {
                    throw new RestException(HttpStatusCode.NotFound, "Пользователь не найден");
                }

                await _dataContext.Notifications.AddAsync(new Notification()
                {
                    UserId = user.Id,
                    TitleKk = request.TitleKk,
                    TitleRu = request.TitleRu,
                    BodyKk = request.BodyKk,
                    BodyRu = request.BodyRu,
                    LoanApplicationTaskId = request.LoanApplicationTaskId

                }, cancellationToken);

                await _dataContext.SaveChangesAsync(cancellationToken);

                if (user.EmailConfirmed)
                {
                    var taskStatusChangedEmailOperation = new TaskStatusChangedEmailOperation(request.TitleRu, request.BodyRu);
                    var message = taskStatusChangedEmailOperation.GetMessage(new List<string>() { user.Email });
                    _emailSenderService.Send(message);
                }

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }
    }
}
