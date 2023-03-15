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
    public class ListCountries
    {
        public class ListQuery : ListFilter, IRequest<Response<ListResponse>>
        { 
            public Guid TechModelId { get; set; }
            public decimal? Rate { get; set; }
        }

        public class ListQueryHandler : IRequestHandler<ListQuery, Response<ListResponse>>
        {
            private readonly DataContext _dataContext;

            public ListQueryHandler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<ListResponse>> Handle(ListQuery request, CancellationToken cancellationToken)
            {
                var query = _dataContext.DicCountries
                   .Where(x => !x.IsDeleted && x.DicCountryTechModels.Any(xx => xx.DicTechModelId == request.TechModelId))
                   .AsQueryable();

                if (request.Rate.HasValue)
                    query = query.Where(x => x.DicCountryTechModels.Any(x => x.Rate == request.Rate));

                var list = await query
                      .AsNoTracking()
                      .OrderBy(x => x.Sort)
                      //.Skip(request.Skip)
                      //.Take(request.PageLimit)
                      .Select(x => new DictionaryDto
                      {
                          Id = x.Id,
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
