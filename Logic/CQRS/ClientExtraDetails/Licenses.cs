using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.Models.Common;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.ClientExtraDetails
{
    public class Licenses
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
                var details = await _dataContext.LoanApplicationExtraDetails
                    .FirstOrDefaultAsync(x => x.LoanApplicationId == request.LoanApplicationId, cancellationToken);

                if (details == null)
                    throw new RestException(HttpStatusCode.NotFound, "Дополнительная информация не найдена");

                var licenses = await _dataContext.Licenses
                        .Include(x => x.Document)
                        .Where(x => x.ExtraDetailsId == details.Id)
                        .Select(x => new
                        {
                            x.Id,
                            x.Essence,
                            x.Document
                        })
                        .ToListAsync(cancellationToken);

                var result = new TableData()
                {
                    Header = GenerateTableHeaders()
                };

                if (licenses == null)
                    return Response.Success("Запрос выполнен успешно", result);

                foreach (var item in licenses)
                {
                    result.Body.Add(new Dictionary<string, object>()
                        {
                            { "document", $"{item.Document.Number}, {item.Document.DateIssue:dd.MM.yyyy}" },
                            { "issuer", item.Document.Issuer },
                            { "essence", item.Essence },
                        });
                }

                return Response.Success("Запрос выполнен успешно", result);
            }

            private List<TableHeader> GenerateTableHeaders() => new List<TableHeader>
                    {
                        new TableHeader
                        {
                            Code = "document",
                            Name = "№ и дата выдачи лицензии",
                            IsOrderBy = true,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "issuer",
                            Name = "Орган, выдавший лицензию",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "essence",
                            Name = "Суть лицензии (на что выдана)",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        }
                    };
        }
    }
}
