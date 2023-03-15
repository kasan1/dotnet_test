using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Agro.Shared.Logic.Models.Common;
using Microsoft.EntityFrameworkCore;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Data.Primitives;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Agro.Shared.Logic.Services.System.Security;

namespace Agro.Okaps.Logic.CQRS.LoanApplication
{
    public class Delete
    {
        public class DeleteCommand : IRequest<Response<Unit>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class CommandHandler : IRequestHandler<DeleteCommand, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IUserAccessor _userAccessor;

            public CommandHandler(DataContext dataContext, IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _userAccessor = userAccessor;
            }

            public async Task<Response<Unit>> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications
                    .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId && x.UserId == _userAccessor.GetCurrentUserId());
                
                if (application == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                if (application.Status != ApplicationTypeEnum.Temp)
                    throw new RestException(HttpStatusCode.BadRequest, "Заявка уже в работе, вы не можете вносить изменения");

                _dataContext.LoanApplications.Remove(application);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }
    }
}
