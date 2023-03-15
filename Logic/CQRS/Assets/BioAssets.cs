using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.Models.Common;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.Assets
{
    public class BioAssets
    {
        public class Query : IRequest<Response<TableData>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<TableData>>
        {
            private readonly DataContext _dataContext;

            public QueryHandler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<TableData>> Handle(Query request, CancellationToken cancellationToken)
            {
                var bioAssets = await _dataContext.Activities
                    .Include(x => x.LivestockActivities)
                        .ThenInclude(l => l.DicLivestockType)
                    .Where(aa => aa.LoanApplicationId == request.LoanApplicationId)
                    .Select(x => x.LivestockActivities)
                    .FirstOrDefaultAsync();

                var result = new TableData()
                {
                    Header = GenerateTableHeaders()
                };

                if (bioAssets == null)
                    return Response.Success("Запрос выполнен успешно", result);

                foreach (var item in bioAssets)
                {
                    result.Body.Add(new Dictionary<string, object>()
                    {
                        { "name", item.DicLivestockType?.GetName() },
                        { "count", item.Count },
                        { "liveWeightCount", item.LiveWeight },
                        { "slaughterWeightCount", item.SlaughterWeight },
                        { "livePrice", item.LivePrice },
                        { "slaughterPrice", item.SlaughterPrice }
                    });
                }

                return Response.Success("Запрос выполнен успешно", result);
            }

            private List<TableHeader> GenerateTableHeaders() => new List<TableHeader>
                    {
                        new TableHeader
                        {
                            Code = "name",
                            Name = "Наименование",
                            IsOrderBy = true,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "count",
                            Name = "Общее количество",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "liveWeightCount",
                            Name = "Количество в живом весе",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "slaughterWeightCount",
                            Name = "Количество в убойном весе",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "livePrice",
                            Name = "Цена реализации в живом весе, тенге",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "slaughterPrice",
                            Name = "Цена реализации в убойном весе, тенге",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                    };
        }
    }
}
