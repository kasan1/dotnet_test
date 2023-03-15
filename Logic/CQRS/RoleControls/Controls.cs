using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.RoleControls.Dto;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.Identity;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.RoleControls
{
    public class Controls
    {
        public class Query : IRequest<Response<List<RoleControlsSettings>>>
        {
            public Guid LoanApplicationTaskId { get; set; }
            public Guid UserId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<List<RoleControlsSettings>>>
        {
            private readonly DataContext _dataContext;

            public QueryHandler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<List<RoleControlsSettings>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var loanApplicationTask = await _dataContext.LoanApplicationTasks
                    .Include(x => x.LoanApplication)
                    .Include(x => x.Role)
                    .Include(x => x.DicLoanHistoryStatus)
                    .Include(x => x.DicTaskStatus)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.LoanApplicationTaskId && x.UserId == request.UserId);
                if (loanApplicationTask == null)
                    throw new RestException(HttpStatusCode.NotFound, "Задача не найдена");

                var rolesDict = await _dataContext.Roles.Where(x => !x.IsDeleted).ToListAsync();
                var roleId = loanApplicationTask.RoleId.Value;
                var role = rolesDict.FirstOrDefault(x => x.Id == loanApplicationTask.RoleId);
                if (role.Value == RoleType.CreditCommittee)
                    roleId = rolesDict.FirstOrDefault(x => x.Code == nameof(RoleType.CreditCommittee)).Id;


                var controlsList = await _dataContext.RoleControls
                    .Include(x => x.Role)
                    .Where(x => !x.IsDeleted && x.RoleId == roleId && x.LoanHistoryStatusId == loanApplicationTask.StatusId)
                    .OrderByDescending(x => x.RoleId == roleId && x.LoanHistoryStatusId == loanApplicationTask.StatusId)
                    .ToListAsync();

                if (!controlsList.Any(x => x.RoleId == roleId))
                    throw new RestException(HttpStatusCode.NotFound, "Настройки не найдены");
                
                var controlsIds = controlsList.Select(x => x.Id);

                var buttons = await _dataContext.RoleControlsButtons
                    .Where(x => !x.IsDeleted && controlsIds.Contains(x.RoleControlId))
                    .OrderBy(x => x.IsApply)
                    .ToListAsync();

                var fields = await _dataContext.RoleControlsFields
                    .Where(x => !x.IsDeleted && controlsIds.Contains(x.RoleControlId))
                    .ToListAsync();

                var values = await _dataContext.RoleControlsFieldValues
                    .Where(x => !x.IsDeleted && x.ApplicationId == loanApplicationTask.ApplicationId)
                    .OrderByDescending(x => x.CreatedDate)
                    .ToListAsync();

                var comments = await _dataContext.Comments
                    .Where(x => !x.IsDeleted && x.ApplicationId == loanApplicationTask.LoanApplication.Id)
                    .GroupBy(x => new { x.RoleControlsFieldId })
                    .Select(x => new { x.Key.RoleControlsFieldId, Count = x.Count() })
                    .ToListAsync();

                var result = new List<RoleControlsSettings> { };
                foreach (var controls in controlsList)
                {
                    if ((controls.Role.Value == RoleType.CreditManager || controls.Role.Value == RoleType.CreditCommittee) 
                        && loanApplicationTask.DicTaskStatus.Code != "Created")
                        continue;

                    result.Add(new RoleControlsSettings
                    {
                        Id = controls.Id,
                        Title = controls.Role.GetName(),
                        SubTitle = controls.GetName(),
                        IsReadOnly = controls.Role.Id != roleId ||
                                     loanApplicationTask.DicTaskStatus.Code != "Created",
                        Fields = fields
                            .Where(x => x.RoleControlId == controls.Id)
                            .Select(x => new RoleControlField
                            {
                                Id = x.Id,
                                Name = x.GetName(),
                                IsChecked = values.FirstOrDefault(v => v.RoleControlsFieldId == x.Id)?.Value ?? false,
                                CountOfComments = comments.Count(c => c.RoleControlsFieldId == x.Id)
                            }),
                        Buttons = buttons
                            .Where(x => x.RoleControlId == controls.Id)
                            .Select(x => new RoleControlButton
                            {
                                TaskStatusId = x.TaskStatusId,
                                Name = x.GetName(),
                                HasForm = x.HasForm,
                                DialogTitle = x.DialogTitle(),
                                DialogMessage = !x.HasForm ? x.DialogMessage() : null,
                                IsApply = x.IsApply
                            })
                    });
                }

                return Response.Success("Запрос выполнен успешно", result);
            }
        }
    }
}
