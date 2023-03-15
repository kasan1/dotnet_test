using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.Identity;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Agro.Bpm.Logic.CQRS.Integrations._1C
{
    public class GetContracts
    {
        public class Command : IRequest<Response<Unit>>
        {
            public Guid UserId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly IHttpClientFactory _httpClientFactory;
            private readonly DataContext _dataContext;
            private readonly UserManager<AppUser> _userManager;

            public Handler(
                IHttpClientFactory httpClientFactory, 
                DataContext dataContext,
                UserManager<AppUser> userManager
            )
            {
                _httpClientFactory = httpClientFactory;
                _dataContext = dataContext;
                _userManager = userManager;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _userManager.Users
                    .Include(x => x.Profile)
                    .Where(x => x.Id == request.UserId)
                    .Select(x => new { x.Id, x.Profile.Identifier })
                    .FirstOrDefaultAsync(cancellationToken);

                if (user == null)
                    throw new RestException(HttpStatusCode.NotFound, "Пользователь не найден");

                using var client = _httpClientFactory.CreateClient("C1");

                var response = await client.GetAsync($"/kaz10/hs/bpm/database/iin/{user.Identifier}", cancellationToken);

                if (!response.IsSuccessStatusCode)
                    throw new RestException(HttpStatusCode.InternalServerError, "Не удалось получить договора");

                var contracts = JsonConvert.DeserializeObject<List<ContractDto>>(await response.Content.ReadAsStringAsync());
                if (contracts.Any())
                {
                    var statuses = await _dataContext.DicContractStatus.ToListAsync(cancellationToken);
                    foreach (var contract in contracts)
                    {
                        var localContract = await _dataContext.Contracts.FirstOrDefaultAsync(x => x.Id == contract.Id);
                        var status = !string.IsNullOrEmpty(contract.Status)
                            ? statuses.FirstOrDefault(x => x.Code == contract.Status)
                            : null;

                        if (localContract == null)
                        {
                            localContract = new Contract()
                            {
                                Id = contract.Id,
                                CreatedDate = contract.GetDate(),
                                ModifiedDate = contract.GetDateOfUpdate(),
                                UserId = user.Id,
                                Number = contract.Number,
                                PrincipalDebtBalance = contract.GetPrincipalDebtBalance(),
                                StatusId = status?.Id
                            };

                            await _dataContext.Contracts.AddAsync(localContract, cancellationToken);

                            await _dataContext.Calculators.AddAsync(new Calculator
                            {
                                ContractId = contract.Id,
                                CoFinancing = contract.GetCoFinancing(),
                                Sum = contract.GetSum(),
                                Rate = contract.GetRate(),
                                Period = contract.GetPeriod()
                            });
                        }
                        else if (localContract.ModifiedDate > contract.GetDateOfUpdate())
                        {
                            localContract.Number = contract.Number;
                            localContract.PrincipalDebtBalance = contract.GetPrincipalDebtBalance();
                            localContract.ModifiedDate = contract.GetDateOfUpdate();
                            localContract.StatusId = status?.Id;

                            var calculator = await _dataContext.Calculators.SingleAsync(x => x.ContractId == localContract.Id, cancellationToken);
                            calculator.CoFinancing = contract.GetCoFinancing();
                            calculator.Sum = contract.GetSum();
                            calculator.Rate = contract.GetRate();
                            calculator.Period = contract.GetPeriod();
                        }
                    }

                    await _dataContext.SaveChangesAsync(cancellationToken);
                }
                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }


            private class ContractDto
            {
                private DateTime ConvertDate(string date) => DateTime.ParseExact(date, "dd.MM.yyyy", CultureInfo.InvariantCulture);

                public Guid Id { get; set; }
                public string DateOfUpdate { private get; set; }
                public DateTime GetDateOfUpdate()
                {
                    return !string.IsNullOrEmpty(DateOfUpdate)
                        ? ConvertDate(DateOfUpdate)
                        : DateTime.Now;
                }
                public string Date { private get; set; }
                public DateTime GetDate()
                {
                    return !string.IsNullOrEmpty(Date)
                        ? ConvertDate(Date)
                        : DateTime.Now;
                }

                public decimal? Sum { private get; set; }
                public decimal GetSum() => Sum ?? 0;
                public decimal? Rate { private get; set; }
                public decimal GetRate() => Rate ?? 0;
                public decimal? CoFinancing { private get; set; }
                public decimal GetCoFinancing() => CoFinancing ?? 0;
                public int? Period { private get; set; }
                public int GetPeriod() => Period ?? 0;
                public decimal? PrincipalDebtBalance { private get; set; }
                public decimal GetPrincipalDebtBalance() => PrincipalDebtBalance ?? 0;
                public string Number { get; set; }
                public string Status { get; set; }

                /// <summary>
                /// Дата заключения
                /// </summary>
                public string DateOfConclusion { private get; set; }
                public DateTime GetDateOfConclusion()
                {
                    return !string.IsNullOrEmpty(DateOfConclusion)
                        ? ConvertDate(DateOfConclusion)
                        : DateTime.Now;
                }

                /// <summary>
                /// Дата завершения
                /// </summary>
                public string DateOfClose { get; set; }
                public DateTime GetDateOfClose()
                {
                    return !string.IsNullOrEmpty(DateOfClose)
                        ? ConvertDate(DateOfClose)
                        : DateTime.Now;
                }
            }
        }
    }
}
