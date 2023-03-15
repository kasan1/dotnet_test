using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Agro.Okaps.Logic.CQRS.LoanApplication.Dtos;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Services.Calculator;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Agro.Shared.Data.Primitives;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Agro.Shared.Logic.Services.System.Security;

namespace Agro.Okaps.Logic.CQRS.LoanApplication
{
    public class Create
    {
        public class CreateCommand :IRequest<Response<Unit>>
        {
            public Guid? LoanProductId { get; set; }
            public List<ContractDto> Contracts { get; set; }
        }

        public class CommandHandler : IRequestHandler<CreateCommand, Response<Unit>>
        {
            private readonly ICalculator _calculator;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IUserAccessor _userAccessor;
            private readonly DataContext _dataContext;
            private readonly string _defaultLoanProductCode = "1";
            private readonly string _defaultStatusCode = "Temp";
            private readonly string _notFoundErrorMessage = "Не найден элемент справочника";

            public CommandHandler(DataContext dataContext, 
                ICalculator calculator, 
                IHttpContextAccessor httpContextAccessor,
                IUserAccessor userAccessor)
            {
                _calculator = calculator;
                _httpContextAccessor = httpContextAccessor;
                _userAccessor = userAccessor;
                _dataContext = dataContext;
            }

            public async Task<Response<Unit>> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                //TODO: проверку спровочников оптимизировать, контракты с одиннаковыми ставками и сроками объяденить 
                var loanProduct =
                    request.LoanProductId.HasValue ?
                    await _dataContext.DicLoanProducts.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanProductId) :
                    await _dataContext.DicLoanProducts.FirstOrDefaultAsync(x => !x.IsDeleted && x.Code == _defaultLoanProductCode);
                if (loanProduct == null)
                    throw new RestException(System.Net.HttpStatusCode.InternalServerError, "Продукт не найден");

                var loanTypes = await _dataContext.DicLoanTypes.ToListAsync(cancellationToken);
                var loanTypeId = loanTypes.FirstOrDefault(x => x.Value == LoanTypeEnum.ExpressLeasing).Id;

                var status = await _dataContext.DicLoanHistoryStatuses.FirstOrDefaultAsync(x => x.Code == _defaultStatusCode && !x.IsDeleted);
                if (status == null)
                    throw new RestException(System.Net.HttpStatusCode.InternalServerError, "Статус не найден");

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

                #endregion
                                
                var loanApplication = new Shared.Data.Context.LoanApplication
                {
                    Id = Guid.NewGuid(),
                    UserId = _userAccessor.GetCurrentUserId(),
                    LoanProductId = loanProduct.Id,
                    DicLoanTypeId = loanTypeId,
                    Status = ApplicationTypeEnum.Temp,
                    StatusId = status.Id
                };
                loanApplication.SetRegNumber();
                await _dataContext.LoanApplications.AddAsync(loanApplication);

                var contractTempStatus = await _dataContext.DicContractStatus.FirstOrDefaultAsync(x => x.Code == "Temp");
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
                    
                    var contract = new Contract
                    {
                        Id = Guid.NewGuid(),
                        Name = techModel.GetName(),
                        LoanApplicationId = loanApplication.Id,
                        UserId = loanApplication.UserId,
                        StatusId = contractTempStatus?.Id
                    };
                    await _dataContext.Contracts.AddAsync(contract);

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

                    var calculatorResult = await _calculator.Calculate(new Shared.Logic.Models.Calculator.CalculatorInput
                    {
                        TechTypeId = techType.Id,
                        TechSubTypeId = techSubType.Id,
                        CountryId = country.Id,
                        Count = contractDto.Technic.Count,
                        Price = contractDto.Technic.Price,
                        Accessories = contractDto.Accessories.Select(x => new Shared.Logic.Models.Calculator.SubjectAccessories
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

                    var calculator = new Shared.Data.Context.Calculator
                    {
                        ContractId = contract.Id,
                        CoFinancing = contractDto.Calculator.CoFinancing,
                        Period = contractDto.Calculator.Period,
                        Rate = calculatorResult.Rate,
                        Sum = calculatorResult.Sum
                    };
                    await _dataContext.Calculators.AddAsync(calculator);
                   
                    
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
                        var accessory = new SelectedAccessory
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

                    foreach (var provisionDto in contractDto.Provisions)
                    {
                        #region Проверка справочников
                        var provisionType = provisionTypes
                            .FirstOrDefault(x => x.Id == provisionDto.TypeId);
                        if (provisionType == null)
                            throw new RestException(System.Net.HttpStatusCode.BadRequest, _notFoundErrorMessage);

                        var provisionDescription = provisionDescriptions
                            .FirstOrDefault(x => x.Id == provisionDto.DescriptionId);
                        if (provisionDescription == null)
                            throw new RestException(System.Net.HttpStatusCode.BadRequest, _notFoundErrorMessage);

                        #endregion
                        var provision = new Provision
                        {
                            ContractId = contract.Id,
                            ProvisionTypeId = provisionType.Id,
                            ProvisionDescriptionId = provisionDescription.Id,
                            Sum = provisionDto.Sum
                        };
                        await _dataContext.Provisions.AddAsync(provision);
                    }
                }
                                
                await _dataContext.SaveChangesAsync();
                                
                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }
        }
    }
}
