using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Agro.Shared.Data.Extensions;
using Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs;
using Agro.Shared.Logic.Services.System.Security;
using Agro.Shared.Data.Enums.Identity;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons
{
    public class List
    {
        public class ListQuery : ListFilter, IRequest<Response<LoanApplicationListDto>>
        {
            public string Search { get; set; }

            public Guid? RoleId { get; set; }

            public Guid? StatusId { get; set; }
        }

        public class ListQueryHandler : IRequestHandler<ListQuery, Response<LoanApplicationListDto>>
        {
            private DataContext _dataContext;
            private readonly IUserAccessor _userAccessor;

            public ListQueryHandler(DataContext dataContext, IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _userAccessor = userAccessor;
            }

            public async Task<Response<LoanApplicationListDto>> Handle(ListQuery request, CancellationToken cancellationToken)
            {
                var userId = _userAccessor.GetCurrentUserId();
                var query = _dataContext.LoanApplications
                   .Where(x => !x.IsDeleted && x.LoanApplicationTasks.Any(xx => xx.UserId == userId && !xx.IsDeleted))
                   .AsQueryable();

                var search = !string.IsNullOrEmpty(request.Search) ? request.Search.ToLower().Trim() : null;
                if (search != null)
                    query = query
                        .Where(x =>
                            x.User.Profile.LastName.Contains(search) ||
                            x.User.Profile.FirstName.Contains(search) ||
                            x.User.Profile.Patronymic.Contains(search) ||
                            x.User.Profile.Identifier.Contains(search));

                if (request.RoleId.HasValue)
                    query = query.Where(x => x.LoanApplicationTasks.Any(xx => xx.UserId == userId && !xx.IsDeleted && xx.RoleId == request.RoleId.Value)) ;

                if (request.StatusId.HasValue)
                    query = query.Where(x => x.LoanApplicationTasks.OrderBy(x => x.DicTaskStatus.Sort).First(xx => xx.UserId == userId && !xx.IsDeleted).TaskStatusId == request.StatusId.Value);

                var count = await query
                      .CountAsync();

                var list = await query
                      .OrderBy(GetSortProperty(request.OrderBy), "Id", request.Order)
                      .Skip(request.Skip)
                      .Take(request.PageLimit)
                      .Select(x => new LoanApplicationDto
                      {
                          LoanApplicationId = x.Id,
                          LoanApplicationTaskId = x.LoanApplicationTasks.OrderBy(xx => xx.DicTaskStatus.Sort)
                            .FirstOrDefault(xx => xx.UserId == userId && !xx.IsDeleted).Id,
                          Fullname = x.User.Profile.GetFullName(),
                          RegisterNumber = x.RegNumber,
                          Iin = x.User.Profile.Identifier,
                          AppointmentDate = x.CreatedDate,
                          LoanStatus = x.DicLoanHistoryStatus.GetName(),
                          LoanProduct = x.DicLoanProducts.GetName(),
                          LoanType = x.DicLoanType.GetName()
                      })
                      .ToListAsync();
                
                return Response.Success("Запрос выполнен успешно", new LoanApplicationListDto {
                    List = list,
                    Count = count
                });
            }

            private static string GetSortProperty(string property)
            {
                if (property?.ToLower() == nameof(LoanApplicationDto.LoanStatus).ToLower())
                    return nameof(LoanApplicationTask.StatusId);

                return property;

            }
        }
    }
}
