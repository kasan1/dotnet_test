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
    public class FloraAssets
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
                var floraAssets = await _dataContext.Activities
                    .Include(x => x.FloraActivities)
                        .ThenInclude(f => f.FloraCulture)
                    .Include(x => x.FloraActivities)
                        .ThenInclude(f => f.Productivities)
                    .Where(aa => aa.LoanApplicationId == request.LoanApplicationId)
                    .Select(x => x.FloraActivities)
                    .FirstOrDefaultAsync();

                var result = new TableData()
                {
                    Header = GenerateTableHeaders()
                };

                if (floraAssets == null)
                    return Response.Success("Запрос выполнен успешно", result);

                foreach (var item in floraAssets)
                {
                    var productivities = item.Productivities.OrderByDescending(x => x.Year);

                    result.Body.Add(new Dictionary<string, object>()
                    {
                        { "name", item.FloraCulture?.Name },
                        { "plannedSeedSquare", item.PlannedSquare },
                        { "seedRate", item.SeedingRate },
                        { "price", item.PriceRealization },
                        { "expenses", "" },
                        { "productivityCurrentYear", productivities?.FirstOrDefault()?.Value },
                        { "productivityLastYear", productivities?.Skip(1)?.FirstOrDefault()?.Value },
                        { "productivityBeforeLastYear", productivities?.Skip(2)?.FirstOrDefault()?.Value },
                    });
                }

                return Response.Success("Запрос выполнен успешно", result);
            }

            private List<TableHeader> GenerateTableHeaders() => new List<TableHeader>
                    {
                        new TableHeader
                        {
                            Code = "name",
                            Name = "Наименование культуры",
                            IsOrderBy = true,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "plannedSeedSquare",
                            Name = "Планируемая площадь посевов, га",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "seedRate",
                            Name = "Норма посева, кг на 1 га",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "price",
                            Name = "Цена реализации, за 1 тонну",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "expenses",
                            Name = "Затраты",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "productivityCurrentYear",
                            Name = "Урожайность за текущий год",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "productivityLastYear",
                            Name = "Урожайность 1 год назад",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "productivityBeforeLastYear",
                            Name = "Урожайность 2 года назад",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                    };
        }
    }
}
