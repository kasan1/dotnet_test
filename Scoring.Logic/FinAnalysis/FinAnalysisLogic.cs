using Agro.Integration.Logic.OutService.ASP;
using Agro.Integration.Logic.OutService.GCVP;
using Agro.Shared.Logic.GKB;
using Agro.Shared.Logic.OutService.PKB;
using Agro.Integration.Logic.OutService.ZAGS;
using Agro.Shared.Logic.Primitives;
using Agro.Scoring.Logic.Scoring;
using Agro.Shared.Data.Repos.FinAnalysis;
using Agro.Shared.Data.Repos.LoanApplication;
using Agro.Shared.Logic.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Agro.Shared.Data.Context.PolicyRules;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.Services.System.File;
using Agro.Shared.Data.Enums.System;

namespace Agro.Scoring.Logic.FinAnalysis
{
    [Obsolete]
    public class FinAnalysisLogic : IFinAnalysisLogic
    {
        private readonly IASPLogic _ASPLogic;
        private readonly IZAGSLogic _ZAGSLogic;
        private readonly IGKBLogic _GKBLogic;
        private readonly IPKBLogic _PKBLogic;
        private readonly IGCVPLogic _GCVPLogic;

        private readonly ICheckAffilationLogic _checkAffilation;
        private readonly IOverdueCheckLogic _overdueCheck;
        private readonly IPKBChecksLogic _pkbChecks;
        private readonly IGCVPCheckLogic _gCVPCheckLogic;

        private readonly IFinAnalysisRepo _repo;
        private readonly ILoanApplicationRepo _loanApplicationRepo;
        private readonly IFileService _fileService;

        public FinAnalysisLogic(IASPLogic ASPLogic,
            IZAGSLogic ZAGSLogic,
            IGKBLogic GKBLogic,
            IPKBLogic PKBLogic,
            IGCVPLogic GCVPLogic,

            ICheckAffilationLogic checkAffilation,
            IOverdueCheckLogic overdueCheck,
            IPKBChecksLogic pkbChecks,
            IGCVPCheckLogic gCVPCheckLogic,

            ILoanApplicationRepo loanApplicationRepo,
            Delegates.FileServiceResolver fileServiceResolver,

            IFinAnalysisRepo repo)
        {
            _ASPLogic = ASPLogic;
            _ZAGSLogic = ZAGSLogic;
            _GKBLogic = GKBLogic;
            _PKBLogic = PKBLogic;
            _GCVPLogic = GCVPLogic;

            _checkAffilation = checkAffilation;
            _overdueCheck = overdueCheck;
            _pkbChecks = pkbChecks;
            _gCVPCheckLogic = gCVPCheckLogic;

            _loanApplicationRepo = loanApplicationRepo;
            _fileService = fileServiceResolver(FileServiceTypeEnum.Database);
            _repo = repo;
        }

        public async Task Start(Guid applicationId)
        {
            var _app = await _loanApplicationRepo.GetQueryable(x => x.Id == applicationId)
                .Include(x => x.User)
                .FirstOrDefaultAsync();
                        
            var finAnalysis = await _repo.GetQueryable(x => x.LoanApplicationId == applicationId).FirstOrDefaultAsync();
            if (finAnalysis == null)
            {
                finAnalysis = new Shared.Data.Context.FinAnalysis
                {
                    LoanApplicationId = applicationId
                };
            }

            try
            {
                //await Affilition(finAnalysis, );
                finAnalysis.Status = RejectStatuses.Correct;
                await PostCamunda(finAnalysis, _app.ProcessInstanceId.ToString(), "success");
            }
            catch (Exception e)
            {
                Log.Error("Ошибка фин анализа: " + e.Message);
                finAnalysis.Status = RejectStatuses.ServiceUnavailable;
                await PostCamunda(finAnalysis, _app.ProcessInstanceId.ToString(), "error");
            }
        }

