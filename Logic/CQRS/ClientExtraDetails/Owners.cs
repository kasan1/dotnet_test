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
using Agro.Shared.Logic.Services.ClientDetails;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.ClientExtraDetails
{
    public class Owners
    {
        public class Query : IRequest<Response<TableData>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<TableData>>
        {
            private readonly DataContext _dataContext;
            private readonly IClientDetailsService _clientDetailsService;

            public QueryHandler(DataContext dataContext, IClientDetailsService clientDetailsService)
            {
                _dataContext = dataContext;
                _clientDetailsService = clientDetailsService;
            }

            public async Task<Response<TableData>> Handle(Query request, CancellationToken cancellationToken)
            {
                var details = await _dataContext.LoanApplicationExtraDetails
                    .FirstOrDefaultAsync(x => x.LoanApplicationId == request.LoanApplicationId, cancellationToken);

                if (details == null)
                    throw new RestException(HttpStatusCode.NotFound, "Дополнительная информация не найдена");

                var ulOwners = await _dataContext.UlOwners
                        .Include(x => x.Organization)
                            .ThenInclude(x => x.Personality)
                                .ThenInclude(p => p.BankAccounts)
                        .Where(x => x.ExtraDetailsId == details.Id)
                        .Select(x => new
                        {
                            x.Id,
                            x.Rate,
                            x.Organization.Personality.FullName,
                            BankAccounts = x.Organization.Personality.BankAccounts.Select(x => new
                            {
                                x.Id,
                                x.BIC,
                                x.Number
                            })
                        })
                        .ToListAsync(cancellationToken);

                var result = new TableData()
                {
                    Header = GenerateUlOwnersTableHeaders()
                };
                if (ulOwners.Any())
                {
                    foreach (var item in ulOwners)
                    {
                        result.Body.Add(new Dictionary<string, object>()
                        {
                            { "fullname", item.FullName },
                            { "rate", item.Rate.ToString("N2") },
                            { "requisites", string.Join("; ", item.BankAccounts.Select(ba => $"Номер счета: {ba.Number}, БИК: {ba.BIC}")) },
                        });
                    }
                }
                else
                {
                    result.Header = GenerateFlOwnersTableHeaders();

                    var flOwners = await _dataContext.FlOwners
                        .Where(x => x.ExtraDetailsId == details.Id)
                        .Select(x => new
                        {
                            x.Id,
                            x.Person.PersonalityId
                        })
                        .ToListAsync(cancellationToken);

                    var personIds = flOwners.Select(x => x.PersonalityId);

                    var people = await _clientDetailsService.GetPeople(personIds);

                    int index = 1;
                    foreach (var flOwnerDto in flOwners)
                    {
                        var person = people.FirstOrDefault(x => x.PersonalityId == flOwnerDto.PersonalityId);
                        if (person != null)
                        {
                            result.Body.Add(new Dictionary<string, object>()
                            {
                                { "index", index++ },
                                { "fullname", person.FullName },
                                { "document", $"{person.IdentificationDocument.Number}, {person.IdentificationDocument.Issuer}, {person.IdentificationDocument.DateIssue:dd.MM.yyyy}" },
                                { "address", $"{person.Address.Fact}" },
                            });
                        }
                    }
                }                

                return Response.Success("Запрос выполнен успешно", result);
            }

            private List<TableHeader> GenerateUlOwnersTableHeaders() => new List<TableHeader>
                    {
                        new TableHeader
                        {
                            Code = "fullname",
                            Name = "Наименование юридического лица/Ф.И.О. физического лица",
                            IsOrderBy = true,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "rate",
                            Name = "%",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "requisites",
                            Name = "Реквизиты",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        }
                    };

            private List<TableHeader> GenerateFlOwnersTableHeaders() => new List<TableHeader>
                    {
                        new TableHeader
                        {
                            Code = "index",
                            Name = "№",
                            IsOrderBy = true,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "fullname",
                            Name = "Ф.И.О. члена КХ/ФХ/ИП",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "document",
                            Name = "Документ, удостоверяющий личность (№ и дата выдачи)",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "address",
                            Name = "Место жительства (фактическое)",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        }
                    };
        }
    }
}
