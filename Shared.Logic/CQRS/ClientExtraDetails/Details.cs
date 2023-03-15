using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Agro.Shared.Logic.Services.ClientDetails;
using Agro.Shared.Logic.CQRS.ClientExtraDetails.DTOs;
using Agro.Shared.Logic.CQRS.Common.DTOs;

namespace Agro.Shared.Logic.CQRS.ClientExtraDetails
{
    public class Details
    {
        public class Query : IRequest<Response<ExtraDetailsDto>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<ExtraDetailsDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IClientDetailsService _clientDetailsService;

            public QueryHandler(DataContext dataContext, IClientDetailsService clientDetailsService)
            {
                _dataContext = dataContext;
                _clientDetailsService = clientDetailsService;
            }

            public async Task<Response<ExtraDetailsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications
                    .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId);
                if (application == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                var details = await _dataContext.LoanApplicationExtraDetails
                        .Include(x => x.VatCertificate)
                    .Where(x => x.LoanApplicationId == application.Id)
                    .Select(x => new ExtraDetailsDto {
                        Id = x.Id,
                        IsReadOnly = application.Status != ApplicationTypeEnum.Temp,
                        VatCertificate = x.VatCertificate != null ? new DocumentDto(x.VatCertificate) : null
                    })
                    .FirstOrDefaultAsync(cancellationToken);

                if (details == null)
                    throw new RestException(HttpStatusCode.NotFound, "Дополнительная информация не найдена");

                details.UlOwners = await _dataContext.UlOwners
                        .Include(x => x.Organization)
                            .ThenInclude(x => x.Personality)
                                .ThenInclude(p => p.BankAccounts)
                        .Where(x => x.ExtraDetailsId == details.Id)
                        .Select(x => new UlOwnerDto
                        {
                            Id = x.Id,
                            Rate = x.Rate,
                            FullName = x.Organization.Personality.FullName,
                            BankAccounts = x.Organization.Personality.BankAccounts.Select(x => new BankAccountDto
                            {
                                Id = x.Id,
                                BIC = x.BIC,
                                Number = x.Number
                            })
                        })
                        .ToListAsync(cancellationToken);

                details.FlOwners = await _dataContext.FlOwners
                        .Where(x => x.ExtraDetailsId == details.Id)
                        .Select(x => new FlOwnerDto
                        {
                            Id = x.Id,
                            PersonId = x.Person.PersonalityId
                        })
                        .ToListAsync(cancellationToken);

                var personIds = details.FlOwners.Select(x => x.PersonId.Value);

                var people = await _clientDetailsService.GetPeople(personIds);

                foreach (var flOwnerDto in details.FlOwners)
                {
                    var person = people.FirstOrDefault(x => x.PersonalityId == flOwnerDto.PersonId);
                    flOwnerDto.FullName = person?.FullName;
                    flOwnerDto.Address = person?.Address;
                    flOwnerDto.IdentificationDocument = person?.IdentificationDocument;
                }

                details.Licenses = await _dataContext.Licenses
                        .Include(x => x.Document)
                        .Where(x => x.ExtraDetailsId == details.Id)
                        .Select(x => new LicenseDto
                        {
                            Id = x.Id,
                            Essence = x.Essence,
                            Document = new DocumentDto(x.Document)
                        })
                        .ToListAsync(cancellationToken);

                return Response.Success("Запрос выполнен успешно", details);
            }


            
        }
    }
}
