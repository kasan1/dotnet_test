using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Okaps.Logic.CQRS.LoanApplication.Dtos;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.Calculator;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Okaps.Logic.CQRS.LoanApplication
{
    public class Update
    {
        public class UpdateCommand : IRequest<Response<Unit>>
        {
            public Guid ApplicationId { get; set; }
            public List<ContractDto> Contracts { get; set; }
        }

        public class CommandHandler : IRequestHandler<UpdateCommand, Response<Unit>>
        {
            private readonly ICalculator _calculator;
            private readonly DataContext _dataContext;
            private readonly string _notFoundErrorMessage = "Не найден элемент справочника";

            public CommandHandler(DataContext dataContext, ICalculator calculator)
            {
                _calculator = calculator;
                _dataContext = dataContext;
            }

            public async Task<Response<Unit>> Handle(UpdateCommand request, CancellationToken cancellationToken)
            {                
                var application = await _dataContext.LoanApplications.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.ApplicationId);
                if (application == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                if (application.Status != ApplicationTypeEnum.Temp)
                    throw new RestException(HttpStatusCode.BadRequest, "Заявка уже в работе, вы не можете вносить изменения");

                #region Подгрузка справочников
                var techTypesIds = new List<Guid>();
                var techModelIds = new List<Guid>();
                var techProductIds = new List<Guid>();
                var countryIds = new List<Guid>();
                var providerIds = new List<Guid>();


                techTypesIds.AddRange(request.Contracts.Select(x => x.Technic.TechTypeId));
                techTypesIds.AddRange(request.Contracts.Select(x => x.Technic.TechSubtypeId));
                techModelIds.AddRange(request.Contracts.Select(x => x.Technic.TechModelId));
                techProductIds.AddRange(request.Contracts.Select(x => x.Technic.TechProductId));
                countryIds.AddRange(request.Contracts.Select(x => x.Technic.CountryId));
                providerIds.AddRange(request.Contracts.Select(x => x.Technic.ProviderId));

                request.Contracts.ForEach(x =>
                {
                    techProductIds.AddRange(x.Accessories.Select(xx => xx.TechProductId));
                    techModelIds.AddRange(x.Accessories.Select(xx => xx.TechModelId));
                    countryIds.AddRange(x.Accessories.Select(xx => xx.CountryId));
                    providerIds.AddRange(x.Accessories.Select(xx => xx.ProviderId));
                });

                var techTypes = await _dataContext.DicTechTypes
                    .Where(x => !x.IsDeleted && techTypesIds.Contains(x.Id))
                    .ToListAsync();

                var techProducts = await _dataContext.DicTechProducts
                    .Where(x => !x.IsDeleted && techProductIds.Contains(x.Id))
                    .ToListAsync();

                var techModels = await _dataContext.DicTechModels
                        .Where(x => !x.IsDeleted && techModelIds.Contains(x.Id))
                        .ToListAsync();

                var countries = await _dataContext.DicCountries
                        .Where(x => !x.IsDeleted && countryIds.Contains(x.Id))
                        .ToListAsync();

                var providers = await _dataContext.DicProviders
                        .Where(x => !x.IsDeleted && providerIds.Contains(x.Id))
                        .ToListAsync();

                var provisionTypes = await _dataContext.DicProvisionTypes.ToListAsync(cancellationToken);
                var provisionDescriptions = await _dataContext.DicProvisionDescription.ToListAsync(cancellationToken);

                var loanTypes = await _dataContext.DicLoanTypes.ToListAsync(cancellationToken);
                var loanTypeId = loanTypes.FirstOrDefault(x => x.Value == LoanTypeEnum.ExpressLeasing).Id;
                #endregion

                var contracts = await _dataContext.Contracts
                    .Include(x => x.SelectedTechnic)
                    .Include(x => x.SelectedAccessories)
                    .Include(x => x.Calculator)
                    .Include(x => x.Provisions)
                    .Where(x => !x.IsDeleted && x.LoanApplicationId == application.Id)
                    .ToListAsync();

                foreach (var contractDto in request.Contracts)
                {
                    #region Проверка справочников
                    var techType = techTypes.FirstOrDefault(x => x.Id == contractDto.Technic.TechTypeId);
                    if (techType == null)
                        throw new RestException(System.Net.HttpStatusCode.BadRequest, _notFoundErrorMessage);

                    var techSubType = techTypes.FirstOrDefault(x => x.Id == contractDto.Technic.TechSubtypeId);
                    if (techSubType == null)
                        throw new RestException(System.Net.HttpStatusCode.BadRequest, _notFoundErrorMessage);

                    var techProduct = techProducts.FirstOrDefault(x => x.Id == contractDto.Technic.TechProductId);
                    if (techProduct == null)
                        throw new RestException(System.Net.HttpStatusCode.BadRequest, _notFoundErrorMessage);

                    var techModel = techModels.FirstOrDefault(x => x.Id == contractDto.Technic.TechModelId);
                    if (techModel == null)
                        throw new RestException(System.Net.HttpStatusCode.BadRequest, _notFoundErrorMessage);

                    var country = countries.FirstOrDefault(x => x.Id == contractDto.Technic.CountryId);
                    if (country == null)
                        throw new RestException(System.Net.HttpStatusCode.BadRequest, _notFoundErrorMessage);

                    var provider = providers.FirstOrDefault(x => x.Id == contractDto.Technic.ProviderId);
                    if (provider == null)
                        throw new RestException(System.Net.HttpStatusCode.BadRequest, _notFoundErrorMessage);
                    #endregion

                    var contract = contractDto.Id.HasValue ? contracts.FirstOrDefault(x => x.Id == contractDto.Id) : null;
                    var insertFlag = false;
                    if (contract == null)
                    {
                        contract = new Contract
                        {
                            Id = Guid.NewGuid(),
                            Name = techModel.GetName(),
                            LoanApplicationId = application.Id
                        };
                        await _dataContext.Contracts.AddAsync(contract);
                        insertFlag = true;
                    }

                    #region Основная техника
                    if (insertFlag)
                    {
                        var selectedTechnic = new SelectedTechnic
                        {
                            ContractId = contract.Id,
                            TechModelId = techModel.Id,
                            CountryId = country.Id,
                            ProviderId = provider.Id,
                            Count = contractDto.Technic.Count,
                            Price = contractDto.Technic.Price
                        };
                        await _dataContext.SelectedTechnics.AddAsync(selectedTechnic);
                    }
                    else
                    {
                        contract.SelectedTechnic.TechModelId = techModel.Id;
                        contract.SelectedTechnic.CountryId = country.Id;
                        contract.SelectedTechnic.ProviderId = provider.Id;
                        contract.SelectedTechnic.Count = contractDto.Technic.Count;
                        contract.SelectedTechnic.Price = contractDto.Technic.Price;
                    }
                    #endregion

                    #region Калькулятор
                    var calculatorResult = await _calculator.Calculate(new Shared.Logic.Models.Calculator.CalculatorInput
                    {
                        TechTypeId = techType.Id,
                        TechSubTypeId = techSubType.Id,
                        CountryId = country.Id,
                        Count = contractDto.Technic.Count,
                        Price = contractDto.Technic.Price,
                        Accessories = contractDto.Accessories?.Select(x => new Shared.Logic.Models.Calculator.SubjectAccessories
                        {
                            Count = x.Count,
                            Price = x.Price
                        }).ToList()
                    });

                    if (calculatorResult.CoFinancing > contractDto.Calculator.CoFinancing)
                        throw new RestException(System.Net.HttpStatusCode.BadRequest, "Неправильное значение софинансирования");

                    if (calculatorResult.Period < contractDto.Calculator.Period)
                        throw new RestException(System.Net.HttpStatusCode.BadRequest, "Неправильное значение периода");

                    //TODO: не очень правильное решение, нужно обсудить с бизнесом
                    if (calculatorResult.LoanType == LoanTypeEnum.StandartLeasing)
                        loanTypeId = loanTypes.FirstOrDefault(x => x.Value == LoanTypeEnum.StandartLeasing).Id;

                    if (insertFlag)
                    {
                        var calculator = new Shared.Data.Context.Calculator
                        {
                            ContractId = contract.Id,
                            CoFinancing = contractDto.Calculator.CoFinancing,
                            Period = contractDto.Calculator.Period,
                            Rate = calculatorResult.Rate,
                            Sum = calculatorResult.Sum
                        };
                        await _dataContext.Calculators.AddAsync(calculator);
                    }
                    else
                    {
                        contract.Calculator.CoFinancing = contractDto.Calculator.CoFinancing;
                        contract.Calculator.Period = contractDto.Calculator.Period;
                        contract.Calculator.Rate = calculatorResult.Rate;
                        contract.Calculator.Sum = calculatorResult.Sum;
                    }
                    #endregion

                    if (contractDto.Accessories != null && contractDto.Accessories.Any())
                    {
                        var existingAccessoriesIds = contractDto.Accessories.Select(x => x.Id).Where(x => x.HasValue);
                        var accessoriesToRemove = contract.SelectedAccessories?.Where(x => !existingAccessoriesIds.Contains(x.Id));

                        if (accessoriesToRemove != null && accessoriesToRemove.Any())
                            _dataContext.SelectedAccessories.RemoveRange(accessoriesToRemove);

                        foreach (var accessoryDto in contractDto.Accessories)
                        {
                            #region Проверка справочников
                            var accessoryTechProduct = techProducts
                                .FirstOrDefault(x => x.Id == accessoryDto.TechProductId);
                            if (accessoryTechProduct == null)
                                throw new RestException(System.Net.HttpStatusCode.BadRequest, _notFoundErrorMessage);

                            var accessoryTechModel = techModels
                                .FirstOrDefault(x => x.Id == accessoryDto.TechModelId);
                            if (accessoryTechModel == null)
                                throw new RestException(System.Net.HttpStatusCode.BadRequest, _notFoundErrorMessage);

                            var accessoryCountry = countries
                                .FirstOrDefault(x => x.Id == accessoryDto.CountryId);
                            if (accessoryCountry == null)
                                throw new RestException(System.Net.HttpStatusCode.BadRequest, _notFoundErrorMessage);

                            var accessoryProvider = providers
                                .FirstOrDefault(x => x.Id == accessoryDto.ProviderId);
                            if (accessoryProvider == null)
                                throw new RestException(System.Net.HttpStatusCode.BadRequest, _notFoundErrorMessage);
                            #endregion

                            var accessory = accessoryDto.Id.HasValue ? contract.SelectedAccessories.FirstOrDefault(x => x.Id == accessoryDto.Id) : null;
                            if (accessory == null)
                            {
                                accessory = new SelectedAccessory
                                {
                                    ContractId = contract.Id,
                                    TechModelId = accessoryTechModel.Id,
                                    CountryId = accessoryCountry.Id,
                                    ProviderId = accessoryProvider.Id,
                                    Count = accessoryDto.Count,
                                    Price = accessoryDto.Price
                                };
                                await _dataContext.SelectedAccessories.AddAsync(accessory);
                            }
                            else
                            {
                                accessory.TechModelId = accessoryTechModel.Id;
                                accessory.CountryId = accessoryCountry.Id;
                                accessory.ProviderId = accessoryProvider.Id;
                                accessory.Count = accessoryDto.Count;
                                accessory.Price = accessoryDto.Price;
                            }
                        }
                    }

                    if (contractDto.Provisions != null && contractDto.Provisions.Any())
                    {
                        var existingProvisionsIds = contractDto.Provisions.Select(x => x.Id).Where(x => x.HasValue);
                        var provisionsToRemove = contract.Provisions?.Where(x => !existingProvisionsIds.Contains(x.Id));

                        if (provisionsToRemove != null && provisionsToRemove.Any())
                            _dataContext.Provisions.RemoveRange(provisionsToRemove);

                        foreach (var provisionDto in contractDto.Provisions)
                        {
                            #region Проверка справочников
                            var provisionType = provisionTypes
                                .FirstOrDefault(x => x.Id == provisionDto.TypeId);
                            if (provisionType == null)
                                throw new RestException(HttpStatusCode.BadRequest, _notFoundErrorMessage);

                            var provisionDescription = provisionDescriptions
                              .FirstOrDefault(x => x.Id == provisionDto.DescriptionId);
                            if (provisionDescription == null)
                                throw new RestException(HttpStatusCode.BadRequest, _notFoundErrorMessage);

                            #endregion

                            var provision = provisionDto.Id.HasValue ? contract.Provisions.FirstOrDefault(x => x.Id == provisionDto.Id) : null;
                            if (provision == null)
                            {
                                provision = new Provision
                                {
                                    ContractId = contract.Id,
                                    ProvisionTypeId = provisionType.Id,
                                    ProvisionDescriptionId = provisionDescription.Id,
                                    Sum = provisionDto.Sum
                                };
                                await _dataContext.Provisions.AddAsync(provision);
                            }
                            else
                            {
                                provision.ProvisionTypeId = provisionType.Id;
                                provision.ProvisionDescriptionId = provisionDescription.Id;
                                provision.Sum = provisionDto.Sum;
                            }
                        }
                    }
                }
                application.DicLoanTypeId = loanTypeId;
                await _dataContext.SaveChangesAsync();
                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }
    }
}
