using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Agro.Shared.Logic.CQRS.Dictionary.DTOs;

namespace Agro.Okaps.Logic.CQRS.Dictionary
{
    public class ListTechTypes
    {
        public class ListQuery : ListFilter, IRequest<Response<ListResponse>>
        {
            public Guid? ParentId { get; set; }
            public Guid? LoanProductId { get; set; }
        }

        public class ListQueryHandler : IRequestHandler<ListQuery, Response<ListResponse>>
        {
            private readonly DataContext _dataContext;
            private readonly string _loanProductNewTechnic = "1";
            public ListQueryHandler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<ListResponse>> Handle(ListQuery request, CancellationToken cancellationToken)
            {
                if (!request.LoanProductId.HasValue)
                    request.LoanProductId = (await _dataContext.DicLoanProducts.FirstOrDefaultAsync(x => x.Code == _loanProductNewTechnic)).Id;

                var query = _dataContext.DicTechTypes
                   .Where(x => !x.IsDeleted && x.DicLoanProductId == request.LoanProductId.Value && x.ParentId == request.ParentId)
                   .AsQueryable();

                var list = await query
                      .AsNoTracking()
                      .OrderBy(x => x.Sort)
                      //.Skip(request.Skip)
                      //.Take(request.PageLimit)
                      .Select(x => new DictionaryDto
                      {
                          Id = x.Id,
                          ParentId = x.ParentId,
                          Code = x.Code,
                          Name = x.GetName()
                      })
                      .ToListAsync();

                return Response.Success("Запрос выполнен успешно", new ListResponse
                {
                    List = list,
                    Count = await query.CountAsync()
                });
            }
        }
    }
}
