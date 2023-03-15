using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Agro.Shared.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Agro.Okaps.Logic.CQRS.LoanApplication.Dtos;
using Agro.Shared.Logic.Services.System.Security;
using Agro.Shared.Logic.Services.System.File;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Data.Enums.System;

namespace Agro.Okaps.Logic.CQRS.LoanApplication
{
    public class AllContracts
    {
        public class Query : IPaginationFilter,  IRequest<Response<ListResponse<ContractShortDto>>>
        {
            public short Page { get; set; } = 1;
            public short PageLimit { get; set; } = 10;
        }

        public class CommandHandler : IRequestHandler<Query, Response<ListResponse<ContractShortDto>>>
        {
            private readonly DataContext _dataContext;
            private readonly IUserAccessor _userAccessor;
            private readonly IFileService _fileService;

            public CommandHandler(
                DataContext dataContext, 
                IUserAccessor userAccessor,
                Delegates.FileServiceResolver fileServiceResolver)
            {
                _dataContext = dataContext;
                _userAccessor = userAccessor;
                _fileService = fileServiceResolver(FileServiceTypeEnum.Database);
            }

            public async Task<Response<ListResponse<ContractShortDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var query = _dataContext.Contracts
                        .Where(x => x.UserId == _userAccessor.GetCurrentUserId() &
                                    x.DicContractStatus.Code != "Temp");

                var contracts = await query
                        .OrderByDescending(x => x.CreatedDate)
                        .Skip((request.Page - 1) * request.PageLimit)
                        .Take(request.PageLimit)
                        .Select(x => new ContractShortDto
                        {
                            Id = x.Id,
                            LoanApplicationId = x.LoanApplicationId,
                            Number = x.Number,
                            CreatedDate = x.CreatedDate,
                            Description = x.Name,
                            Status = x.DicContractStatus != null ? x.DicContractStatus.GetName() : null,
                            PrincipalDebtBalance = x.PrincipalDebtBalance,
                            Calculator = new CalculatorDto
                            {
                                CoFinancing = x.Calculator.CoFinancing,
                                Period = x.Calculator.Period,
                                Rate = x.Calculator.Rate,
                                Sum = x.Calculator.Sum
                            }
                        })
                        .ToListAsync(cancellationToken);

                foreach (var contract in contracts)
                {
                    var scheduleFiles = await _fileService.GetEntityFiles(EntityType.PaymentSchedule, contract.Id.Value);
                    if (scheduleFiles.Any())
                        contract.ScheduleUrl = $"api/files/{scheduleFiles.First().Id}";
                }

                return Response.Success("Запрос выполнен успешно", new ListResponse<ContractShortDto> {
                    List = contracts,
                    Count = await query.CountAsync()
                });
            }
        }
    }
}
