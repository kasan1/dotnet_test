using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Camunda;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.Camunda.Commands
{
    public class StopProcess
    {

        public class Command : IRequest<Response<Unit>>
        {
            public Guid ApplicationId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private DataContext _dataContext;
            private readonly IProcessLogic _processLogic;

            public Handler(DataContext dataContext, IProcessLogic processLogic)
            {
                _dataContext = dataContext;
                _processLogic = processLogic;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications
                    .FirstOrDefaultAsync(x => x.Id == request.ApplicationId && !x.IsDeleted && x.ProcessInstanceId.HasValue);

                if (application == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Заявка не найдена.");

                //TODO: пересмотреть статус для отказа на заявку
                application.Status = Shared.Data.Primitives.ApplicationTypeEnum.CMArchive;

                var tasks = await _dataContext.LoanApplicationTasks
                    .Where(x => !x.IsDeleted && x.ApplicationId == application.Id)
                    .ToListAsync();

                tasks.ForEach(x => x.IsDeleted = true);
                await _dataContext.SaveChangesAsync();

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }

    }
}
