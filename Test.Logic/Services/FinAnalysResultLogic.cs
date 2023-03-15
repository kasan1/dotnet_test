using Agro.Okaps.Logic.Models;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Repos.FinAnalysis;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using static Agro.Shared.Data.Context.PolicyRules;

namespace Agro.Okaps.Logic
{
    [AllowAnonymous]
    public class FinAnalysResultLogic : IFinAnalysResultLogic
    {

        private readonly IFinAnalysisRepo _finAnalysRepo;

        public FinAnalysResultLogic(IFinAnalysisRepo finAnalysRepo)
        {
            _finAnalysRepo = finAnalysRepo;
        }

        public async Task<object> GetFinAnalysResult(Guid ApplicationId)
        {
            var res = await _finAnalysRepo.GetQueryable(x => x.LoanApplicationId == ApplicationId).FirstOrDefaultAsync();
            if (res == null)
                return null;

            var finOut = new FinAnalysOutDto
            {
                Status = res.Status,

                IsManyChildren = res.IsManyChildren.HasValue ? res.IsManyChildren.Value : false,
                FalseBusiness = res.FalseBusiness,
                Bankrupt = res.Bankrupt,
                WantedIncome = res.WantedIncome,
                Inactive = res.Inactive,
                TaxesBankrupt = res.TaxesBankrupt,
                TaxArrear = res.TaxArrear,
                TerrorList = res.TerrorList,
                Aliment = res.Aliment,
                Pedophily = res.Pedophily,
                LostPeople = res.LostPeople,
                IsAffiliation = res.Affiliation,
                AnnualPay = res.AnnualPay,
                IsAsa = res.IsASA,

                CreditReportId = res.CreditReportId
            };

            if (res.ExistenceOfAmountDPD)
            {
                finOut.CreditHistory = RejectStatuses.Minor;
                finOut.CreditHistoryDetail = "Количество дней текущей просрочки " + res.SumOverdueAmount;
            }
            else if (res.ExistDPDPastInToYears)
            {
                finOut.CreditHistory = RejectStatuses.Critical;
                finOut.CreditHistoryDetail = "Количество дней непрерывной просрочки состовляет " + res.CountDPDPastInToYears;
            }
            else
            {
                finOut.CreditHistory = RejectStatuses.Correct;

            }

            return finOut;
        }

