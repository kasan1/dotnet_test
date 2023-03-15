using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Camunda;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Agro.Bpm.Logic.CQRS.Camunda
{
    public class CompleteAllTasks
    {

        public class Command : IRequest<Response<Unit>>
        {
            public Guid ApplicationId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private DataContext _dataContext;
            private readonly IProcessLogic _processLogic;
            private readonly ILogger<Handler> _logger;

            public Handler(
                DataContext dataContext, 
                IProcessLogic processLogic,
                ILogger<Handler> logger)
            {
                _dataContext = dataContext;
                _processLogic = processLogic;
                _logger = logger;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var tasks = await _dataContext.LoanApplicationTasks
                    .Include(x => x.Role)
                    .Where(x => x.LoanApplication.Id == request.ApplicationId)
                    .ToListAsync(cancellationToken);
                if (!tasks.Any())
                    throw new RestException(HttpStatusCode.NotFound, $"Не найдены активные задачи");

                var taskStatus = await _dataContext.DicTaskStatuses.FirstOrDefaultAsync(x => x.Code == "Completed");
                if (taskStatus == null)
                    throw new RestException(HttpStatusCode.BadRequest, $"'Completed' is not valid status code.");
                                                
                try
                {                    
                    foreach (var t in tasks)
                    {
                        t.TaskStatusId = taskStatus.Id;
                        t.Comment = "Задача закрыта администратором системы";
                        var variables = taskStatus.GetLogicVariables(t.Role.Code);
                        try
                        {
                            await _processLogic.TaskComplete(t.Id, variables);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogWarning("При закрытии задачи возникла ошибка: {0}", ex.Message);

                            if (!ex.Message.Contains("task is null"))
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
