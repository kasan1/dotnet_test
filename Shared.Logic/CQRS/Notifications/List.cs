using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Agro.Shared.Logic.CQRS.Notifications.DTOs;
using Agro.Shared.Logic.Services.System.Security;

namespace Agro.Shared.Logic.CQRS.Notifications
{
    public class List
    {
        public class Query : IPaginationFilter, IRequest<Response<ListResponse>>
        {
            public short Page { get; set; } = 1;
            public short PageLimit { get; set; } = 10;
        }

        public class Handler : IRequestHandler<Query, Response<ListResponse>>
        {
            private readonly Data.Context.DataContext _dataContext;
            private readonly IUserAccessor _userAccessor;

            public Handler(Data.Context.DataContext dataContext,  IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _userAccessor = userAccessor;
            }

            public async Task<Response<ListResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _dataContext.Notifications
                 .Where(x => x.UserId == _userAccessor.GetCurrentUserId())
                 .AsQueryable();

                var list = await query
                        .Include(x => x.LoanApplicationTask)
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip((request.Page - 1) * request.PageLimit)
                    .Take(request.PageLimit)
                    .Select(x => new NotificationDto
                    {
                        Id = x.Id,
                        Title = x.GetTitle(),
                        Body = x.GetBody(),
                        CreatedDate = x.CreatedDate,
                        IsRead = x.IsRead,
                        LoanApplicationId = x.LoanApplicationTask.ApplicationId
                    })
                    .ToListAsync(cancellationToken);

                return Response.Success("Запрос выполнен успешно", new ListResponse
                {
                    List = list,
                    Count = await query.CountAsync(cancellationToken)
                });
            }
        }
    }
}
