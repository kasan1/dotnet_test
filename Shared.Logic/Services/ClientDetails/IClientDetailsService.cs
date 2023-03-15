using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Context.LoanApplications;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.CQRS.ClientDetails.DTOs;
using Agro.Shared.Logic.CQRS.Common.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Z.EntityFramework.Plus;

namespace Agro.Shared.Logic.Services.ClientDetails
{
    public interface IClientDetailsService
    {
        /// <summary>
        /// Инициализация справочников
        /// </summary>
        Task Init(IEnumerable<Guid> OKEDIds = null, IEnumerable<Guid?> regionIds = null, CancellationToken cancellation = default);
        Task<Organization> CreateOrUpdateOrganizationAsync(OrganizationDto organizationDto);
        Task<Organization> CreateOrUpdateOrganizationAsync(OwnerOrganizationDto organizationDto, CancellationToken cancellation);
        Task<Person> CreateOrUpdatePersonAsync(PersonDto personDto);

        Task<Guid> CreateOrUpdateDocumentAsync(DocumentDto documentDto, DocumentTypeEnum documentTypeEnum);

        OrganizationDto GetOrganization(Organization organization);
        Task<List<PersonDto>> GetPeople(IEnumerable<Guid> personIds);
    }
    public class ClientDetailsService: IClientDetailsService
    {
        private readonly DataContext _dataContext;
        private List<DicMariageStatus> _dicMariageStatuses;
        private List<DicOwnershipForm> _dicOwnershipForms;
        private List<DicOrganizationAndLegalForm> _dicLegalForms;
        private List<DicTaxTreatment> _dicTaxTreatments;
        private List<DicSubjectOfEntrepreneur> _dicSubjectOfEntrepreneur;
        private List<DicDocumentType> _dicDocumentTypes;
        private List<DicOKED> _dicOKED;
        private List<DicRegion> _dicRegion;

        public ClientDetailsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task Init(IEnumerable<Guid> OKEDIds = null, IEnumerable<Guid?> regionIds = null, CancellationToken cancellationToken = default)
        {
            _dicDocumentTypes = await _dataContext.DicDocumentTypes.ToListAsync(cancellationToken);
            _dicRegion = (regionIds?.Any() ?? false) ? await _dataContext.DicRegions.Where(x => !x.IsDeleted && regionIds.Contains(x.Id)).ToListAsync()
                                                     : new List<DicRegion>();

            _dicMariageStatuses = await _dataContext.DicMariageStatuses.ToListAsync(cancellationToken);
            _dicOwnershipForms = await _dataContext.DicOwnershipForms.ToListAsync(cancellationToken);
            _dicLegalForms = await _dataContext.DicOrganizationAndLegalForms.ToListAsync(cancellationToken);
            _dicOKED = (OKEDIds?.Any() ?? false) ? await _dataContext.DicOKED.Where(x => OKEDIds.Contains(x.Id)).ToListAsync(cancellationToken)
                                                 : new List<DicOKED>();
            _dicDocumentTypes = await _dataContext.DicDocumentTypes.ToListAsync(cancellationToken);
            _dicSubjectOfEntrepreneur = await _dataContext.DicSubjectOfEntrepreneur.ToListAsync(cancellationToken);
            _dicTaxTreatments = await _dataContext.DicTaxTreatments.ToListAsync(cancellationToken);
        }

