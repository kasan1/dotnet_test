using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Agro.Shared.Logic.Common.Exceptions;
using System.Net;
using System;
using Agro.Shared.Data.Context;
using static Agro.Shared.Data.Context.PolicyRules;
using System.Linq;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.OutService.PKB;
using Microsoft.AspNetCore.Http;
using Agro.Shared.Logic.CQRS.Files;
using System.Collections.Generic;
using Agro.Shared.Logic.GKB;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Data.Entities.FinAnalysis;
using Agro.Shared.Logic.Extensions;

namespace Agro.Shared.Logic.CQRS.FinAlalysis
{
    public class Start
    {
        public class Command : IRequest<Response<Unit>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly ILogger<Start> _logger;
            private readonly DataContext _dataContext;
            private readonly IGKBLogic _gkbLogic;
            private readonly IPKBLogic _PKBLogic;
            private readonly IPKBChecksLogic _pkbChecks;
            private readonly IMediator _mediator;
            private readonly bool _isProduction;

            public Handler(
                IConfiguration configuration,
                IMediator mediator,
                DataContext dataContext,
                IGKBLogic gkbLogic,
                IPKBLogic PKBLogic,
                IPKBChecksLogic pkbChecks,
                ILogger<Start> logger
            )
            {
                _logger = logger;
                _mediator = mediator;
                _dataContext = dataContext;
                _gkbLogic = gkbLogic;
                _PKBLogic = PKBLogic;
                _pkbChecks = pkbChecks;
                _isProduction = configuration["environmentVariables:ASPNETCORE_ENVIRONMENT"] == "Production";
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"Запуск фин. анализа для заявки {request.LoanApplicationId}.");

                var application = await _dataContext.LoanApplications.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId, cancellationToken);
                if (application == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                var lastFinAnalysis = await _dataContext.FinAnalyses.FirstOrDefaultAsync(x => x.LoanApplicationId == request.LoanApplicationId);
                if (lastFinAnalysis != null)
                {
                    _dataContext.FinAnalyses.Remove(lastFinAnalysis);
                    await _dataContext.SaveChangesAsync(cancellationToken);
                }

                var finAnalysis = new FinAnalysis
                {
                    LoanApplicationId = request.LoanApplicationId,
                    Status = _isProduction ? RejectStatuses.ServiceUnavailable : RejectStatuses.Correct
                };

                await _dataContext.FinAnalyses.AddAsync(finAnalysis, cancellationToken);


                var personalities = await _dataContext.LoanApplicationDetailsPersonalities
                                            .Where(x => x.Details.LoanApplicationId == request.LoanApplicationId
                                            && (x.PersonalityType == PersonalityTypeEnum.Organization ||
                                                x.PersonalityType == PersonalityTypeEnum.Head ||
                                                x.PersonalityType == PersonalityTypeEnum.Representative ||
                                                x.PersonalityType == PersonalityTypeEnum.Beneficiary))
                                            .Select(x => new { DetailsPersonalityId = x.Id, x.Personality, x.PersonalityType })
                                            .ToListAsync(cancellationToken);

                

                var checkedPersonalities = new HashSet<string>();
                foreach (var x in personalities)
                {
                    var key = x.Personality.Identifier ?? x.Personality.FullName;
                    if (string.IsNullOrEmpty(key))
                        continue;

                    if (checkedPersonalities.Contains(key))
                        continue;
                    checkedPersonalities.Add(key);

                    var checkingResults = await Check(x.Personality, cancellationToken);
                    if (checkingResults.Any())
                    {
                        finAnalysis.Status = RejectStatuses.Critical;

                        _dataContext.CheckingResults.RemoveRange(_dataContext.CheckingResults.Where(cr => cr.DetailsPersonalityId == x.DetailsPersonalityId));

                        await _dataContext.CheckingResults.AddRangeAsync(checkingResults.Select(cr =>
                            new CheckingResult
                            {
                                CheckingListId = cr.Id,
                                DetailsPersonalityId = x.DetailsPersonalityId
                            })
                        );
                    }
                    
                    if (!string.IsNullOrEmpty(x.Personality.Identifier))
                    {
                        if (_isProduction)
                        {
                            await PKBCheck(finAnalysis, x.Personality);

                            if (x.PersonalityType == PersonalityTypeEnum.Organization)
                                await GkbReport(finAnalysis, x.Personality, true, cancellationToken);
                        }
                    }

                    if (x.PersonalityType == PersonalityTypeEnum.Organization)
                    {
                        var organization = await _dataContext.Organizations.FirstOrDefaultAsync(o => o.PersonalityId == x.Personality.Id, cancellationToken);
                        if (organization.IsNewRegistered())
                        {
                            finAnalysis.Status = RejectStatuses.Critical;
                        }
                    }
                }

                await _dataContext.SaveChangesAsync(cancellationToken);

                _logger.LogInformation($"Завершение фин. анализа для заявки {request.LoanApplicationId}.");

                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }

