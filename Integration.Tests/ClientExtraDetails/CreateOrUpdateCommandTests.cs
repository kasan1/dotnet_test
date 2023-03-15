using Agro.Shared.Logic.CQRS.ClientDetails.DTOs;
using Agro.Shared.Logic.CQRS.ClientExtraDetails.DTOs;
using Agro.Shared.Logic.CQRS.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Agro.Integration.Tests.ClientExtraDetails
{
    public class CreateOrUpdateCommandTests : Base
    {
        [Fact]
        public async Task ExecuteAsync_ShouldCreateLoanApplicationExtraDetails_WhenThereIsNoValidationErrors()
        {
            var request = new Shared.Logic.CQRS.ClientExtraDetails.CreateOrUpdate.Command
            {
                UlOwners = new List<UlOwnerDto>
                 {
                     new UlOwnerDto
                     {
                          FullName = "Асанов Усен",
                          Rate =51,
                          BankAccounts = new List<BankAccountDto>
                          {
                              new BankAccountDto
                              {
                                   BIC = "KASPI",
                                   Number = "1234567890"
                              }
                          }
                     },
                     new UlOwnerDto
                     {
                          FullName = "Иванов Иван",
                          Rate = 49,
                          BankAccounts = new List<BankAccountDto>
                          {
                              new BankAccountDto
                              {
                                   BIC = "SBER",
                                   Number = "1234567890"
                              }
                          }
                     }
                 },
                FlOwners = new List<FlOwnerDto> {
                    new FlOwnerDto
                    {
                        FullName = "Карабаев Сарыбай",
                        Address = new AddressDto
                        {
                            Register = "Петрова 21",
                            Fact = "Майлина 20"
                        },
                        IdentificationDocument =  new DocumentDto
                        {
                            Number = "445566",
                            Issuer = "MU RK",
                            DateIssue = DateTime.Now.AddYears(-4)
                        }
                    }
                },
                VatCertificate = new DocumentDto
                {
                    Number = "112233",
                    Issuer = "MU RK",
                    DateIssue = DateTime.Now.AddYears(-1)
                },
                Licenses = new List<LicenseDto> {
                    new LicenseDto
                    {
                        Document = new DocumentDto
                        {
                            Number = "445566",
                            Issuer = "MU RK",
                            DateIssue = DateTime.Now.AddYears(-2)
                        },
                        Essence = "На производство кефира"
                    }
                }
            };

            var response = await _client.PostAsync("/api/LoanApplication/4e407a01-8974-4535-af8d-8bff47a0e689/details/extra", GetContent(request));
            var content = await response.Content.ReadAsStringAsync();
            _ = content;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
