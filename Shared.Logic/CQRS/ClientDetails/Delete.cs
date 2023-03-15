using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Okaps.Logic.CQRS.ClientDetails
{
    public class Delete
    {
        public class DeleteDetailsCommand : IRequest<Response<Unit>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class ListQueryHandler : IRequestHandler<DeleteDetailsCommand, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            
            public ListQueryHandler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<Unit>> Handle(DeleteDetailsCommand request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId);
                if (application == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Заявка не найдена");

                var details = await _dataContext.LoanApplicationDetails.FirstOrDefaultAsync(x => x.LoanApplicationId == application.Id);
                _dataContext.LoanApplicationDetails.Remove(details);
                await _dataContext.SaveChangesAsync();

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }
    }
}
