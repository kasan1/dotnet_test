using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.RoleControls
{
    public class SetFieldsValues
    {
        public class SetFieldsValuesCommand : IRequest<Response<Unit>>
        {
            public Guid LoanApplicationTaskId { get; set; }

            public Dictionary<Guid, bool> Fields { get; set; }
        }

        public class Handler : IRequestHandler<SetFieldsValuesCommand, Response<Unit>>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<Unit>> Handle(SetFieldsValuesCommand request, CancellationToken cancellationToken)
            {
                var loanApplicationTask = await _dataContext.LoanApplicationTasks
                    .FirstOrDefaultAsync(x => x.Id == request.LoanApplicationTaskId);
                if (loanApplicationTask == null)
                    throw new RestException(HttpStatusCode.NotFound, "Задача не найдена");

                var controls = await _dataContext.RoleControls
                    .FirstOrDefaultAsync(x => x.LoanHistoryStatusId == loanApplicationTask.StatusId && x.RoleId == loanApplicationTask.RoleId);
                if (controls == null)
                    throw new RestException(HttpStatusCode.NotFound, "Настройки не найдены");

                var fields = await _dataContext.RoleControlsFields
                    .Where(x => x.RoleControlId == controls.Id)
                    .ToListAsync();

                foreach (var field in fields)
                {
                    if (request.Fields?.ContainsKey(field.Id) ?? false)
                    {
                        await _dataContext.RoleControlsFieldValues.AddAsync(new RoleControlsFieldValue
                        {
                            ApplicationId = loanApplicationTask.ApplicationId,
                            RoleControlsFieldId = field.Id,
                            Value = request.Fields[field.Id]
                        });
                    }
                    else
                        throw new RestException(HttpStatusCode.NotFound, "Поле не найдено");
                }

                await _dataContext.SaveChangesAsync();

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }
    }
}