        public OrganizationDto GetOrganization(Organization organization)
        {
            return new OrganizationDto
            {
                Id = organization.Id,
                PersonalityId = organization.Personality.Id,
                Identifier = organization.Personality.Identifier,
                FullName = organization.Personality.FullName,
                Fax = organization.Personality.Fax,
                Email = organization.Personality.Email,
                RegisteredDate = organization.RegisteredDate,
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
                OKED = organization.OKED.Select(o => o.OkedId),
                Parent = organization.Parent,
                OwnershipFormId = organization.OwnershipFormId,
                TaxTreatmentId = organization.TaxTreatmentId,
                LegalFormId = organization.LegalFormId,
                SubjectOfEntrepreneurId = organization.SubjectOfEntrepreneurId,
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
                         }).FirstOrDefault(),
                Head = new PersonDto
                {
                    Identifier = organization.HeadIdentifier,
                    FullName = organization.HeadFullName
                }
            };
        }

        public async Task<List<PersonDto>> GetPeople(IEnumerable<Guid> personIds)
        {
            return await _dataContext.People
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
                    MarriageStatusId = x.MariageStatusId,
                    CountryId = x.CountryId,
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

        public async Task<Organization> CreateOrUpdateOrganizationAsync(OrganizationDto organizationDto)
        {
            if (organizationDto == null)
                throw new RestException(HttpStatusCode.BadRequest, "Пожалуйста заполните данные об организации");

            var legalForm = _dicLegalForms.FirstOrDefault(x => x.Id == organizationDto.LegalFormId);
            if (legalForm == null)
                throw new RestException(HttpStatusCode.NotFound, "Справочник опф не найден");

            if (legalForm.Value == OrganizationAndLegalFormEnum.Juridical && !_dicOwnershipForms.Any(x => x.Id == organizationDto.OwnershipFormId))
                throw new RestException(HttpStatusCode.NotFound, "Справочник форма собственности не найден");

            if (!_dicTaxTreatments.Any(x => x.Id == organizationDto.TaxTreatmentId))
                throw new RestException(HttpStatusCode.NotFound, "Справочник налоговый режим не найден");

            if (!_dicSubjectOfEntrepreneur.Any(x => x.Id == organizationDto.SubjectOfEntrepreneurId))
                throw new RestException(HttpStatusCode.NotFound, "Справочник субъект предпринимательства не найден");

            Organization organization;
            var okedToRemove = new HashSet<Guid>();
            var bankAccountsToRemove = new HashSet<Guid>();
            var debtsToRemove = new HashSet<Guid>();
            var creditHistoriesToRemove = new HashSet<Guid>();
            var affiliatedOrganizationsToRemove = new HashSet<Guid>();
            if (organizationDto.Id.HasValue)
            {
                organization = await _dataContext.Organizations
                    .Include(x => x.OKED)
                    .FirstOrDefaultAsync(x => x.Id == organizationDto.Id.Value);

                if (organization == null)
                    throw new RestException(HttpStatusCode.NotFound, "Организация не найдена");

                okedToRemove = _dataContext.OrganizationOKED.Where(x => x.OrganizationId == organization.Id).Select(x => x.Id).ToHashSet();
                bankAccountsToRemove = _dataContext.BankAccounts.Where(x => x.PersonalityId == organization.PersonalityId).Select(x => x.Id).ToHashSet();
                debtsToRemove = _dataContext.PersonalityDepts.Where(x => x.PersonalityId == organization.PersonalityId).Select(x => x.Id).ToHashSet();
                creditHistoriesToRemove = _dataContext.CreditHistory.Where(x => x.PersonalityId == organization.PersonalityId).Select(x => x.Id).ToHashSet();
                affiliatedOrganizationsToRemove = _dataContext.Organizations.Where(x => x.AffiliatedOrganizatonId == organization.Id).Select(x => x.Id).ToHashSet();
            }
            else
            {
                organization = new Organization
                {
                    Id = Guid.NewGuid()
                };
            }

            organization.PersonalityId = await CreateOrUpdatePersonalityAsync(organizationDto, organization.PersonalityId);
            organization.OwnershipFormId = organizationDto.OwnershipFormId;
            organization.LegalFormId = organizationDto.LegalFormId;
            organization.SubjectOfEntrepreneurId = organizationDto.SubjectOfEntrepreneurId;
            organization.TaxTreatmentId = organizationDto.TaxTreatmentId;
            organization.IsAffiliated = organizationDto.IsAffiliated;
            organization.Parent = organizationDto.Parent;
            organization.ShareInCapital = organizationDto.ShareInCapital;
            organization.RegisteredDate = organizationDto.RegisteredDate;

            if (organizationDto.Id.HasValue)
                _dataContext.Organizations.Update(organization);
            else
                await _dataContext.Organizations.AddAsync(organization);

            if (organizationDto.RegistrationDocument != null)
            {
                await CreateOrUpdatePersonalityDocumentAsync(organizationDto.RegistrationDocument, DocumentTypeEnum.Registration, organization.PersonalityId);
            }

            foreach (var okedId in organizationDto.OKED)
            {
                if (!_dicOKED.Any(x => x.Id == okedId))
                    throw new RestException(HttpStatusCode.NotFound, "Справочник ОКЭД не найден");

                var organisationOked = organization.OKED?.FirstOrDefault(x => x.OkedId == okedId);
                if (organisationOked == null)
                {
                    organisationOked = new OrganizationOKED
                    {
                        Id = Guid.NewGuid(),
                        OkedId = okedId,
                        OrganizationId = organization.Id,
                    };

                    await _dataContext.OrganizationOKED.AddAsync(organisationOked);
                }
                okedToRemove.Remove(organisationOked.Id);
            }
            _dataContext.OrganizationOKED.Where(x => okedToRemove.Contains(x.Id)).Delete();

            if (organizationDto.BankAccounts != null)
            {
                foreach (var bankAccount in organizationDto.BankAccounts)
                {
                    if (bankAccount.Id.HasValue)
                        bankAccountsToRemove.Remove(bankAccount.Id.Value);

                    await CreateOrUpdateBankAccountAsync(bankAccount, organization.PersonalityId);
                }
                _dataContext.BankAccounts.Where(x => bankAccountsToRemove.Contains(x.Id)).Delete();
            }

            if (organizationDto.Debts != null)
            {
                foreach (var debt in organizationDto.Debts)
                {
                    if (debt.Id.HasValue)
                        debtsToRemove.Remove(debt.Id.Value);

                    await CreateOrUpdateDebtAsync(debt, organization.PersonalityId);
                }
                _dataContext.PersonalityDepts.Where(x => debtsToRemove.Contains(x.Id)).Delete();
            }

            if (organizationDto.CreditHistory != null)
            {
                foreach (var creditHistory in organizationDto.CreditHistory)
                {
                    if (creditHistory.Id.HasValue)
                        creditHistoriesToRemove.Remove(creditHistory.Id.Value);

                    await CreateOrUpdateCreditHistoryAsync(creditHistory, organization.PersonalityId);
                }
                _dataContext.CreditHistory.Where(x => creditHistoriesToRemove.Contains(x.Id)).Delete();
            }

            if (organizationDto.AffiliatedOrganizations != null)
            {
                foreach (var affiliatedOrganization in organizationDto.AffiliatedOrganizations)
                {
                    if (affiliatedOrganization.Id.HasValue)
                        affiliatedOrganizationsToRemove.Remove(affiliatedOrganization.Id.Value);

                    await CreateOrUpdateAffiliatedOrganizationAsync(affiliatedOrganization, organization.Id);
                }
                _dataContext.Organizations.Where(x => affiliatedOrganizationsToRemove.Contains(x.Id)).Delete();
            }

            await _dataContext.SaveChangesAsync();

            return organization;
        }

        public async Task<Person> CreateOrUpdatePersonAsync(PersonDto personDto)
        {
            if (personDto == null)
                throw new RestException(HttpStatusCode.BadRequest, "Пожалуйста заполните персональные данные");

            if (personDto.MarriageStatusId.HasValue && !_dicMariageStatuses.Any(x => x.Id == personDto.MarriageStatusId))
                throw new RestException(HttpStatusCode.NotFound, "Справочник статус о браке не найден");

            Person person;
            if (personDto.Id.HasValue)
            {
                person = await _dataContext.People.FindAsync(personDto.Id.Value);
                if (person == null)
                    throw new RestException(HttpStatusCode.NotFound, "Человек не найден");
            }
            else
            {
                person = new Person
                {
                    Id = Guid.NewGuid(),
                };
            }

            person.BirthDate = personDto.BirthDate;
            person.BirthPlace = personDto.BirthPlace;
            person.IsResident = personDto.IsResident;
            person.CountryId = personDto.CountryId;
            person.MariageStatusId = personDto.MarriageStatusId;
            person.Spouse = personDto.Spouse;
            person.Education = personDto.Education;
            person.PersonalityId = await CreateOrUpdatePersonalityAsync(personDto, person.PersonalityId);

            if (personDto.Id.HasValue)
                _dataContext.People.Update(person);
            else
                await _dataContext.People.AddAsync(person);

            await _dataContext.SaveChangesAsync();

            return person;
        }

        public async Task<Guid> CreateOrUpdatePersonalityAsync(PersonalityBaseDto personalityDto, Guid? personalityId)
        {
            if (personalityDto.RegionId.HasValue && !_dicRegion.Any(x => x.Id == personalityDto.RegionId))
                throw new RestException(HttpStatusCode.NotFound, "Справочник регион не найден");

            Personality personality = null;
            if (personalityId.HasValue && personalityId != Guid.Empty)
            {
                personality = await _dataContext.Personalities.FindAsync(personalityId);
                if (personality == null)
                    throw new RestException(HttpStatusCode.NotFound, "Персональность не найдена");
            }
            else
            {
                personality = new Personality
                {
                    Id = Guid.NewGuid()
                };
            }

            personality.Identifier = personalityDto.Identifier;
            personality.Email = personalityDto.Email;
            personality.FullName = personalityDto.FullName;
            personality.Fax = personalityDto.Fax;
            personality.RegionId = personalityDto.RegionId;

            if (personalityId.HasValue && personalityId != Guid.Empty)
                _dataContext.Personalities.Update(personality);
            else
                await _dataContext.Personalities.AddAsync(personality);

            if (personalityDto.Address != null)
                personality.AddressId = await CreateOrUpdateAddressAsync(personalityDto.Address);

            if (personalityDto.Phone != null)
                personality.PhoneId = await CreatePhoneAsync(personalityDto.Phone);

            if (personalityDto.WorkExperience != null)
                personality.WorkExperienceId = await CreateOrUpdateWorkExperienceAsync(personalityDto.WorkExperience);

            if (personalityDto.IdentificationDocument != null)
            {
                await CreateOrUpdatePersonalityDocumentAsync(personalityDto.IdentificationDocument, DocumentTypeEnum.Identification, personality.Id);
            }

            await _dataContext.SaveChangesAsync();

            return personality.Id;
        }

        private async Task CreateOrUpdateBankAccountAsync(BankAccountDto bankAccountDto, Guid personalityId)
        {
            BankAccount bankAccount;
            if (bankAccountDto.Id.HasValue)
            {
                bankAccount = await _dataContext.BankAccounts.FindAsync(bankAccountDto.Id.Value);
                if (bankAccount == null)
                    throw new RestException(HttpStatusCode.NotFound, "Банковский аккаунт не найден");
            }
            else
            {
                bankAccount = new BankAccount
                {
                    Id = Guid.NewGuid(),
                    PersonalityId = personalityId
                };
            }

            bankAccount.BIC = bankAccountDto.BIC;
            bankAccount.Number = bankAccountDto.Number;

            if (bankAccountDto.Id.HasValue)
                _dataContext.BankAccounts.Update(bankAccount);
            else
                await _dataContext.BankAccounts.AddAsync(bankAccount);
        }

        private async Task CreateOrUpdateDebtAsync(DebtDto debtDto, Guid personalityId)
        {
            Dept debt;
            if (debtDto.Id.HasValue)
            {
                debt = await _dataContext.PersonalityDepts.FindAsync(debtDto.Id.Value);
                if (debt == null)
                    throw new RestException(HttpStatusCode.NotFound, "Долг не найден");
            }
            else
            {
                debt = new Dept
                {
                    Id = Guid.NewGuid(),
                    PersonalityId = personalityId
                };
            }

            debt.BIC = debtDto.BIC;
            debt.Value = debtDto.Debt;

            if (debtDto.Id.HasValue)
                _dataContext.PersonalityDepts.Update(debt);
            else
                await _dataContext.PersonalityDepts.AddAsync(debt);
        }

        private async Task CreateOrUpdateCreditHistoryAsync(CreditHistoryDto creditHistoryDto, Guid personalityId)
        {
            CreditHistory creditHistory;
            if (creditHistoryDto.Id.HasValue)
            {
                creditHistory = await _dataContext.CreditHistory.FindAsync(creditHistoryDto.Id.Value);
                if (creditHistory == null)
                    throw new RestException(HttpStatusCode.NotFound, "Кредитная история не найдена");
            }
            else
            {
                creditHistory = new CreditHistory
                {
                    Id = Guid.NewGuid(),
                    PersonalityId = personalityId
                };
            }

            creditHistory.DateIssue = creditHistoryDto.DateIssue;
            creditHistory.Balance = creditHistoryDto.Balance;
            creditHistory.FullName = creditHistoryDto.FullName;
            creditHistory.Period = creditHistoryDto.Period;
            creditHistory.Sum = creditHistoryDto.Sum;

            if (creditHistoryDto.Id.HasValue)
                _dataContext.CreditHistory.Update(creditHistory);
            else
                await _dataContext.CreditHistory.AddAsync(creditHistory);
        }

        private async Task<Organization> CreateOrUpdateAffiliatedOrganizationAsync(OrganizationDto organizationDto, Guid organizationId)
        {
            Organization organization;
            if (organizationDto.Id.HasValue)
            {
                organization = await _dataContext.Organizations.FindAsync(organizationDto.Id.Value);
                if (organization == null)
                    throw new RestException(HttpStatusCode.NotFound, "Организация не найден");
            }
            else
            {
                organization = new Organization
                {
                    Id = Guid.NewGuid(),
                };
            }

            organization.PersonalityId = await CreateOrUpdatePersonalityAsync(organizationDto, organization.PersonalityId);
            organization.IsAffiliated = false;
            organization.Parent = organizationDto.Parent;
            organization.ShareInCapital = organizationDto.ShareInCapital;
            organization.AffiliatedOrganizatonId = organizationId;
            organization.HeadIdentifier = organizationDto.Head.Identifier;
            organization.HeadFullName = organizationDto.Head.FullName;

            if (organizationDto.Id.HasValue)
                _dataContext.Organizations.Update(organization);
            else
                await _dataContext.Organizations.AddAsync(organization);

            foreach (var bankAccount in organizationDto.BankAccounts)
            {
                await CreateOrUpdateBankAccountAsync(bankAccount, organization.PersonalityId);
            }

            foreach (var dept in organizationDto.Debts)
            {
                await CreateOrUpdateDebtAsync(dept, organization.PersonalityId);
            }

            await _dataContext.SaveChangesAsync();

            return organization;
        }

        private async Task<Guid> CreateOrUpdateAddressAsync(AddressDto addressDto)
        {
            Address address;
            if (addressDto.Id.HasValue)
            {
                address = await _dataContext.Addresses.FindAsync(addressDto.Id.Value);
                if (address == null)
                    throw new RestException(HttpStatusCode.NotFound, "Адрес не найден");
            }
            else
            {
                address = new Address
                {
                    Id = Guid.NewGuid()
                };
            }

            address.Fact = addressDto.Fact;
            address.Register = addressDto.Register;

            if (addressDto.Id.HasValue)
                _dataContext.Addresses.Update(address);
            else
                await _dataContext.Addresses.AddAsync(address);

            return address.Id;
        }

        private async Task<Guid> CreatePhoneAsync(PhoneDto phoneDto)
        {
            Phone phone;
            if (phoneDto.Id.HasValue)
            {
                phone = await _dataContext.Phones.FindAsync(phoneDto.Id.Value);
                if (phone == null)
                    throw new RestException(HttpStatusCode.NotFound, "Номер телефона не найден");
            }
            else
            {
                phone = new Phone
                {
                    Id = Guid.NewGuid()
                };
            }

            phone.Home = phoneDto.Home;
            phone.Mobile = phoneDto.Mobile;
            phone.Work = phoneDto.Work;

            if (phoneDto.Id.HasValue)
                _dataContext.Phones.Update(phone);
            else
                await _dataContext.Phones.AddAsync(phone);

            return phone.Id;
        }

        public async Task<Guid> CreateOrUpdateWorkExperienceAsync(WorkExperienceDto workExperienceDto)
        {
            WorkExperience workExperience;
            if (workExperienceDto.Id.HasValue)
            {
                workExperience = await _dataContext.WorkExperiences.FindAsync(workExperienceDto.Id.Value);
                if (workExperience == null)
                    throw new RestException(HttpStatusCode.NotFound, "Опыт работы не найден");
            }
            else
            {
                workExperience = new WorkExperience
                {
                    Id = Guid.NewGuid()
                };
            }

            workExperience.Total = workExperienceDto.Total;
            workExperience.Agriculture = workExperienceDto.Agriculture;

            if (workExperienceDto.Id.HasValue)
                _dataContext.WorkExperiences.Update(workExperience);
            else
                await _dataContext.WorkExperiences.AddAsync(workExperience);

            return workExperience.Id;
        }

        private async Task CreateOrUpdatePersonalityDocumentAsync(DocumentDto documentDto, DocumentTypeEnum documentType, Guid personalityId)
        {
            PersonalityDocument personalityDocument;
            if (documentDto.Id.HasValue)
            {
                personalityDocument = await _dataContext.PersonalityDocuments.FirstOrDefaultAsync(x => x.DocumentId == documentDto.Id.Value && x.PersonalityId == personalityId);
                if (personalityDocument == null)
                    throw new RestException(HttpStatusCode.NotFound, "Идентификационный/Регистрационный документ не найдена");
            }
            else
            {
                personalityDocument = new PersonalityDocument
                {
                    Id = Guid.NewGuid(),
                    PersonalityId = personalityId
                };
            }

            personalityDocument.DocumentId = await CreateOrUpdateDocumentAsync(documentDto, documentType);

            if (documentDto.Id.HasValue)
                _dataContext.PersonalityDocuments.Update(personalityDocument);
            else
                await _dataContext.PersonalityDocuments.AddAsync(personalityDocument);
        }

        public async Task<Guid> CreateOrUpdateDocumentAsync(DocumentDto documentDto, DocumentTypeEnum documentTypeEnum)
        {
            var documentType = _dicDocumentTypes.FirstOrDefault(x => x.DocumentType == documentTypeEnum);
            if (documentType == null)
                throw new RestException(HttpStatusCode.InternalServerError, "Не найден тип документа");

            Document document;
            if (documentDto.Id.HasValue)
            {
                document = await _dataContext.Documents.FindAsync(documentDto.Id.Value);
                if (document == null)
                    throw new RestException(HttpStatusCode.NotFound, "Документ не найден");
            }
            else
            {
                document = new Document
                {
                    Id = Guid.NewGuid()
                };
            }

            document.DateIssue = documentDto.DateIssue;
            document.Issuer = documentDto.Issuer;
            document.Number = documentDto.Number;
            document.DocumentTypeId = documentType.Id;

            if (documentDto.Id.HasValue)
                _dataContext.Documents.Update(document);
            else
                await _dataContext.Documents.AddAsync(document);

            return document.Id;
        }

        public async Task<Organization> CreateOrUpdateOrganizationAsync(OwnerOrganizationDto organizationDto, CancellationToken cancellation)
        {

            if (organizationDto == null)
                throw new RestException(HttpStatusCode.BadRequest, "Пожалуйста заполните данные об организации");

            Organization organization;
           
            var bankAccountsToRemove = new HashSet<Guid>();
            if (organizationDto.Id.HasValue)
            {
                organization = await _dataContext.Organizations
                    .FirstOrDefaultAsync(x => x.Id == organizationDto.Id.Value);

                if (organization == null)
                    throw new RestException(HttpStatusCode.NotFound, "Организация не найдена");

                bankAccountsToRemove = _dataContext.BankAccounts.Where(x => x.PersonalityId == organization.PersonalityId).Select(x => x.Id).ToHashSet();
            }
            else
            {
                organization = new Organization
                {
                    Id = Guid.NewGuid()
                };
            }

            organization.PersonalityId = await CreateOrUpdatePersonalityAsync(new OrganizationDto
            {
                FullName = organizationDto.FullName
            }, organization.PersonalityId);
           

            if (organizationDto.Id.HasValue)
                _dataContext.Organizations.Update(organization);
            else
                await _dataContext.Organizations.AddAsync(organization);

            if (organizationDto.BankAccounts != null)
            {
                foreach (var bankAccount in organizationDto.BankAccounts)
                {
                    if (bankAccount.Id.HasValue)
                        bankAccountsToRemove.Remove(bankAccount.Id.Value);

                    await CreateOrUpdateBankAccountAsync(bankAccount, organization.PersonalityId);
                }
                _dataContext.BankAccounts.Where(x => bankAccountsToRemove.Contains(x.Id)).Delete();
            }

            await _dataContext.SaveChangesAsync();

            return organization;
        }
    }
}
