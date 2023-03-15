using Agro.Okaps.Logic.CQRS.LoanApplication.Dtos;
using Agro.Shared.Data.Context;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.Security;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Okaps.Logic.CQRS.LoanApplication
{
    public class List
    {
        public class Query : IPaginationFilter, IRequest<Response<ListResponse<LoanApplicationDto>>>
        {
            public short Page { get; set; } = 1;
            public short PageLimit { get; set; } = 10;
        }

        public class Handler : IRequestHandler<Query, Response<ListResponse<LoanApplicationDto>>>
        {
            private readonly DataContext _dataContext;
            private readonly IUserAccessor _userAccessor;

            public Handler(
                DataContext dataContext, IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _userAccessor = userAccessor;
            }

            public async Task<Response<ListResponse<LoanApplicationDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _dataContext.LoanApplications
                  .Where(x => !x.IsDeleted && x.UserId == _userAccessor.GetCurrentUserId())
                  .AsQueryable();

                var list = await query
                        .Include(x => x.DicLoanType)
                        .Include(x => x.DicLoanHistoryStatus)
                            .ThenInclude(xx => xx.DicApplicationStatus)
                    .OrderByDescending(x => x.CreatedDate)
                    .Skip((request.Page - 1) * request.PageLimit)
                    .Take(request.PageLimit)
                    .Select(x => new LoanApplicationDto
                    {
                        LoanApplicationId = x.Id,
                        LoanStatus = x.Status,
                        LoanStatusName = x.DicLoanHistoryStatus.DicApplicationStatus.GetName(),
                        RegisterNumber = x.RegNumber,
                        CreatedDate = x.CreatedDate,
                        LoanType = x.DicLoanType.Value,
                        LoanTypeName = x.DicLoanType.GetName()
                    })
                    .ToListAsync(cancellationToken);

                var applicationIds = list.Select(x => x.LoanApplicationId);

                var contracts = await _dataContext.Contracts
                         .Include(x => x.Calculator)
                         .Include(x => x.SelectedTechnic)
                             .ThenInclude(xx => xx.DicTechModel)
                                 .ThenInclude(xx => xx.DicTechProduct)
                                     .ThenInclude(xxx => xxx.DicTechType)
                         .Include(x => x.SelectedAccessories)
                             .ThenInclude(xx => xx.DicTechModel)

                         .Where(x => x.SelectedTechnic!= null && applicationIds.Contains(x.LoanApplicationId.Value))
                         .Select(x => new ContractDto
                         {
                             Id = x.Id,
                             LoanApplicationId = x.LoanApplicationId,
                             Technic = new TechnicDto
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
                                 TechProduct = x.SelectedTechnic.DicTechModel.DicTechProduct.GetName(),
                                 TechSubtypeId = x.SelectedTechnic.DicTechModel.DicTechProduct.DicTechTypeId,
                                 TechTypeId = x.SelectedTechnic.DicTechModel.DicTechProduct.DicTechType.ParentId.Value
                             },
                             Calculator = new CalculatorDto
                             {
                                 CoFinancing = x.Calculator.CoFinancing,
                                 Period = x.Calculator.Period,
                                 Sum = x.Calculator.Sum,
                                 Rate = x.Calculator.Rate,
                             },
                             Accessories = x.SelectedAccessories.Where(a => !a.IsDeleted).Select(a => new AccessoryDto
                             {
                                 Id = a.Id,
                                 CountryId = a.CountryId,
                                 ProviderId = a.ProviderId,
                                 Provider = a.DicProvider.GetName(),
                                 TechModelId = a.TechModelId,
                                 TechModel = a.DicTechModel.GetName(),
                                 TechProductId = a.DicTechModel.DicTechProductId,
                                 TechProduct = a.DicTechModel.DicTechProduct.GetName(),
                                 Price = a.Price,
                                 Count = a.Count
                             }).ToList()
                         })
                         .ToListAsync(cancellationToken);

                list.ForEach(x => x.Contracts = contracts.Where(c => x.LoanApplicationId == c.LoanApplicationId));
               
                return Response.Success("Запрос выполнен успешно", new ListResponse<LoanApplicationDto>
                {
                    List = list,
                    Count = await query.CountAsync(cancellationToken)
                });
            }
        }
    }
}
