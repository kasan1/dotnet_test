using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.CQRS.Files;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons
{
    public class ExpertiseResult
    {
        public class Query : IRequest<Response<List<ExpertiseResultDto>>>
        {
            public Guid LoanApplicationTaskId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<List<ExpertiseResultDto>>>
        {
            private readonly DataContext _dataContext;
            private readonly IMediator _mediator;

            public QueryHandler(DataContext dataContext, IMediator mediator)
            {
                _dataContext = dataContext;
                _mediator = mediator;
            }

            public async Task<Response<List<ExpertiseResultDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var loanApplicationTask = await _dataContext.LoanApplicationTasks
                    .FirstOrDefaultAsync(x => x.Id == request.LoanApplicationTaskId);

                if (loanApplicationTask == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                var expertiseRolesList = new List<RoleType>() 
                {
                    RoleType.Pledger, RoleType.Purchaser, RoleType.Jurist, RoleType.SecurityManager, RoleType.RiskManager, RoleType.Logist
                };

                var rolesDict = await _dataContext.Roles
                    .Where(x => !x.IsDeleted && expertiseRolesList.Contains(x.Value))
                    .ToListAsync();

                var loanApplicationTasks = await _dataContext.LoanApplicationTasks
                    .Include(x => x.DicTaskStatus)
                    .Where(x => rolesDict.Select(x => x.Id).Contains(x.RoleId.Value)
                        && x.DicTaskStatus.Code == "Completed"
                        && x.ApplicationId == loanApplicationTask.ApplicationId)
                    .OrderBy(x => x.ModifiedDate)
                    .ToListAsync();

                var comments = await _dataContext.Comments
                    .Include(x => x.RoleControlsField)
                        .ThenInclude(f => f.RoleControls)
                    .Where(x => x.ApplicationId == loanApplicationTask.ApplicationId)
                    .Select(x => new { x.Id, x.UserId, x.Text, x.RoleControlsField.RoleControls.RoleId })
                    .ToListAsync();

                var result = new List<ExpertiseResultDto>();
                foreach (var task in loanApplicationTasks)
                {
                    foreach (var comment in comments.Where(x => x.UserId == task.UserId && x.RoleId == task.RoleId))
                    {
                        var files = await _mediator.Send(new ListByEntity.Query()
                        {
                            EntityId = comment.Id,
                            EntityType = EntityType.Comment
                        });

                        result.Add(new ExpertiseResultDto
                        {
                            RoleName = rolesDict.First(x => x.Id == task.RoleId).NameRu,
                            Comment = comment.Text,
                            Files = files.Data
                        });
                    }
                }

                return Response.Success("Запрос выполнен успешно", result);
            }
        }
    }
}
