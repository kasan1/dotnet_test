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
using Agro.Shared.Logic.CQRS.ClientDetails.DTOs;

namespace Agro.Shared.Logic.CQRS.ClientDetails
{
    public class Details
    {
        public class Query : IRequest<Response<DetailsDto>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<DetailsDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IClientDetailsService _clientDetailsService;

            public QueryHandler(DataContext dataContext, IClientDetailsService clientDetailsService)
            {
                _dataContext = dataContext;
                _clientDetailsService = clientDetailsService;
            }

            public async Task<Response<DetailsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications
                    .Include(x => x.DicLoanType)
                    .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId);
                if (application == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                var details = await _dataContext.LoanApplicationDetails
                    .Include(x => x.DetailsPersonalities)
                    .FirstOrDefaultAsync(x => x.LoanApplicationId == application.Id);

                if (details == null)
                {
                    return Response.Success("Запрос выполнен успешно", new DetailsDto
                    {
                        Id = null,
                        IsReadOnly = application.Status != ApplicationTypeEnum.Temp,
                        LoanType = application.DicLoanType.Value
                    });
                }

                var organizationPersonalityId = details.DetailsPersonalities
                    .FirstOrDefault(x => x.PersonalityType == PersonalityTypeEnum.Organization).PersonalityId;

                if (organizationPersonalityId == null)
                    throw new RestException(HttpStatusCode.NotFound, "Организация не найдена");

                var organizationQuery = _dataContext.Organizations
                    .Include(x => x.OKED)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.BankAccounts)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Address)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Phone)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.WorkExperience)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.CreditHistory)
                     .Include(x => x.Personality)
                        .ThenInclude(p => p.Depts)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Documents)
                            .ThenInclude(d => d.Document)
                                .ThenInclude(dd => dd.DocumentType)
                    .AsQueryable();

                var organization = await organizationQuery.FirstOrDefaultAsync(x => x.PersonalityId == organizationPersonalityId);

                if (organization == null)
                    throw new RestException(HttpStatusCode.NotFound, "Организация не найдена");

                var affiliatedOrganizations = await organizationQuery
                    .Where(x => x.AffiliatedOrganizatonId == organization.Id)
                    .ToListAsync();

                var organizationDto = _clientDetailsService.GetOrganization(organization);
                organizationDto.AffiliatedOrganizations = affiliatedOrganizations.Select(x => _clientDetailsService.GetOrganization(x));

                var result = new DetailsDto
                {
                    Id = details.Id,
                    IsReadOnly = application.Status != ApplicationTypeEnum.Temp,
                    LoanType = application.DicLoanType.Value,
                    Organization = organizationDto
                };

                var personIds = details.DetailsPersonalities
                    .Where(x => x.PersonalityType != PersonalityTypeEnum.Organization)
                    .Select(x => x.PersonalityId);

                var people = await _clientDetailsService.GetPeople(personIds);

                foreach (var personality in details.DetailsPersonalities)
                {
                    switch (personality.PersonalityType)
                    {
                        case PersonalityTypeEnum.Head:
                            result.Head = people.FirstOrDefault(x => x.PersonalityId == personality.PersonalityId);
                            if (result.Head == null)
                                throw new RestException(HttpStatusCode.NotFound, "Руководитель не найден");
                            break;
                        case PersonalityTypeEnum.Booker:
                            result.Booker = people.FirstOrDefault(x => x.PersonalityId == personality.PersonalityId);
                            if (result.Booker == null)
                                throw new RestException(HttpStatusCode.NotFound, "Бухгалтер не найден");
                            break;
                        case PersonalityTypeEnum.Beneficiary:
                            result.Beneficiary = people.FirstOrDefault(x => x.PersonalityId == personality.PersonalityId);
                            break;
                        case PersonalityTypeEnum.Representative:
                            result.Representative = people.FirstOrDefault(x => x.PersonalityId == personality.PersonalityId);
                            break;
                        case PersonalityTypeEnum.Contact:
                            var contactDto = people.FirstOrDefault(x => x.PersonalityId == personality.PersonalityId);
                            if (contactDto != null)
                                result.Contacts.Add(contactDto);
                            break;
                        default:
                            break;
                    }
                }

                return Response.Success("Запрос выполнен успешно", result);
            }


            
        }
    }
}
