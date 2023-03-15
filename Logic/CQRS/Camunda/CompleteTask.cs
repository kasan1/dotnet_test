using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.RoleControls;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.Camunda;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.CQRS.Files;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.Camunda
{
    public class CompleteTask
    {

        public class CompleteTaskCommand : IRequest<Response<Unit>>
        {
            public Guid TaskId { get; set; }
            public Guid TaskStatusId { get; set; }
            public string Comment { get; set; }
            public IFormFileCollection Files { get; set; }
            public Dictionary<Guid, bool> Fields { get; set; }
        }

        public class Handler : IRequestHandler<CompleteTaskCommand, Response<Unit>>
        {
            private DataContext _dataContext;
            private readonly IProcessLogic _processLogic;
            private readonly IMediator _mediator;

            public Handler(IMediator mediator, DataContext dataContext, IProcessLogic processLogic)
            {
                _dataContext = dataContext;
                _processLogic = processLogic;
                _mediator = mediator;
            }

            public async Task<Response<Unit>> Handle(CompleteTaskCommand request, CancellationToken cancellationToken)
            {
                var task = await _dataContext.LoanApplicationTasks
                    .Include(x => x.LoanApplication)
                    .Include(x => x.Role)
                    .Include(x => x.DicLoanHistoryStatus)
                    .FirstOrDefaultAsync(x => x.Id == request.TaskId, cancellationToken);
                if (task == null)
                    throw new RestException(HttpStatusCode.NotFound, $"Task '{request.TaskId}' is not found.");

                var taskStatus = await _dataContext.DicTaskStatuses.FirstOrDefaultAsync(x => x.Id == request.TaskStatusId);
                if (taskStatus == null)
                    throw new RestException(HttpStatusCode.BadRequest, $"'{request.TaskStatusId}' is not valid status.");

                task.Comment = request.Comment;

                #region форма с файлами
                if (request.Fields?.Keys.Count > 0)
                {
                    await _mediator.Send(new SetFieldsValues.SetFieldsValuesCommand
                    {
                        Fields = request.Fields,
                        LoanApplicationTaskId = request.TaskId
                    }, cancellationToken);
                }

                if (request.Files != null)
                    await _mediator.Send(new Upload.UploadCommand
                    {
                        EntityId = request.TaskId,
                        EntityType = EntityType.LoanApplicationTask,
                        Files = request.Files
                    });
                #endregion

                try
                {
                    var tasks = await _dataContext.LoanApplicationTasks
                        .Include(x => x.LoanApplication)
                        .Include(x => x.Role)
                        .Include(x => x.DicLoanHistoryStatus)
                        .Where(x => !x.IsDeleted && x.ApplicationId == task.ApplicationId && x.DicTaskStatus.Code == "Created" && x.StatusId == task.StatusId && x.RoleId == task.RoleId)
                        .ToListAsync();
                    foreach (var t in tasks)
                    {
                        t.TaskStatusId = request.TaskStatusId;
                        var variables = taskStatus.GetLogicVariables(t.Role.Code);
                        try
                        {
                            await _processLogic.TaskComplete(t.Id, variables);
                        }
                        catch(Exception ex)
                        {
                           if(!ex.Message.Contains("task is null"))
                                throw new RestException(HttpStatusCode.InternalServerError, ex.Message);
                        }
                    }
                    await _dataContext.SaveChangesAsync(cancellationToken);
                    return Response.Success("Запрос выполнен успешно", Unit.Value);
                }
                catch (Exception e)
                {
                    throw new RestException(HttpStatusCode.InternalServerError, e.Message);
                }
            }
        }

    }
}
