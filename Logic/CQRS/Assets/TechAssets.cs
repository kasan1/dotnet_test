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
    public class TechAssets
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
                var techAssets = await _dataContext.Activities
                    .Include(x=>x.TechnicActivities)
                    .Where(aa => aa.LoanApplicationId == request.LoanApplicationId)
                    .Select(x => x.TechnicActivities)
                    .FirstOrDefaultAsync();

                var result = new TableData()
                {
                    Header = GenerateTableHeaders()
                };

                if (techAssets == null)
                    return Response.Success("Запрос выполнен успешно", result);

                foreach (var item in techAssets)
                {
                    result.Body.Add(new Dictionary<string, object>()
                    {
                        { "name", item.Fullname },
                        { "date", item.DateIssue.ToString("dd.MM.yyyy") },
                        { "count", item.Count },
                        { "countOfWorking", item.CountOfCorrect },
                        { "encumbrances", item.IsPledged ? "Да" : "Нет" },
                        { "reason", item.PledgeDescription }
                    });
                }

                return Response.Success("Запрос выполнен успешно", result);
            }

            private List<TableHeader> GenerateTableHeaders() => new List<TableHeader>
                    {
                        new TableHeader
                        {
                            Code = "name",
                            Name = "Наименование собственной техники (оборудования), здания, сооружения, автотранспорта и т.д. имеющихся в наличии",
                            IsOrderBy = true,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "date",
                            Name = "Год выпуска",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "count",
                            Name = "Количество",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "countOfWorking",
                            Name = "Количество в исправном состоянии",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "encumbrances",
                            Name = "Обременение",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "reason",
                            Name = "Кому и за что заложено",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        }
                    };
        }
    }
}
