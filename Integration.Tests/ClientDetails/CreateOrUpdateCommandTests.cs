using Agro.Shared.Logic.CQRS.ClientActivities.DTOs;
using Agro.Shared.Logic.CQRS.ClientDetails.DTOs;
using Agro.Shared.Logic.CQRS.Common.DTOs;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Agro.Integration.Tests.ClientDetails
{
    public class CreateOrUpdateCommandTests : Base
    {
        [Fact]
        public async Task ExecuteAsync_ShouldCreateLoanApplication_WhenThereIsNoValidationErrors()
        {
            var request = new Shared.Logic.CQRS.ClientDetails.CreateOrUpdate.Command
            {
                Head = new PersonDto
                {
                    BirthDate = new System.DateTime(1991, 6, 13),
                    BirthPlace = "ВКО",
                    IsResident = true,
                    CountryId = System.Guid.Parse("695740b3-fde5-45a3-be29-54cafb7659af"),
                    MarriageStatusId = System.Guid.Parse("3528f2e8-478a-45bf-9271-26fcf09c7a5b"),
                    FullName = "Аманбеков Бауыржан",
                    Identifier = "910613350495",
                    Phone = new PhoneDto
                    {
                        Work = "+77079852755"
                    },
                    Address = new AddressDto
                    {
                        Register = "Иманова, 45"
                    },
                    Education = "высшее",
                    WorkExperience = new WorkExperienceDto
                    {
                        Total = "10 лет",
                        Agriculture = "10 лет"
                    }
                },
                Organization = new OrganizationDto
                {
                    LegalFormId = System.Guid.Parse("31045F1D-E216-4724-B733-0C813458DF47"),
                    SubjectOfEntrepreneurId = System.Guid.Parse("70CD9AA2-DA90-40B0-B62E-D1C26FFCD2FD"),
                    TaxTreatmentId = System.Guid.Parse("5586A71E-1277-4E90-9004-BAAD6745373A"),
                    OKED = new List<System.Guid> {
                        System.Guid.Parse("8e27ebdf-16ea-4376-b74f-011c87a1877f"),
                        System.Guid.Parse("102A2954-EA3E-4E86-AEA9-A43E8516E372")
                    },
                    RegistrationDocument = new DocumentDto
                    {
                        Number = "123456",
                        Issuer = "МВД РК",
                        DateIssue = System.DateTime.Now,
                    },
                    BankAccounts = new List<BankAccountDto> {
                         new BankAccountDto  {
                            BIC="KASPI",
                            Number="123456"
                         }
                    },
                    IsAffiliated = false,
                    Identifier = "910613350495",
                    FullName = "ТОО Аспан",

                    Email = "b.amanbekov@kaf.kz",
                    Phone = new PhoneDto
                    {
                        Work = "+77079852755"
                    },
                    Address = new AddressDto
                    {
                        Register = "Алматы 12"
                    },
                    IdentificationDocument = new DocumentDto
                    {
                        Number = "123456",
                        Issuer = "МВД РК",
                        DateIssue = System.DateTime.Now
                    }
                }
            };

            var response = await _client.PostAsync("/api/LoanApplication/4e407a01-8974-4535-af8d-8bff47a0e689/details", GetContent(request));
            var content = await response.Content.ReadAsStringAsync();
            _ = content;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task ExecuteAsync_ShouldCreateClientActivities_WhenThereIsNoValidationErrors()
        {
            var request = new Shared.Logic.CQRS.ClientActivities.Create.CreateActivityCommand
            {
                FloraActivities = new List<FloraActivityDto>
                {
                    new FloraActivityDto
                    {
                        CultureId = System.Guid.Parse("4ACBBB13-A739-4C8A-0E99-08D89E6C964E"),
                        Cost = 43000,
                        PlannedSquare = 204,
                        PriceRealization= 95000,
                        SeedingRate = 120,
                        ProductivityCurrentYear = 18,
                        ProductivityLastYear = 14,
                        ProductivityBeforeLastYear = 12
                    }
                },
                LandActivities = new List<LandActivityDto>
                {
                    new LandActivityDto
                    {
                        LandTypeId = System.Guid.Parse("6C293F35-6171-43B1-868A-67632DB8D1A4"),
                        OwnershipTypeId = System.Guid.Parse("64767E74-6F0D-40B6-97E5-4ED609286204"),
                        Square = 100
                    }
                },
                TechnicActivities = new List<TechnicActivityDto>
                {
                    new TechnicActivityDto {
                        Fullname = "Сеялки СЗЗ-2.1",
                        Count = 1,
                        CountOfCorrect = 1,
                        DateIssue = System.DateTime.Now,
                        IsPledged = false,
                        PledgeDescription = "не указан"
                    }
                },
                LivestockActivities = new List<LivestockActivityDto>
                {
                    new LivestockActivityDto
                    {
                        LivestockTypeId = System.Guid.Parse("38906768-E79A-42A6-AB41-6EDC04A45AB6"),
                        //LivestockTypeParentId = System.Guid.Parse(""),
                        LiveWeight = 10,
                        SlaughterWeight = 3,
                        SlaughterPrice = 30000,
                        LivePrice = 100000
                    }
                }
            };

            var response = await _client.PostAsync("/api/LoanApplication/4e407a01-8974-4535-af8d-8bff47a0e689/activities", GetContent(request));
            var content = await response.Content.ReadAsStringAsync();
            _ = content;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
