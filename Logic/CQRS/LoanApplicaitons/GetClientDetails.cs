using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.LoanApplicaitons.DTOs.ClientDetails;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.LoanApplicaitons
{
    public class GetClientDetails
    {
        public class Query : IRequest<Response<DetailsDto>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<DetailsDto>>
        {
            private readonly DataContext _dataContext;

            public QueryHandler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<DetailsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId);
                if (application == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Заявка не найдена");

                var details = await _dataContext.LoanApplicationDetails
                    .Include(x => x.DetailsPersonalities)
                    .FirstOrDefaultAsync(x => x.LoanApplicationId == application.Id);

                if (details == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Информация не найдена");

                var organizationPersonalityId = details.DetailsPersonalities
                    .FirstOrDefault(x => x.PersonalityType == PersonalityTypeEnum.Organization).PersonalityId;

                if (organizationPersonalityId == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Организация не найдена");

                var organizationQuery = _dataContext.Organizations
                    .Include(x => x.DicOrganizationAndLegalForm)
                    .Include(x => x.DicOwnershipForm)
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
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Организация не найдена");

                var affiliatedOrganizations = await organizationQuery
                    .Where(x => x.AffiliatedOrganizatonId == organization.Id)
                    .ToListAsync();

                var organizationDto = GetOrganization(organization);
                organizationDto.AffiliatedOrganizations = affiliatedOrganizations.Select(x => GetOrganization(x));

                var result = new DetailsDto
                {
                    Id = details.Id,
                    Organization = organizationDto
                };

                var personIds = details.DetailsPersonalities
                    .Where(x => x.PersonalityType != PersonalityTypeEnum.Organization)
                    .Select(x => x.PersonalityId);

                var people = await GetPeople(personIds);

                foreach (var personality in details.DetailsPersonalities)
                {
                    switch (personality.PersonalityType)
                    {
                        case PersonalityTypeEnum.Head:
                            result.Head = people.FirstOrDefault(x => x.PersonalityId == personality.PersonalityId);
                            if (result.Head == null)
                                throw new RestException(System.Net.HttpStatusCode.NotFound, "Руководитель не найден");
                            break;
                        case PersonalityTypeEnum.Booker:
                            result.Booker = people.FirstOrDefault(x => x.PersonalityId == personality.PersonalityId);
                            if (result.Booker == null)
                                throw new RestException(System.Net.HttpStatusCode.NotFound, "Бухгалтер не найден");
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


            private OrganizationDto GetOrganization(Organization organization)
            {
                return new OrganizationDto
                {
                    Id = organization.Id,
                    PersonalityId = organization.Personality.Id,
                    Identifier = organization.Personality.Identifier,
                    FullName = organization.Personality.FullName,
                    Fax = organization.Personality.Fax,
                    Email = organization.Personality.Email,
                    RegionId = organization.Personality.RegionId,
                    Phone = organization.Personality.Phone != null ? new PhoneDto
                    {
                        Id = organization.Personality.Phone.Id,
                        Work = organization.Personality.Phone.Work,
                        Home = organization.Personality.Phone.Home,
                        Mobile = organization.Personality.Phone.Mobile,
                    } : null,
                    Address = organization.Personality.Address != null ? new AddressDto
                    {
                        Id = organization.Personality.Address.Id,
                        Fact = organization.Personality.Address.Fact,
                        Register = organization.Personality.Address.Register
                    } : null,
                    CreditHistory = organization.Personality.CreditHistory.Select(c => new CreditHistoryDto
                    {
                        Id = c.Id,
                        Balance = c.Balance,
                        DateIssue = c.DateIssue,
                        FullName = c.FullName,
                        Period = c.Period,
                        Sum = c.Sum
                    }),
                    Debts = organization.Personality.Depts.Select(d => new DebtDto
                    {
                        Id = d.Id,
                        BIC = d.BIC,
                        Debt = d.Value
                    }),
                    WorkExperience = organization.Personality.WorkExperience != null ? new WorkExperienceDto
                    {
                        Id = organization.Personality.WorkExperience.Id,
                        Agriculture = organization.Personality.WorkExperience.Agriculture,
                        Total = organization.Personality.WorkExperience.Total
                    } : null,
                    BankAccounts = organization.Personality.BankAccounts.Select(b => new BankAccountDto
                    {
                        Id = b.Id,
                        BIC = b.BIC,
                        Number = b.Number
                    }),
                    OKED = organization.OKED?.Where(o => o.DicOKED != null).Select(o => o.DicOKED.NameRu),
                    Parent = organization.Parent,
                    OwnershipForm = organization.DicOwnershipForm?.NameRu,
                    OrganizationType = organization.DicOrganizationAndLegalForm?.NameRu,
                    IsAffiliated = organization.IsAffiliated,
                    ShareInCapital = organization.ShareInCapital,
                    IdentificationDocument = organization.Personality.Documents
                             .Where(d => d.Document.DocumentType.DocumentType == DocumentTypeEnum.Identification)
                             .Select(d => new DocumentDto
                             {
                                 Id = d.Document.Id,
                                 Issuer = d.Document.Issuer,
                                 DateIssue = d.Document.DateIssue,
                                 Number = d.Document.Number
                             }).FirstOrDefault(),
                    RegistrationDocument = organization.Personality.Documents
                             .Where(d => d.Document.DocumentType.DocumentType == DocumentTypeEnum.Registration)
                             .Select(d => new DocumentDto
                             {
                                 Id = d.Document.Id,
                                 Issuer = d.Document.Issuer,
                                 DateIssue = d.Document.DateIssue,
                                 Number = d.Document.Number
                             }).FirstOrDefault()
                };
            }

            private async Task<List<PersonDto>> GetPeople(IEnumerable<Guid> personIds)
            {
                return await _dataContext.People
                    .Include(x => x.DicCountry)
                    .Include(x => x.DicMariageStatus)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Address)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Phone)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Documents)
                    .Where(x => personIds.Contains(x.PersonalityId))
                    .Select(x => new PersonDto
                    {
                        Id = x.Id,
                        PersonalityId = x.PersonalityId,
                        Identifier = x.Personality.Identifier,
                        FullName = x.Personality.FullName,
                        Fax = x.Personality.Fax,
                        Email = x.Personality.Email,
                        RegionId = x.Personality.RegionId,
                        BirthDate = x.BirthDate,
                        BirthPlace = x.BirthPlace,
                        IsResident = x.IsResident,
                        Spouse = x.Spouse,
                        Education = x.Education,
                        WorkExperience = x.Personality.WorkExperience != null ? new WorkExperienceDto
                        {
                            Id = x.Personality.WorkExperience.Id,
                            Agriculture = x.Personality.WorkExperience.Agriculture,
                            Total = x.Personality.WorkExperience.Total
                        } : null,
                        MarriageStatus = x.DicMariageStatus.NameRu,
                        Country = x.DicCountry.NameRu,
                        Phone = new PhoneDto
                        {
                            Id = x.Personality.Phone.Id,
                            Work = x.Personality.Phone.Work,
                            Home = x.Personality.Phone.Home,
                            Mobile = x.Personality.Phone.Mobile,
                        },
                        Address = new AddressDto
                        {
                            Id = x.Personality.Address.Id,
                            Fact = x.Personality.Address.Fact,
                            Register = x.Personality.Address.Register
                        },
                        IdentificationDocument = x.Personality.Documents
                             .Where(d => d.Document.DocumentType.DocumentType == DocumentTypeEnum.Identification)
                             .Select(d => new DocumentDto
                             {
                                 Id = d.Document.Id,
                                 Issuer = d.Document.Issuer,
                                 DateIssue = d.Document.DateIssue,
                                 Number = d.Document.Number
                             }).FirstOrDefault(),
                    })
                    .ToListAsync();
            }
        }
    }
}
