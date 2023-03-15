using Agro.Okaps.Api.Controllers;
using Agro.Okaps.Logic.CQRS.LoanApplication.Dtos;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Agro.Integration.Tests.LoanApplication
{
    public class CreateCommandTests : Base
    {
        [Fact]
        public async Task ExecuteAsync_ShouldCreateLoanApplication_WhenThereIsNoValidationErrors()
        {
            var request = new Okaps.Logic.CQRS.LoanApplication.Create.CreateCommand
            {
                LoanProductId = System.Guid.Parse("A039445D-6A52-45E0-BCBF-032B850F8FFB"),
                Contracts = new List<ContractDto>
                {
                    new ContractDto
                    {
                        Technic = new TechnicDto
                        {
                            TechTypeId = System.Guid.Parse("C9BE2B3B-0348-4832-9274-448C5767A131"),
                            TechSubtypeId = System.Guid.Parse("ECE50167-5948-4B64-83D3-E71030DF0D69"),
                            TechProductId = System.Guid.Parse("2107E1CF-5976-4A0E-A896-B6FD68CAE8BF"),
                            TechModelId = System.Guid.Parse("D9B95067-59C0-47E1-1290-08D86FFAF9E6"),
                            CountryId = System.Guid.Parse("40EE6AE0-54E1-4AC7-9819-1F00A378CCDA"),
                            ProviderId = System.Guid.Parse("48F5FA9F-8223-4A66-BF95-B68EEBC6C618"),
                            Count = 1,
                            Price = 15000000
                        },
                        Calculator = new CalculatorDto
                        {
                            CoFinancing = 25,
                            Period = 7
                        },
                        Provisions = new List<ProvisionDto>
                        {
                            new ProvisionDto
                            {
                                TypeId = System.Guid.Parse("8FC3A266-5E33-4138-9284-C47E05696CB3"),
                                DescriptionId = System.Guid.Parse("03723EEB-7807-44A8-92B4-EBE52825B652"),
                                Sum = 100*1000*1000
                            }
                        }
                    }
                }
            };

            var response = await _client.PostAsync(ApiRoutes.LoanApplication.Post, GetContent(request));
            var content = await response.Content.ReadAsStringAsync();
            _ = content;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