        private async Task PKBCheck(Shared.Data.Context.FinAnalysis finAnalysis, string identifier)
        {
            #region ПКБ

            var _pkbId = await _PKBLogic.GetPKBXml(identifier);
            if (_pkbId.HasValue)
            {
                //проверка из публичных источников
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

                    var fileStream = await _PKBLogic.GetPKBFile(identifier);

                    var formFile = new FormFile(fileStream, 0, fileStream.Length, "PKB", "PKB.pdf")
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = "application/pdf"
                    };

                    await _fileService.UploadAsync(formFile, EntityType.PKB, finAnalysis.LoanApplicationId);

                    if (finAnalysis.Inactive != RejectStatuses.Correct || finAnalysis.TaxArrear != RejectStatuses.Correct
                        || finAnalysis.Aliment != RejectStatuses.Correct)
                    {
                        finAnalysis.Status = RejectStatuses.Minor;
                        await PostCamunda(finAnalysis);
                        throw new RestException(System.Net.HttpStatusCode.BadRequest);
                    }
                    if (finAnalysis.FalseBusiness != RejectStatuses.Correct || finAnalysis.Bankrupt != RejectStatuses.Correct
                        || finAnalysis.WantedIncome != RejectStatuses.Correct || finAnalysis.LostPeople != RejectStatuses.Correct
                        || finAnalysis.TaxesBankrupt != RejectStatuses.Correct || finAnalysis.Pedophily != RejectStatuses.Correct
                        || finAnalysis.TerrorList != RejectStatuses.Correct)
                    {
                        finAnalysis.Status = RejectStatuses.Critical;
                        await PostCamunda(finAnalysis);
                        throw new RestException(System.Net.HttpStatusCode.BadRequest);
                    }
                }
            }
            else
            {
                Log.Error("Сервис ПКБ не ответил");
                finAnalysis.Status = RejectStatuses.ServiceUnavailable;
                await PostCamunda(finAnalysis);
                throw new RestException(System.Net.HttpStatusCode.BadRequest, "Сервис ПКБ не ответил");
            }

