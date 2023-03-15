using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.Integrations._1C.DTOs;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.CQRS.Common.DTOs;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Agro.Bpm.Logic.CQRS.Integrations._1C
{
    public class Send
    {
        public class Command : IRequest<Response<Unit>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IMediator _mediator;
            private readonly IHttpClientFactory _httpClientFactory;
            
            public Handler(DataContext dataContext, IMediator mediator, IHttpClientFactory httpClientFactory)
            {
                _dataContext = dataContext;
                _mediator = mediator;
                _httpClientFactory = httpClientFactory;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications
                    .Include(x => x.DicLoanType)
                    .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId, cancellationToken);
                if (application == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                var details = await _dataContext.LoanApplicationDetails
                    .Include(x => x.DetailsPersonalities)
                    .FirstOrDefaultAsync(x => x.LoanApplicationId == application.Id, cancellationToken);

                if (details == null)
                    throw new RestException(HttpStatusCode.NotFound, "Данные не найдены");

                #region Контрагент
                var organizationPersonalityId = details.DetailsPersonalities
                    .FirstOrDefault(x => x.PersonalityType == PersonalityTypeEnum.Organization)?.PersonalityId;

                if (organizationPersonalityId == null)
                    throw new RestException(HttpStatusCode.NotFound, "Организация не найдена");

                var headPersonalityId = details.DetailsPersonalities.FirstOrDefault(x => x.PersonalityType == PersonalityTypeEnum.Head)?.PersonalityId;
                if (headPersonalityId == null)
                    throw new RestException(HttpStatusCode.NotFound, "Руководитель не найден");


                var organizationQuery = _dataContext.Organizations
                    .Include(x => x.OKED)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.BankAccounts)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Address)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Phone)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Documents)
                            .ThenInclude(d => d.Document)
                                .ThenInclude(dd => dd.DocumentType)
                    .Include(x=>x.DicOrganizationAndLegalForm)
                    .Include(x=>x.DicTaxTreatment)
                    .Include(x=>x.DicSubjectOfEntrepreneur)
                    .AsQueryable();

                var organization = await organizationQuery.FirstOrDefaultAsync(x => x.PersonalityId == organizationPersonalityId, cancellationToken);

                if (organization == null)
                    throw new RestException(HttpStatusCode.NotFound, "Организация не найдена");

                var affiliatedOrganizations = await organizationQuery
                    .Where(x => x.AffiliatedOrganizatonId == organization.Id)
                    .ToListAsync();

                var company = new Company
                {
                    Id = organization.Id,
                    Identifier = organization.Personality.Identifier,
                    Name = organization.Personality.FullName,
                    TypeOfRelationWithCompany = Guid.Parse("9057ABA8-AB78-4702-92DC-B659B1349291"),
                    RelationWithCompany = Guid.Parse("28D70007-CBF2-4CA1-8AD7-87380C3DF261"),
                    IsResident = true,
                    Address = new DTOs.Address
                    {
                        Region = organization.Personality.RegionId,
                        Fact = organization.Personality.Address.Fact,
                        Register = organization.Personality.Address.Register
                    },
                    BankAccounts = organization.Personality.BankAccounts.Select(b => new BankAccountDto
                    {
                        BIC = b.BIC,
                        Number = b.Number
                    }).ToList(),
                    Oked = organization.OKED.Select(o => new ListItem
                    {
                        Id = o.OkedId
                    }).ToList(),
                    IsPhysical = organization.DicOrganizationAndLegalForm.Value != OrganizationAndLegalFormEnum.Juridical,
                    FormOfLegal = organization.LegalFormId,
                    TaxTreatment = organization.DicTaxTreatment.Code,
                    SubjectOfEntrepreneur = organization.DicSubjectOfEntrepreneur.Code,
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

                var contactPersonalityIds = details.DetailsPersonalities
                    .Where(x => x.PersonalityType == PersonalityTypeEnum.Contact)
                    .Select(x => x.PersonalityId);

                var people = await _dataContext.People
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Address)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Phone)
                    .Include(x => x.Personality)
                        .ThenInclude(p => p.Documents)
                .Where(x => x.PersonalityId == headPersonalityId || contactPersonalityIds.Contains(x.PersonalityId))
                .Select(x => new
                {
                    personalityId = x.PersonalityId,
                    data = new DTOs.Person
                    {
                        Id = x.Id,
                        Identifier = x.Personality.Identifier,
                        FullName = x.Personality.FullName,
                        Email = x.Personality.Email,
                        Birthdate = x.BirthDate,
                        Phone = x.Personality.Phone.Mobile ?? x.Personality.Phone.Home,
                        IdentificationDocument = x.Personality.Documents
                         .Where(d => d.Document.DocumentType.DocumentType == DocumentTypeEnum.Identification)
                         .Select(d => new DocumentDto
                         {
                             Id = d.Document.Id,
                             Issuer = d.Document.Issuer,
                             DateIssue = d.Document.DateIssue,
                             Number = d.Document.Number
                         }).FirstOrDefault(),
                    }
                })
                .ToListAsync(cancellationToken);

                foreach (var person in people)
                {
                    if (person.personalityId == headPersonalityId)
                        company.Head = person.data;
                    else
                        company.Contacts.Add(person.data);
                }
                #endregion

                #region Договора

                var contracts = await _dataContext.Contracts
                    .Include(x => x.Calculator)
                    .Include(x => x.SelectedTechnic)
                    .Include(x => x.SelectedTechnic)
                        .ThenInclude(xx => xx.DicTechModel)
                            .ThenInclude(xxx => xxx.DicTechProduct)
                                .ThenInclude(xxx => xxx.DicTechType)
                    .Include(x => x.SelectedTechnic)
                        .ThenInclude(xx => xx.DicCountry)
                    .Include(x => x.SelectedTechnic)
                        .ThenInclude(xx => xx.DicProvider)
                    .Where(x => x.LoanApplicationId == request.LoanApplicationId)
                    .Select(x => new DTOs.Contract
                    {
                        Id = x.Id,
                        ApplicationId = application.Id,
                        Name = x.Name,
                        Calculator = new DTOs.Calculator
                        {
                            CoFinancing = x.Calculator.CoFinancing,
                            Rate = x.Calculator.Rate,
                            CoFinancingValue = x.Calculator.GetCoFinancingValue()
                        },
                        DateStart = x.CreatedDate,
                        Technic = new Technic
                        {
                            Count = x.SelectedTechnic.Count,
                            Price = x.SelectedTechnic.Price,
                            Country = x.SelectedTechnic.DicCountry.Code,
                            Provider = x.SelectedTechnic.DicProvider.Code,
                            Model = x.SelectedTechnic.DicTechModel.Code,
                            Type = x.SelectedTechnic.DicTechModel.DicTechProduct.DicTechType.Code
                        },
                    }).ToListAsync(cancellationToken);

                var contractIds = contracts.Select(x => x.Id);
                var accessories = await _dataContext.SelectedAccessories
                    .Include(xx => xx.DicTechModel)
                        .ThenInclude(xxx => xxx.DicTechProduct)
                                .ThenInclude(xxx => xxx.DicTechType)
                    .Include(xx => xx.DicCountry)
                    .Include(xx => xx.DicProvider)
                    .Where(x => contractIds.Contains(x.ContractId))
                    .Select(x => new Technic
                    {
                        ContractId = x.ContractId,
                        Count = x.Count,
                        Price = x.Price,
                        Country = x.DicCountry.Code,
                        Provider = x.DicProvider.Code,
                        Model = x.DicTechModel.Code,
                        Type = x.DicTechModel.DicTechProduct.DicTechType.Code
                    })
                    .ToListAsync(cancellationToken);

                var number = 1001;
                foreach(var contract in contracts)
                {
                    contract.Number = $"{number++}";
                    contract.Accessories = accessories.Where(x => x.ContractId == contract.Id).ToList();
                }

                #endregion

                var json = JsonConvert.SerializeObject(new Envelope
                {
                    Contragent = company,
                    Contracts = contracts
                });

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }
    }
}
