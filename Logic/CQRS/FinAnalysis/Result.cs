using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.FinAnalysis.Dto;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.CQRS.Files;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.FinAnalysis
{
    public class Result
    {
        public class Query : IRequest<Response<FinAnalysisResultDto>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<FinAnalysisResultDto>>
        {
            private readonly DataContext _dataContext;
            private readonly IMediator _mediator;

            public QueryHandler(DataContext dataContext, IMediator mediator)
            {
                _dataContext = dataContext;
                _mediator = mediator;
            }

            public async Task<Response<FinAnalysisResultDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var finAnalysis = await _dataContext.FinAnalyses
                    .FirstOrDefaultAsync(x => x.LoanApplicationId == request.LoanApplicationId);

                if (finAnalysis == null)
                    throw new RestException(HttpStatusCode.NotFound, "Финансовый анализ не найден");

                var verificationStatuses = await _dataContext.DicVerificationStatuses.ToListAsync();

                var result = new FinAnalysisResultDto()
                {
                    DateOfInspection = finAnalysis.CreatedDate,
                    OverallStatus = verificationStatuses.FirstOrDefault(x => x.Status == finAnalysis.Status)?.NameRu
                };

                var pkbFile = await _mediator.Send(new ListByEntity.Query() { 
                    EntityId = request.LoanApplicationId, 
                    EntityType = EntityType.PKB }, cancellationToken);

                // TODO: Localize
                result.Results.Add(new FinAnalysisResultItem
                {
                    BlockName = "ПКБ",
                    Subjects = new List<FinAnalysisSubject>()
                    {
                        new FinAnalysisSubject()
                        {
                            Name = "Лжепредпринимательская деятельность",
                            Status = finAnalysis.FalseBusiness,
                            StatusName = verificationStatuses.FirstOrDefault(x => x.Status == finAnalysis.FalseBusiness)?.NameRu
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Списки несостоятельных должников/список банкротов",
                            Status = finAnalysis.Bankrupt,
                            StatusName = verificationStatuses.FirstOrDefault(x => x.Status == finAnalysis.Bankrupt)?.NameRu
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Розыск Комитетом государственных доходов Министерства Финансов РК",
                            Status = finAnalysis.WantedIncome,
                            StatusName = verificationStatuses.FirstOrDefault(x => x.Status == finAnalysis.WantedIncome)?.NameRu
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Список налогоплательщиков, признанных бездействующими",
                            Status = finAnalysis.Inactive,
                            StatusName = verificationStatuses.FirstOrDefault(x => x.Status == finAnalysis.Inactive)?.NameRu
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Список налогоплательщиков, признанных банкротами",
                            Status = finAnalysis.TaxesBankrupt,
                            StatusName = verificationStatuses.FirstOrDefault(x => x.Status == finAnalysis.TaxesBankrupt)?.NameRu
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Сведения об отсутствии (наличии) задолженности, учет по которым ведется в органах государственных доходов",
                            Status = finAnalysis.TaxArrear,
                            StatusName = verificationStatuses.FirstOrDefault(x => x.Status == finAnalysis.TaxArrear)?.NameRu
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Связь с финансированием терроризма",
                            Status = finAnalysis.TerrorList,
                            StatusName = verificationStatuses.FirstOrDefault(x => x.Status == finAnalysis.TerrorList)?.NameRu
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Розыск алиментщиков Комитетом по правовой статистике и специальным учетам ГП РК",
                            Status = finAnalysis.Aliment,
                            StatusName = verificationStatuses.FirstOrDefault(x => x.Status == finAnalysis.Aliment)?.NameRu
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Сведения о лицах, привлеченные к уголовной отвественности за совершение уголовных правонарушений против половой неприкосновенности несовершеннолетних",
                            Status = finAnalysis.Pedophily,
                            StatusName = verificationStatuses.FirstOrDefault(x => x.Status == finAnalysis.Pedophily)?.NameRu
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Розыск преступников, должников, без вести пропавших лиц Комитетом по правовой статистике и специальным учетам ГП РК",
                            Status = finAnalysis.LostPeople,
                            StatusName = verificationStatuses.FirstOrDefault(x => x.Status == finAnalysis.LostPeople)?.NameRu
                        }
                    },
                    File = pkbFile.Data?.FirstOrDefault()
                });

                var gkbFile = await _mediator.Send(new ListByEntity.Query()
                {
                    EntityId = request.LoanApplicationId,
                    EntityType = EntityType.GKB
                }, cancellationToken);

                result.Results.Add(new FinAnalysisResultItem
                {
                    BlockName = "ГКБ",
                    Subjects = new List<FinAnalysisSubject>()
                    {
                        new FinAnalysisSubject()
                        {
                            Name = "Негативный кредитный отчет",
                            Status = finAnalysis.GKBReuslt,
                            StatusName = verificationStatuses.FirstOrDefault(x => x.Status == finAnalysis.GKBReuslt)?.NameRu
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Отсутствие текущий просрочки",
                            StatusName = finAnalysis.ExistenceOfAmountDPD ? "Да" : "Нет"
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Количество дней просрочки по текущим кредитам",
                            StatusName = finAnalysis.SumOverdueAmount.ToString()
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Отсутствие просрочек за последние 2 года",
                            StatusName = finAnalysis.ExistDPDPastInToYears ? "Да" : "Нет"
                        },
                        new FinAnalysisSubject()
                        {
                            Name = "Количество дней просрочек за последние 2 года",
                            StatusName = finAnalysis.CountDPDPastInToYears.ToString()
                        }
                    },
                    File = gkbFile.Data?.FirstOrDefault()
                });

                var checkingResults = await _dataContext.CheckingResults
                                                .Where(x => x.DetailsPersonality.Details.LoanApplicationId == request.LoanApplicationId)
                                                .Select(x => new {
                                                    x.DetailsPersonality.Personality.Identifier,
                                                    x.DetailsPersonality.Personality.FullName,
                                                    x.CheckingList.DicCheckingListType,
                                                    x.CheckingList.Description
                                                })
                                                .ToListAsync(cancellationToken);

                if (checkingResults.Any())
                {
                    result.Results.Add(new FinAnalysisResultItem
                    {
                        BlockName = "Особые списки"
                    });

                    foreach (var gr in checkingResults.GroupBy(x => x.DicCheckingListType.Id))
                    {
                        result.Results.Last().Subjects.Add(new FinAnalysisSubject
                        {
                            Status = PolicyRules.RejectStatuses.Critical,
                            Name = gr.First().DicCheckingListType.GetName(),
                            StatusName = string.Join(", ", gr.Select(x => $"{x.Identifier}-{x.FullName}{(!string.IsNullOrEmpty(x.Description) ? $"({x.Description})" : string.Empty) }"))
                        });
                    }
                }

                var organization = await (from o in _dataContext.Organizations
                                          join ladp in _dataContext.LoanApplicationDetailsPersonalities on o.PersonalityId equals ladp.PersonalityId
                                          join lad in _dataContext.LoanApplicationDetails on ladp.DetailsId equals lad.Id
                                          where lad.LoanApplicationId == request.LoanApplicationId
                                          select o).FirstOrDefaultAsync(cancellationToken);

                if (organization.IsNewRegistered())
                {
                    result.Results.Add(new FinAnalysisResultItem
                    {
                        BlockName = "Дополнительные примечания"
                    });

                    result.Results.Last().Subjects.Add(new FinAnalysisSubject
                    {
                        Status = PolicyRules.RejectStatuses.Critical,
                        Name = "Недавно созданная компания",
                        StatusName = "Да"
                    });
                }

                return Response.Success("Запрос выполнен успешно", result);
            }
        }
    }
}