            #endregion
        }

        private async Task GCVPCheck(Shared.Data.Context.FinAnalysis finAnalysis, string iin)
        {
            var _gcvpId = await _GCVPLogic.GetGCVP(iin);
            if (_gcvpId != null)
            {
                var _gcvp = _gCVPCheckLogic.CallCheckPublicSources((Guid)_gcvpId);
                if (_gcvp.Status != GCVP.GCVPStatus.Error)
                {
                    finAnalysis.FinAnalysisIncomes = _gcvp?.DeductionList?.Select(x => new Shared.Data.Context.FinAnalysisIncome
                    {
                        Sum = x.Amount,
                        Date = x.PaymentDate,
                        Name = x.OrganizationName
                    }).ToList();
                }
            }
            else
            {
                Log.Error("Сервис ГЦВП не ответил");
                finAnalysis.Status = RejectStatuses.ServiceUnavailable;
                await PostCamunda(finAnalysis);
                return;
            }
        }

        private async Task GKB(Shared.Data.Context.FinAnalysis finAnalysis, string iin)
        {
          
            var _gkb = await _GKBLogic.GetCreditReportTypes(iin);
            var proceed = _gkb.Count > 0 && !_gkb.All(x => x.Key == ReportTypes.CreditNoData);
            if (proceed)
            {
                if (_gkb.Any(x => x.Key == ReportTypes.Negative))
                {
                    finAnalysis.GKBReuslt = RejectStatuses.Critical;
                    Log.Error("Негативный отчет из ГКБ");
                    finAnalysis.Status = RejectStatuses.Critical;
                    await PostCamunda(finAnalysis);
                    return;
                }

                var reportName = ReportType.MostDetailedType(_gkb);
                var _gkbId = await _GKBLogic.GetGKBX(iin, reportName);
                if (_gkbId == default)
                {
                    Log.Error("Сервис ГКБ не ответил");
                    finAnalysis.Status = RejectStatuses.ServiceUnavailable;
                    await PostCamunda(finAnalysis);
                    return;
                }
                else
                {
                    var _gkbFile = await _GKBLogic.GetGKBFile(iin);

                    var fileStream = new MemoryStream(_gkbFile);
                    var formFile = new FormFile(fileStream, 0, fileStream.Length, $"{iin}_Credit_Report", $"{iin}_Credit_Report.pdf")
                    {
                        Headers = new HeaderDictionary(),
                        ContentType = "application/pdf"
                    };

                    finAnalysis.CreditReportId = (await _fileService.UploadAsync(formFile, EntityType.GKB, finAnalysis.LoanApplicationId)).Id;

                    //получение массива кредитных обязательств из кредитного отчета
                    var gkbMonthlyPayByFinInstitutResult = _overdueCheck.CallMonthlyPayByFinInstitut((Guid)_gkbId);
                    finAnalysis.FinAnalysisLoanPayments = gkbMonthlyPayByFinInstitutResult?.Select(x => new Shared.Data.Context.FinAnalysisLoanPayment
                    {
                        Payments = x.Payments,
                        Currency = x.Currency,
                        FinInstitut = x.FinInstitut,
                        PeriodPayments = x.PeriodPayments,
                        PeriodPaymentsName = x.PeriodPaymentsName
                    }).ToList();

                    //проверка на текущие просрочки
                    var gkbCallExistenceOfAmountDPDResult = await _overdueCheck.CallExistenceOfAmountDPD((Guid)_gkbId);
                    finAnalysis.ExistenceOfAmountDPD = gkbCallExistenceOfAmountDPDResult.isReject;
                    finAnalysis.SumOverdueAmount = gkbCallExistenceOfAmountDPDResult.vars.CountOverdueAmount;

                    if (gkbCallExistenceOfAmountDPDResult.isReject
                        && gkbCallExistenceOfAmountDPDResult.vars.CountOverdueAmount > 0)
                    {
                        finAnalysis.Status = RejectStatuses.Minor;
                    }

                    ////проверяет просрочки за последние 24 месяца (2 года) 
                    var gkbExistenceDPDPastInToYearsResult = await _overdueCheck.CallExistenceDPDPastInToYears((Guid)_gkbId);
                    finAnalysis.CountDPDPastInToYears = gkbExistenceDPDPastInToYearsResult.vars.CountDPDPastInToYears;
                    finAnalysis.ExistDPDPastInToYears = gkbExistenceDPDPastInToYearsResult.isReject;

                    if (gkbExistenceDPDPastInToYearsResult.isReject
                        && gkbExistenceDPDPastInToYearsResult.vars.CountDPDPastInToYears > 90)
                    {
                        finAnalysis.Status = RejectStatuses.Minor;
                    }

                    //получение кредитных обязательств из кредитного отчета за послдение 12 месяца
                    var gkbCallGetAnnualPayResult = _overdueCheck.CallGetAnnualPay((Guid)_gkbId);
                    finAnalysis.AnnualPay = gkbCallGetAnnualPayResult;
                }
            }
        }

        private async void ASP(Shared.Data.Context.FinAnalysis finAnalysis, string iin)
        {
            //АСП
            var _asp = await _ASPLogic.GetASP(iin);
            finAnalysis.IsASA = _asp;
            
        }
        private async void ZAGS(Shared.Data.Context.FinAnalysis finAnalysis, string iin)
        {
            //ЗАГС
            var _zags = await _ZAGSLogic.GetZAGS(iin);
            finAnalysis.IsManyChildren = false;
        }

        private async void AnnualPay(Shared.Data.Context.FinAnalysis finAnalysis)
        {
            //проверка кредитных обязательств
            if ((bool)finAnalysis.IsASA || (bool)finAnalysis.IsManyChildren)
            {
                if (finAnalysis.AnnualPay != default && finAnalysis.AnnualPay > 758891)
                {
                    finAnalysis.Status = RejectStatuses.Minor;
                    finAnalysis.AnnualPaySuccess = false;
                    await PostCamunda(finAnalysis);
                }
            }
            else
            {
                if (finAnalysis.AnnualPay != default && finAnalysis.AnnualPay > 701347)
                {
                    finAnalysis.Status = RejectStatuses.Minor;
                    finAnalysis.AnnualPaySuccess = false;
                    await PostCamunda(finAnalysis);
                }
            }
        }

        private async Task PostCamunda(Shared.Data.Context.FinAnalysis finAnalysis, string processId = null, string isReject = null)
        {
            var exists = _repo.GetQueryable(x => x.Id == finAnalysis.Id).Any();
            if (exists)
                await _repo.Update(finAnalysis);
            else
                await _repo.Add(finAnalysis);
        }
    }    
}