            #region проверки

            private async Task<List<CheckingList>> Check(Personality personality, CancellationToken cancellation)
            {
                if (!string.IsNullOrEmpty(personality.FullName))
                    return await _dataContext.CheckingList
                        .Where(x =>
                             x.Identifier == personality.Identifier ||
                             x.Fullname.ToLower().Trim() == personality.FullName.ToLower().Trim() ||
                             x.Fullname.ToLower().Trim() == personality.FullName.ToCyrillic().ToLower().Trim() ||
                             x.Fullname.ToLower().Trim() == personality.FullName.ToLatin().ToLower().Trim()

                        ).ToListAsync(cancellation);
                else
                    return await _dataContext.CheckingList
                       .Where(x => x.Identifier == personality.Identifier)
                       .ToListAsync(cancellation);
            }

            private async Task PKBCheck(FinAnalysis finAnalysis, Personality personality)
            {
#region ПКБ

                var _pkbId = await _PKBLogic.GetPKBXml(personality.Identifier);
                if (_pkbId.HasValue)
                {
                    var pkb = await _pkbChecks.CallCheckPublicSources(_pkbId.Value);
                    if (pkb != null)
                    {
                        finAnalysis.FalseBusiness = pkb.vars.FalseBusi;
                        finAnalysis.Bankrupt = pkb.vars.Bankruptcy;
                        finAnalysis.WantedIncome = pkb.vars.KgdWanted;
                        finAnalysis.Inactive = pkb.vars.Inactive;
                        finAnalysis.TaxesBankrupt = pkb.vars.BankruptKgd;
                        finAnalysis.TaxArrear = pkb.vars.TaxArrear;
                        finAnalysis.TerrorList = pkb.vars.TerrorList;
                        finAnalysis.Aliment = pkb.vars.QamqorAlimony;
                        finAnalysis.Pedophily = pkb.vars.Pedophile;
                        finAnalysis.LostPeople = pkb.vars.QamqorList;

                        var fileStream = await _PKBLogic.GetPKBFile(personality.Identifier);

                        var formFile = new FormFile(fileStream, 0, fileStream.Length, "PKB", $"PKB{personality.Identifier}_{DateTime.Now:yyyy-MM-dd_HH-mm}.pdf")
                        {
                            Headers = new HeaderDictionary(),
                            ContentType = "application/pdf"
                        };

                        await _mediator.Send(new Upload.UploadCommand
                        {
                            EntityId = finAnalysis.LoanApplicationId,
                            EntityType = EntityType.LoanApplication,
                            Files = new FormFileCollection { formFile }
                        });

                        if (finAnalysis.Inactive != RejectStatuses.Correct || finAnalysis.TaxArrear != RejectStatuses.Correct
                            || finAnalysis.Aliment != RejectStatuses.Correct)
                        {
                            if (finAnalysis.Status != RejectStatuses.Critical)
                                finAnalysis.Status = RejectStatuses.Minor;
                            
                        }
                        if (finAnalysis.FalseBusiness != RejectStatuses.Correct || finAnalysis.Bankrupt != RejectStatuses.Correct
                            || finAnalysis.WantedIncome != RejectStatuses.Correct || finAnalysis.LostPeople != RejectStatuses.Correct
                            || finAnalysis.TaxesBankrupt != RejectStatuses.Correct || finAnalysis.Pedophily != RejectStatuses.Correct
                            || finAnalysis.TerrorList != RejectStatuses.Correct)
                        {
                            finAnalysis.Status = RejectStatuses.Critical;
                        }
                    }
                }
                else
                {
                    finAnalysis.Status = RejectStatuses.ServiceUnavailable;   
                }

#endregion
            }
            private async Task GkbReport(FinAnalysis finAnalysis, Personality personality, bool isFL, CancellationToken cancellationToken)
            {
                try
                {
                    var data = await _gkbLogic.GetGKBFile(personality.Identifier, isFL, cancellationToken);

                    var formFile = new FormFile(new MemoryStream(data), 0, data.Length, "GKB", $"GKB{personality.Identifier}_{DateTime.Now:yyyy-MM-dd_HH-mm}.pdf")
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = "application/pdf"
                    };

                    await _mediator.Send(new Upload.UploadCommand
                    {
                        EntityId = finAnalysis.LoanApplicationId,
                        EntityType = EntityType.LoanApplication,
                        Files = new FormFileCollection { formFile }
                    });
                }
                catch (Exception ex)
                {
                    _ = ex.Message;
                }
                    
            }
           
            #endregion
        }
    }
}
