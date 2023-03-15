using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.Contracts.Dto;
using Agro.Bpm.Logic.Models.Common;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.Contracts
{
    public class Contracts
    {
        public class Query : IRequest<Response<ContractsDto>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<ContractsDto>>
        {
            private readonly DataContext _dataContext;

            public QueryHandler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<ContractsDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                //TODO: пересмотреть выборку полей
                var contracts = await _dataContext.Contracts
                    .Where(x => x.LoanApplicationId == request.LoanApplicationId)
                    .Select(x => new
                    {
                        Calculator = x.Calculator,
                        Techniques = new
                        {
                            ProductName = x.SelectedTechnic.DicTechModel.DicTechProduct.NameRu,
                            ModelName = x.SelectedTechnic.DicTechModel.NameRu,
                            CountryName = x.SelectedTechnic.DicCountry.NameRu,
                            ProviderName = x.SelectedTechnic.DicProvider.NameRu,
                            Count = x.SelectedTechnic.Count,
                            Price = x.SelectedTechnic.Price,
                            x.SelectedTechnic.IsDeleted
                        },
                        Accessories = x.SelectedAccessories
                            .Where(xx => !xx.IsDeleted)
                            .Select(xx => new
                            {
                                ProductName = xx.DicTechModel.DicTechProduct.NameRu,
                                ModelName = xx.DicTechModel.NameRu,
                                CountryName = xx.DicCountry.NameRu,
                                ProviderName = xx.DicProvider.NameRu,
                                Count = xx.Count,
                                Price = xx.Price,
                                xx.IsDeleted
                            }),
                        Provisions = x.Provisions.Select(p => new
                        {
                            Type = p.ProvisionType.NameRu,
                            Description = p.ProvisionDescription.NameRu,
                            Sum = p.Sum
                        })
                    })
                    .ToListAsync();

                var result = new ContractsDto()
                {
                    Calculators = new TableData()
                    {
                        Header = GenerateCalculatorTableHeaders()
                    },
                    Techniques = new TableData()
                    {
                        Header = GenerateTechniqueTableHeaders()
                    },
                    Provisions = new TableData()
                    {
                        Header = GenerateProvisionsTableHeaders()
                    }
                };

                if (contracts == null)
                    return Response.Success("Запрос выполнен успешно", result);

                int index = 1;
                foreach (var contract in contracts)
                {
                    result.Calculators.Body = new List<Dictionary<string, object>>()
                    {
                        new Dictionary<string, object>()
                        {
                            { "contract", index },
                            { "sum", contract.Calculator.Sum },
                            { "rate", contract.Calculator.Rate },
                            { "coofinance", contract.Calculator.CoFinancing },
                            { "period", contract.Calculator.Period },
                            { "overallSum",  CalculateOverallSum(contract.Calculator.Sum, contract.Calculator.CoFinancing) }
                        }
                    };

                    result.Techniques.Body.Add(new Dictionary<string, object>()
                    {
                        { "contract", index },
                        { "product", contract.Techniques.ProductName },
                        { "model", contract.Techniques.ModelName },
                        { "manufacturer", contract.Techniques.CountryName },
                        { "provider", contract.Techniques.ProviderName },
                        { "count", contract.Techniques.Count },
                        { "price", contract.Techniques.Price }
                    });

                    foreach (var accessory in contract.Accessories)
                    {
                        result.Techniques.Body.Add(new Dictionary<string, object>()
                        {
                            { "contract", index },
                            { "product", $"{accessory.ProductName} (компл)" },
                            { "model", accessory.ModelName },
                            { "manufacturer", accessory.CountryName },
                            { "provider", accessory.ProviderName },
                            { "count", accessory.Count },
                            { "price", accessory.Price }
                        });
                    }

                    foreach (var provision in contract.Provisions)
                    {
                        result.Provisions.Body.Add(new Dictionary<string, object>()
                        {
                            { "contract", index },
                            { "type", provision.Type },
                            { "description", provision.Description },
                            { "sum", provision.Sum?.ToString("N2") }
                        });
                    }

                    index++;
                }                

                return Response.Success("Запрос выполнен успешно", result);
            }

            private decimal CalculateOverallSum(decimal initialSum, decimal discount) =>
               initialSum * (100 - discount) / 100;

            private List<TableHeader> GenerateCalculatorTableHeaders() => new List<TableHeader>
                    {
                        new TableHeader
                        {
                            Code = "contract",
                            Name = "Договор",
                            IsOrderBy = true,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "sum",
                            Name = "Общая сумма",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "rate",
                            Name = "Ставка",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "coofinance",
                            Name = "Соофинансирование",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "period",
                            Name = "Срок",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "overallSum",
                            Name = "Итого (сумма после соофинансирования)",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        }
                    };

            private List<TableHeader> GenerateTechniqueTableHeaders() => new List<TableHeader>
                    {
                        new TableHeader
                        {
                            Code = "contract",
                            Name = "Договор",
                            IsOrderBy = true,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "product",
                            Name = "Товар",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "model",
                            Name = "Модель",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "manufacturer",
                            Name = "Страна производитель",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "provider",
                            Name = "Поставщик",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "count",
                            Name = "Количество",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "price",
                            Name = "Цена за ед.",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        }
                    };

            private List<TableHeader> GenerateProvisionsTableHeaders() => new List<TableHeader>
                    {
                        new TableHeader
                        {
                            Code = "contract",
                            Name = "Договор",
                            IsOrderBy = true,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "type",
                            Name = "Вид предлагаемого обеспечения",
                            IsOrderBy = true,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "description",
                            Name = "Описание обеспечения",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        },
                        new TableHeader
                        {
                            Code = "sum",
                            Name = "Сумма гарантии, задатка, оценочная стоимость предмета залога",
                            IsOrderBy = false,
                            OrderByDirection = OrderDirection.Asc
                        }
                    };
        }
    }
}
