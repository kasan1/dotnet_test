using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons
{
    public class CommitteeResult
    {
        public class Query : IRequest<Response<List<CommitteeResultDto>>>
        { 
            public Guid LoanApplicationTaskId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<List<CommitteeResultDto>>>
        {
            private readonly DataContext _dataContext;

            public QueryHandler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<List<CommitteeResultDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var loanApplicationTask = await _dataContext.LoanApplicationTasks
                    .FirstOrDefaultAsync(x => x.Id == request.LoanApplicationTaskId, cancellationToken);

                if (loanApplicationTask == null)
                    throw new RestException(HttpStatusCode.NotFound, "Задача не найдена");

                var rolesDict = await _dataContext.Roles
                    .Where(x => !x.IsDeleted && x.Value == RoleType.CreditCommittee)
                    .ToListAsync(cancellationToken);

                var loanApplicationTasks = await _dataContext.LoanApplicationTasks
                    .Include(x => x.User)
                        .ThenInclude(x => x.Profile)
                    .Include(x => x.DicTaskStatus)
                    .Where(x => rolesDict.Select(x => x.Id).Contains(x.RoleId.Value)
                        && (x.DicTaskStatus.Code == "Completed" || x.DicTaskStatus.Code == "Rejected")
                        && x.ApplicationId == loanApplicationTask.ApplicationId)
                    .ToListAsync(cancellationToken);

                var result = new List<CommitteeResultDto>();
                foreach (var task in loanApplicationTasks)
                {
                    result.Add(new CommitteeResultDto
                    {
                        UserName = task.User.Profile.GetFullName(),
                        Comment = task.DicTaskStatus.Code == "Completed" ? "За" : "Против"
                    });
                }

                return Response.Success("Запрос выполнен успешно", result);
            }
        }
    }
}