        public async Task<object> GetFinAnalysResultForClient(Guid ApplicationId)
        {

            var res = await _finAnalysRepo.GetQueryable(x => x.LoanApplicationId == ApplicationId).OrderByDescending(x => x.ModifiedDate).FirstOrDefaultAsync();
            if (res == null)
                return null;
            var finClientOut = new FinAnalysCliOutDto
            {
                RejectDetails = new List<string>()
            };
            var finOut1 = new FinAnalysOutDto();

            finClientOut.Status = res.Status;

            
            if (res.FalseBusiness == RejectStatuses.Critical || res.FalseBusiness == RejectStatuses.Minor)
                finClientOut.RejectDetails.Add(finOut1.FalseBusinessDetail);
            if (res.Bankrupt == RejectStatuses.Critical || res.Bankrupt == RejectStatuses.Minor)
                finClientOut.RejectDetails.Add(finOut1.BankruptDetail);
            if (res.WantedIncome == RejectStatuses.Critical || res.WantedIncome == RejectStatuses.Minor)
                finClientOut.RejectDetails.Add(finOut1.WantedIncomeDetail);
            if (res.Inactive == RejectStatuses.Critical || res.Inactive == RejectStatuses.Minor)
                finClientOut.RejectDetails.Add(finOut1.InactiveDetail);
            if (res.TaxesBankrupt == RejectStatuses.Critical || res.TaxesBankrupt == RejectStatuses.Minor)
                finClientOut.RejectDetails.Add(finOut1.TaxesBankruptDetail);
            if (res.TaxArrear == RejectStatuses.Critical || res.TaxArrear == RejectStatuses.Minor)
                finClientOut.RejectDetails.Add(finOut1.TaxArrearDetail);
            if (res.TerrorList == RejectStatuses.Critical || res.TerrorList == RejectStatuses.Minor)
                finClientOut.RejectDetails.Add(finOut1.TerrorListDetail);
            if (res.Aliment == RejectStatuses.Critical || res.Aliment == RejectStatuses.Minor)
                finClientOut.RejectDetails.Add(finOut1.AlimentDetail);
            if (res.Pedophily == RejectStatuses.Critical || res.Pedophily == RejectStatuses.Minor)
                finClientOut.RejectDetails.Add(finOut1.PedophilyDetail);
            if (res.LostPeople == RejectStatuses.Critical || res.LostPeople == RejectStatuses.Minor)
                finClientOut.RejectDetails.Add(finOut1.LostPeopleDetail);
            if (res.Affiliation == RejectStatuses.Critical || res.Affiliation == RejectStatuses.Minor)
                finClientOut.RejectDetails.Add(finOut1.AffiliationDetail);

            if (finClientOut.Status == RejectStatuses.ServiceUnavailable)
            {
                finClientOut.FinalErrorMessage = "Ваша заявка находится в работе";
                finClientOut.RejectDetails.Add("Ваша заявка находится в работе, попробуйте позже...");
            }

            string Minordetails = "";
            foreach(string deteail in finClientOut.RejectDetails)
            {
                Minordetails = Minordetails + deteail +" ";
            }

        
            if (finClientOut.Status == RejectStatuses.Minor)
            {
                finClientOut.FinalErrorMessage = "Сбор информации по Вашей заявке произведен. Присутствует отрицательная информация," +
                Minordetails + ", которую можно устранить. После чего Вам необходимо повторно подать заявку через Ваш личный кабинет.";
            }

            if (finClientOut.Status == RejectStatuses.Critical || res.ExistDPDPastInToYears)
            {
                finClientOut.FinalErrorMessage = "Сбор информации по Вашей заявке произведен. Кредитование невозможно, так как присутствует отрицательная информация, " +
                    "не соответствующая Кредитной и Залоговой политикам Общества.";
            }

            if (finClientOut.Status == RejectStatuses.ServiceUnavailable)
            {
                finClientOut.FinalErrorMessage = "Ваша заявка находится в работе";
            }

            if (res.Affiliation == RejectStatuses.Critical || res.Affiliation == RejectStatuses.Minor)
            {
                finClientOut.FinalErrorMessage = "Сбор информации по Вашей заявке произведен, " +
                    "ввиду наличия признака связанности с Обществом особыми отношениями/аффилированности с АО «Фонд финансовой поддержки сельского хозяйства» " +
                    "Вам необходимо обратиться в филиал/представительство АО «Фонд финансовой поддержки сельского хозяйства»";
            }


            if (res.ExistenceOfAmountDPD)
            {
                finClientOut.CreditHistory = RejectStatuses.Minor;
                finClientOut.CreditHistoryDetail = "Количество дней текущей просрочки " + res.SumOverdueAmount;
                finClientOut.FinalErrorMessage = "Сбор информации по Вашей заявке произведен. Присутствует отрицательная информация," +
                    finClientOut.CreditHistoryDetail + ", которую можно устранить. После чего Вам необходимо повторно подать заявку через Ваш личный кабинет.";

            }
            else if (res.ExistDPDPastInToYears)
            {
                finClientOut.CreditHistory = RejectStatuses.Critical;
                finClientOut.CreditHistoryDetail = "Количество дней непрерывной просрочки состовляет " + res.CountDPDPastInToYears;

            }
            else
            {
                finClientOut.CreditHistory = RejectStatuses.Correct;
            }

            //кредитный обязательства за последние 12 месяцев
            //if (!res.AnnualPaySuccess)
            //{
            //    finClientOut.RejectDetails.Add(finOut1.AnnualPaySuccessDetail);
            //}

            return finClientOut;
        }

    }
}
