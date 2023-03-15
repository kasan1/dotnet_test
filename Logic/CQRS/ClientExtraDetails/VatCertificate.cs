using System;
using System.Collections.Generic;
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
    public class VatCertificate
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
                    .Include(x => x.VatCertificate)
                    .FirstOrDefaultAsync(x => x.LoanApplicationId == request.LoanApplicationId, cancellationToken);

                if (details == null)
                    throw new RestException(HttpStatusCode.NotFound, "Дополнительная информация не найдена");                

                var result = new TableData()
                {
                    Header = GenerateTableHeaders()
                };

                if (details.VatCertificate == null)
                    return Response.Success("Запрос выполнен успешно", result);

                result.Body.Add(new Dictionary<string, object>()
                        {
                            { "document", $"{details.VatCertificate.Number}, {details.VatCertificate.DateIssue:dd.MM.yyyy}" },
                            { "issuer", details.VatCertificate.Issuer }
                        });

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
                        }
                    };
        }
    }
}
