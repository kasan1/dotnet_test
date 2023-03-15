using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Agro.Okaps.Logic.CQRS.LoanApplication.Dtos;
using System;
using Agro.Okaps.Logic.CQRS.Dictionary;
using Agro.Shared.Logic.Services.Calculator;
using Agro.Shared.Logic.Services.System.Security;
using Agro.Shared.Logic.Common.Exceptions;

namespace Agro.Okaps.Logic.CQRS.LoanApplication
{
    public class Contracts
    {
        public class ContractsQuery : IRequest<Response<List<ContractExtraDto>>>
        {
            public Guid ApplicationId { get; set; }
        }

        public class CommandHandler : IRequestHandler<ContractsQuery, Response<List<ContractExtraDto>>>
        {
            private readonly IUserAccessor _userAccessor;
            private readonly DataContext _dataContext;
            private readonly IMediator _mediator;
            private readonly ICalculator _calculator;

            public CommandHandler(IMediator mediator,
                IUserAccessor userAccessor,
                DataContext dataContext, 
                ICalculator calculator)
            {
                _userAccessor = userAccessor;
                _dataContext = dataContext;
                _mediator = mediator;
                _calculator = calculator;
            }

            public async Task<Response<List<ContractExtraDto>>> Handle(ContractsQuery request, CancellationToken cancellationToken)
            {
                var loanApplicationId = await _dataContext.LoanApplications
                                                          .FirstOrDefaultAsync(x => x.UserId == _userAccessor.GetCurrentUserId() &
                                                                                    x.Id == request.ApplicationId,
                                                           cancellationToken);

                if (loanApplicationId == null)
                    throw new RestException(System.Net.HttpStatusCode.NotFound, "Не найдена заявка");

                var contracts = await _dataContext.Contracts
                        .Where(x => x.LoanApplicationId == loanApplicationId.Id)
                        .Select(x => new ContractExtraDto
                        {
                            Id = x.Id,
                            Technic = new TechnicExtraDto
                            {
                                Id = x.SelectedTechnic.Id,
                                Count = x.SelectedTechnic.Count,
                                CountryId = x.SelectedTechnic.CountryId,
                                Price = x.SelectedTechnic.Price,
                                ProviderId = x.SelectedTechnic.ProviderId,
                                Provider = x.SelectedTechnic.DicProvider.GetName(),
                                TechModelId = x.SelectedTechnic.TechModelId,
                                TechModel = x.SelectedTechnic.DicTechModel.GetName(),
                                TechProductId = x.SelectedTechnic.DicTechModel.DicTechProductId,
                                TechSubtypeId = x.SelectedTechnic.DicTechModel.DicTechProduct.DicTechTypeId,
                                TechTypeId = x.SelectedTechnic.DicTechModel.DicTechProduct.DicTechType.ParentId.Value
                            },
                            Calculator = new CalculatorDto
                            {
                                CoFinancing = x.Calculator.CoFinancing,
                                Period = x.Calculator.Period,
                            },
                            Accessories = x.SelectedAccessories.Where(a => !a.IsDeleted).Select(a => new AccessoryExtraDto
                            {
                                Id = a.Id,
                                CountryId = a.CountryId,
                                ProviderId = a.ProviderId,
                                Provider = a.DicProvider.GetName(),
                                TechModelId = a.TechModelId,
                                TechModel = a.DicTechModel.GetName(),
                                TechProductId = a.DicTechModel.DicTechProductId,
                                Price = a.Price,
                                Count = a.Count
                            }),
                            HasProvisions = x.Provisions.Any(),
                            Provisions = x.Provisions.Select(p => new ProvisionDto
                            {
                                Id = p.Id,
                                Type = p.ProvisionType.NameRu,
                                TypeId = p.ProvisionTypeId,
                                Description = p.ProvisionDescription.NameRu,
                                DescriptionId = p.ProvisionDescriptionId,
                                Sum = p.Sum
                            })
                        })
                        .ToListAsync(cancellationToken);

                foreach(var contractDto in contracts)
                {
                    contractDto.CalculatorResult = await _calculator.Calculate(new Shared.Logic.Models.Calculator.CalculatorInput
                    {
                        Count = contractDto.Technic.Count,
                        CountryId = contractDto.Technic.CountryId,
                        TechSubTypeId = contractDto.Technic.TechSubtypeId,
                        TechTypeId = contractDto.Technic.TechTypeId,
                        Price = contractDto.Technic.Price,
                        Accessories = contractDto.Accessories.Select(x => new Shared.Logic.Models.Calculator.SubjectAccessories
                        {
                            Count = x.Count,
                            Price = x.Price
                        }).ToList()
                    });
                    var listTechTypes = await _mediator.Send(new ListTechTypes.ListQuery() { });
                    if (listTechTypes.Succeed)
                        contractDto.Technic.TechTypes = listTechTypes.Data.List;

                    var listSubTechTypes = await _mediator.Send(new ListTechTypes.ListQuery() { ParentId = contractDto.Technic.TechTypeId });
                    if (listSubTechTypes.Succeed)
                        contractDto.Technic.TechSubtypes = listSubTechTypes.Data.List;

                    var listProducts = await _mediator.Send(new ListTechProducts.ListQuery() { TechTypeId = contractDto.Technic.TechSubtypeId });
                    if (listProducts.Succeed)
                        contractDto.Technic.TechProducts = listProducts.Data.List;

                    var listModels = await _mediator.Send(new ListTechModels.ListQuery() {  TechProductId = contractDto.Technic.TechProductId });
                    if (listModels.Succeed)
                        contractDto.Technic.TechModels = listModels.Data.List;

                    var listCountries = await _mediator.Send(new ListCountries.ListQuery() { TechModelId = contractDto.Technic.TechModelId, Rate = contractDto.CalculatorResult.Rate });
                    if (listCountries.Succeed)
                        contractDto.Technic.Countries = listCountries.Data.List;

                    var listProviders = await _mediator.Send(new ListProviders.ListQuery() { TechModelId = contractDto.Technic.TechModelId,  CountryId = contractDto.Technic.CountryId });
                    if (listProviders.Succeed)
                        contractDto.Technic.Providers = listProviders.Data.List;

                    
                    foreach(var accessoryDto in contractDto.Accessories)
                    {
                        var listAccessoryProducts = await _mediator.Send(new ListTechProducts.ListQuery() { AccessoryId = accessoryDto.Id });
                        if (listAccessoryProducts.Succeed)
                            accessoryDto.TechProducts = listAccessoryProducts.Data.List;

                        var listAccessoryModels = await _mediator.Send(new ListTechModels.ListQuery() { TechProductId = accessoryDto.TechProductId });
                        if (listAccessoryModels.Succeed)
                            accessoryDto.TechModels = listAccessoryModels.Data.List;

                        var listAccessoryCountries = await _mediator.Send(new ListCountries.ListQuery() { TechModelId = accessoryDto.TechModelId, Rate = contractDto.CalculatorResult.Rate });
                        if (listAccessoryCountries.Succeed)
                            accessoryDto.Countries = listAccessoryCountries.Data.List;

                        var listAccessoryProviders = await _mediator.Send(new ListProviders.ListQuery() { TechModelId = accessoryDto.TechModelId, CountryId = accessoryDto.CountryId });
                        if (listAccessoryProviders.Succeed)
                            accessoryDto.Providers = listAccessoryProviders.Data.List;
                    }
                }

                return Response.Success("Запрос выполнен успешно", contracts);
            }
        }
    }
}
