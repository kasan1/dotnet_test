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
    public class LandAssets
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
                var landAssets = await _dataContext.Activities
                    .Include(x => x.LandActivities)
                        .ThenInclude(l => l.DicLandType)
                    .Include(x => x.LandActivities)
                        .ThenInclude(l => l.DicOwnershipType)
                    .Where(aa => aa.LoanApplicationId == request.LoanApplicationId)
                    .Select(x => x.LandActivities)
                    .FirstOrDefaultAsync();

                var result = new TableData()
                {
                    Header = GenerateTableHeaders()
                };

                if (landAssets == null)
                    return Response.Success("Запрос выполнен успешно", result);

                foreach (var item in landAssets)
                {
                    result.Body.Add(new Dictionary<string, object>()
                    {
                        { "name", item.DicLandType?.GetName() },
                        { "square", item.Square },
                        { "type", item.DicOwnershipType?.GetName() }
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
                            Code = "square",
                            Name = "Площадь",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "type",
                            Name = "Тип собственности",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        }
                    };
        }
    }
}
