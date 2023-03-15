using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Agro.Shared.Data.Extensions;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons
{
    public class TaskList
    {
        public class ListQuery : IRequest<string>
        {
            public string RegNumber { get; set; }

        }

        public class ListQueryHandler : IRequestHandler<ListQuery, string>
        {
            private DataContext _dataContext;

            public ListQueryHandler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<string> Handle(ListQuery request, CancellationToken cancellationToken)
            {
                var query = _dataContext.LoanApplicationTasks
                   .Include(x => x.User)
                        .ThenInclude(x => x.Profile)
                   .Where(x => !x.IsDeleted && x.LoanApplication.RegNumber == request.RegNumber)
                   .AsQueryable();

                var list = await query
                      .OrderBy(x => x.CreatedDate)
                      .Select(x => new
                      {
                          x.CreatedDate,
                          x.User.Profile.Identifier,
                          x.User.Profile.LastName,
                          x.User.Profile.FirstName,
                          RoleCode = x.Role.Code,
                          Role = x.Role.NameRu,
                          StatusCode = x.DicLoanHistoryStatus.Code,
                          Status = x.DicLoanHistoryStatus.NameRu,
                          TaskStatus = x.DicTaskStatus.NameRu
                      })
                      .ToListAsync();

                var result = string.Empty;
                foreach(var t in list)
                {
                    result += $"{t.TaskStatus} {t.CreatedDate:dd.MM.yyyy HH:mm} {t.Identifier} {t.LastName} {t.FirstName}, роль: {t.RoleCode}({t.Role}), статус: {t.StatusCode}({t.Status})\n\n";
                }

                return result;
            }

            
        }
    }
}
