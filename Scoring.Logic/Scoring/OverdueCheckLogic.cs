using System;
using System.Xml;
using static Agro.Shared.Data.Context.PolicyRules;
using Agro.Shared.Data.Repos.OutService;
using System.Threading.Tasks;
using System.Collections.Generic;
using Agro.Shared.Data.Repos.FinAnalysis;
using Microsoft.EntityFrameworkCore;

namespace Agro.Scoring.Logic.Scoring
{
    public class OverdueCheckLogic : IOverdueCheckLogic
    {
        private readonly IOutServiceRepo _outServiceRepo;
        private readonly IFinAnalysisRepo _finAnalysisRepo;
        public OverdueCheckLogic(IOutServiceRepo outServiceRepo, IFinAnalysisRepo finAnalysisRepo)
        {
            _outServiceRepo = outServiceRepo;
            _finAnalysisRepo = finAnalysisRepo;
        }

        public async Task<PolicyResult> CallExistenceOfAmountDPD(Guid outServiceId)
        {
            var outServiceResult = await _outServiceRepo.GetById(outServiceId);
            string responseContent = outServiceResult.ResponseContent;
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(responseContent);
            return ExistenceOfAmountDPD(xml);
        }

        public PolicyResult CallExistenceOfAmountDPD(XmlDocument MainXml)
        {
            return ExistenceOfAmountDPD(MainXml);
        }

        public Task<PolicyResult> CallExistenceDPDPastInToYears(Guid outServiceId)
        {
            string responseContent = _outServiceRepo.GetById(outServiceId).Result.ResponseContent;
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(responseContent);
            return ExistenceDPDPastInToYears(xml);
        }

        public Task<PolicyResult> CallExistenceDPDPastInToYears(XmlDocument MainXml)
        {
            return ExistenceDPDPastInToYears(MainXml);
        }


        public double CallGetAnnualPay(Guid outServiceId)
        {
            string responseContent = _outServiceRepo.GetById(outServiceId).Result.ResponseContent;
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(responseContent);
            return GetAnnualPay(xml);
        }

        public double CallGetAnnualPay(XmlDocument MainXml)
        {
            return GetAnnualPay(MainXml);
        }

        public List<MonthlyPay> CallMonthlyPayByFinInstitut(Guid outServiceId)
        {
            string responseContent = _outServiceRepo.GetById(outServiceId).Result.ResponseContent;
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(responseContent);
            return GetMonthlyPayByFinInstitut(xml);
        }

        public List<MonthlyPay> CallMonthlyPayByFinInstitut(XmlDocument MainXml)
        {
            return GetMonthlyPayByFinInstitut(MainXml);
        }

        /*
        //записываем значение по текущей просрочке в БД 
        private async Task UpdateFinAnalysisExistCurrentOverdue(Guid ApplicationID, double currentOverdue) {

            var finAnalysis = await _finAnalysisRepo.GetQueryable(x => x.LoanApplicationId == ApplicationID).FirstOrDefaultAsync();
            if (finAnalysis != null)
            {
                finAnalysis.ExistenceOfAmountDPD = true;
                finAnalysis.CountOverdueDPD = currentOverdue;
            }
        }*/

        //Наличие текущей просрочки по кредитам
        /// <summary>
        /// наличие текущей просрочки по запросу ГКБ
        /// </summary>
        /// <param name="MainXml"></param>
        /// <returns></returns>
        private PolicyResult ExistenceOfAmountDPD(XmlDocument MainXml)
        {
            PolicyResult result = new PolicyResult();
            result.vars = new PolicyVars();
            result.isReject = false;
            XmlNodeList Contracts;
            if (MainXml.SelectNodes("//Root/ExistingContracts/Contract") != null)
            {
                Contracts = MainXml.SelectNodes("//Root/ExistingContracts/Contract");
            }
            else
            {
                return result;
            }
            foreach (XmlNode nodeContract in Contracts)
            {
                double overdueAmount = 0, overdueAmountCalendar = 0;
                int DPDCount = 0, DPDCountCalendar = 0;

                XmlDocument Contract = new XmlDocument();
                Contract.LoadXml(nodeContract.OuterXml);
                if (Contract.SelectSingleNode("//NumberOfOverdueInstalments") != null)
                {
                    DPDCount = GetNumberOfOverdueInstalments(Contract);
                }

                if (Contract.SelectSingleNode("//OverdueAmount") != null)
                {
                    overdueAmount = GetCurrentPDPAmount(Contract);
                }

                DPDCountCalendar = SearchOverdueInCalendar(Contract, ref overdueAmountCalendar);
                if (overdueAmount > 0 || overdueAmountCalendar > 0 || DPDCount > 0 || DPDCountCalendar > 0)
                {

                    result.isReject = true;
                    result.PolicyRejectReason = "Наличие текущей просроченной задолженности по данным отчета ПКБ";
                    result.vars.ExistenceOfAmountDPD = true;
                    result.vars.CountOverdueAmount = overdueAmount;
                    result.CheckStatus = RejectStatuses.Minor;
                    return result;
                }
            }
            return result;
        }

        //5)Наличие исторической просрочки за последние 24 месяца:
        /// <summary>
        /// наличие текущей просрочки за последние 2 года
        /// </summary>
        /// <param name="MainXml"></param>
        /// <returns></returns>
        private async Task<PolicyResult> ExistenceDPDPastInToYears(XmlDocument MainXml)
        {
            PolicyResult result = new PolicyResult();
            result.vars = new PolicyVars();
            result.isReject = false;
            XmlNodeList TerminatedContracts;

            if (MainXml.SelectNodes("//Root/TerminatedContracts/Contract") != null)
            {
                TerminatedContracts = MainXml.SelectNodes("//Root/TerminatedContracts/Contract");
                result = await GetMaxPDPAndAmountInCalendar(TerminatedContracts, "TerminatedContracts", result, 24);
                if (result.isReject) return result;
            }
            if (MainXml.SelectNodes("//Root/ExistingContracts/Contract") != null)
            {
                TerminatedContracts = MainXml.SelectNodes("//Root/ExistingContracts/Contract");
                result = await GetMaxPDPAndAmountInCalendar(TerminatedContracts, "ExistingContracts", result, 24);
                if (result.isReject) return result;
            }
            return result;
        }

        //получаем максимальное количество дней просрочки в календаре 
        private async Task<PolicyResult> GetMaxPDPAndAmountInCalendar(XmlNodeList Contracts, string ContractType, PolicyResult result, int IsInto24Month)
        {
            var maxDayPDP = 0;

            foreach (XmlNode nodeContract in Contracts)
            {
                XmlDocument Contract = new XmlDocument();
                Contract.LoadXml(nodeContract.OuterXml);
                DateTime CurrentDate = DateTime.Now;
                DateTime CheckDateOfRealRepayment = DateTime.Now.AddDays(1);
                string DateOfRealRepayment = "";
                if (ContractType == "TerminatedContracts")
                {
                    DateOfRealRepayment = Contract.SelectSingleNode("//DateOfRealRepayment/@value").InnerText;
                    if (DateOfRealRepayment != "" && DateOfRealRepayment != "-" && DateOfRealRepayment != "_")
                    {
                        CurrentDate = DateTime.Parse(DateOfRealRepayment);
                        CheckDateOfRealRepayment = CurrentDate.AddMonths(IsInto24Month);
                    }
                    else
                    {
                        DateOfRealRepayment = Contract.SelectSingleNode("//DateOfCreditEnd/@value").InnerText;
                        if (DateOfRealRepayment != "" && DateOfRealRepayment != "-" && DateOfRealRepayment != "_")
                        {
                            CurrentDate = DateTime.Parse(DateOfRealRepayment);
                            CheckDateOfRealRepayment = CurrentDate.AddMonths(IsInto24Month);
                        }
                    }
                }
                if (CheckDateOfRealRepayment > DateTime.Now)
                {
                    CurrentDate = DateTime.Now;

                    int CurrentYear = CurrentDate.Year;
                    int CurrentMonth = CurrentDate.Month;

                    int BeginYear = CurrentDate.AddMonths(-24).Year;
                    int BeginMonth = CurrentDate.AddMonths(-24).Month;

                    int YearCount = Contract.SelectNodes("//PaymentsCalendar/Year").Count;
                    for (int i = 0; i < YearCount; i++)
                    {
                        int year = int.Parse(Contract.SelectNodes("//PaymentsCalendar/Year")[i].SelectSingleNode("@title").Value);
                        if (year >= BeginYear)
                        {
                            XmlDocument Year = new XmlDocument();
                            Year.LoadXml(Contract.SelectNodes("//PaymentsCalendar/Year")[i].OuterXml);
                            for (int j = 0; j < 12; j++)
                            {
                                int PaymentMonths =
                                    int.Parse(Year.SelectNodes("//Payment")[j].SelectSingleNode("@number").Value);
                                if (PaymentMonths >= BeginMonth && year == BeginYear ||
                                    PaymentMonths <= CurrentMonth && year == CurrentYear)
                                {
                                    string currentPDP =
                                        Year.SelectNodes("//Payment")[j].SelectSingleNode("@value").Value;
                                    if (currentPDP != "" && currentPDP != "_" && currentPDP != "-")
                                    {
                                        maxDayPDP = int.Parse(currentPDP);
                                    }
                                    if (maxDayPDP > 90)
                                    {
                                        result.isReject = true;
                                        result.vars.ExistenceDPDPastInToYears = true;
                                        result.vars.CountDPDPastInToYears = maxDayPDP;
                                        result.PolicyRejectReason = "Наличие исторической просрочки за последние 24 месяца";
                                        result.CheckStatus = RejectStatuses.Critical;
                                        return result;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }



        /// <summary>
        /// расчет текущих обязательств относительно ежемесячного платежа 
        /// </summary>
        /// <param name="MainXml"></param>
        /// <returns></returns>
        private List<MonthlyPay> GetMonthlyPayByFinInstitut(XmlDocument MainXml)
        {
            List<MonthlyPay> monthPays = new List<MonthlyPay>();
            double payCurrent = 0;
            //FinancialInstitution
            XmlNodeList Contracts;
            if (MainXml.SelectNodes("//Root/ExistingContracts/Contract") != null)
            {
                Contracts = MainXml.SelectNodes("//Root/ExistingContracts/Contract");
            }
            else
            {
                return monthPays;
            }

            foreach (XmlNode nodeContract in Contracts)
            {
                string Currency;
                XmlDocument Contract = new XmlDocument();
                Contract.LoadXml(nodeContract.OuterXml);
                string SubjectRole = "";
                double periodicityOfPayments = 0;
                string financialInstitution = "";
                string periodicityOfPaymentsValue = "";
                string periodicityOfPaymentsStr = "";
                DateTime dateOfCreditEnd = DateTime.Now;

                if (Contract.SelectSingleNode("//SubjectRole") != null) //Роль субъекта
                {
                    SubjectRole = Contract.SelectSingleNode("//SubjectRole/@value").Value;
                }

                if (Contract.SelectSingleNode("//FinancialInstitution") != null) //Источник информации (Кредитор)
                {
                    financialInstitution = Contract.SelectSingleNode("//FinancialInstitution/@id").Value;
                }

                if (Contract.SelectSingleNode("//PeriodicityOfPayments") != null) //Периодичность платежей
                {
                    periodicityOfPaymentsStr = Contract.SelectSingleNode("//SubjectRole/@id")?.Value;
                    if (periodicityOfPaymentsStr != null && periodicityOfPaymentsStr != "" && periodicityOfPaymentsStr != "_" && periodicityOfPaymentsStr != "-")
                    {
                        periodicityOfPaymentsStr = Contract.SelectSingleNode("//SubjectRole/@id").Value;
                        periodicityOfPaymentsValue = Contract.SelectSingleNode("//PeriodicityOfPayments/@value").Value;
                    }
                    else { periodicityOfPayments = 0; }
                }

                

                switch (periodicityOfPaymentsStr)
                {
                    case "1": periodicityOfPayments = 15; break;  //1 раз в две недели 
                    case "2": periodicityOfPayments = 30; break;  //ежемесячно
                    case "3": periodicityOfPayments = 60; break;   //1 раз в два месяца
                    case "4": periodicityOfPayments = 90; break;   //ежеквартально 
                    case "5": periodicityOfPayments = 120; break;   //1 раз в 4 месяца 
                    case "6": periodicityOfPayments = 150; break; //1 раз в пять месяце 
                    case "7": periodicityOfPayments = 180; break;   //полугодовой платеж 
                    case "8": periodicityOfPayments = 360; break;   //платеж раз в год
                    case "9": periodicityOfPayments = 360; break;   //в день истечения срока
                    case "10": periodicityOfPayments = 360; break;  //взносы с не регулярной периодичностью
                    case "11": periodicityOfPayments = 7; break; //раз в неделю 
                    default: periodicityOfPayments = 360; break;
                }

                if (SubjectRole.Contains("Заёмщик") || SubjectRole.Contains("Заемщик") ||
                     SubjectRole.Contains("Созаемщик") || SubjectRole.Contains("Созаёмщик"))
                {
                    {
                        string payCurrentStr = Contract.SelectSingleNode("//MonthlyInstalmentAmount/@value").Value;
                        payCurrent = FindAmountFromStr(payCurrentStr, out Currency);
                        monthPays.Add(new MonthlyPay
                        {
                            Payments = payCurrent,
                            Currency = Currency,
                            FinInstitut = financialInstitution,
                            PeriodPayments = periodicityOfPayments,
                            PeriodPaymentsName = periodicityOfPaymentsValue
                        });
                    }
                }
            }
            return monthPays;
        }

        /// <summary>
        /// расчет текущих обязательств
        /// </summary>
        /// <param name="MainXml"></param>
        /// <returns></returns>
        internal double GetAnnualPay(XmlDocument MainXml)
        {
            double payCurrent = 0;
            //FinancialInstitution
            XmlNodeList Contracts;
            if (MainXml.SelectNodes("//Root/ExistingContracts/Contract") != null)
            {
                Contracts = MainXml.SelectNodes("//Root/ExistingContracts/Contract");
            }
            else
            {
                return 0;
            }

            foreach (XmlNode nodeContract in Contracts)
            {
                string Currency;
                XmlDocument Contract = new XmlDocument();
                Contract.LoadXml(nodeContract.OuterXml);
                string SubjectRole = "";
                double periodicityOfPayments = 0;
                int DayCount = 0;
                string periodicityOfPaymentsStr = "";
               
                DateTime dateOfCreditEnd = DateTime.Now;

                if (Contract.SelectSingleNode("//SubjectRole") != null) //Роль субъекта
                {
                    SubjectRole = Contract.SelectSingleNode("//SubjectRole/@value").Value;
                }

                if (Contract.SelectSingleNode("//PeriodicityOfPayments") != null) //Периодичность платежей
                {
                    periodicityOfPaymentsStr = Contract.SelectSingleNode("//PeriodicityOfPayments/@id").Value;
                    if (periodicityOfPaymentsStr != "" && periodicityOfPaymentsStr != "_" && periodicityOfPaymentsStr != "-")
                    {
                        periodicityOfPaymentsStr = Contract.SelectSingleNode("//PeriodicityOfPayments/@id").Value;
                       
                    }
                    else { periodicityOfPayments = 0; }
                }

                switch (periodicityOfPaymentsStr)
                {
                    case "1": periodicityOfPayments = 15; break;  //1 раз в две недели 
                    case "2": periodicityOfPayments = 30; break;  //ежемесячно
                    case "3": periodicityOfPayments = 60; break;   //1 раз в два месяца
                    case "4": periodicityOfPayments = 90; break;   //ежеквартально 
                    case "5": periodicityOfPayments = 120; break;   //1 раз в 4 месяца 
                    case "6": periodicityOfPayments = 150; break; //1 раз в пять месяце 
                    case "7": periodicityOfPayments = 180; break;   //полугодовой платеж 
                    case "8": periodicityOfPayments = 360; break;   //платеж раз в год
                    case "9": periodicityOfPayments = 360; break;   //в день истечения срока
                    case "10": periodicityOfPayments = 360; break;  //взносы с не регулярной периодичностью
                    case "11": periodicityOfPayments = 7; break; //раз в неделю 
                    default: periodicityOfPayments = 360; break;
                }

                string DateOfRealRepayment = Contract.SelectSingleNode("//DateOfCreditEnd/@value").InnerText;
                if (DateOfRealRepayment != "" && DateOfRealRepayment != "-" && DateOfRealRepayment != "_")
                {
                    dateOfCreditEnd = DateTime.Parse(DateOfRealRepayment);
                }

                TimeSpan diff1 = dateOfCreditEnd.Subtract(DateTime.Now);
                DayCount = diff1.Days + 1;
                if (DayCount > 360) DayCount = 360;
                periodicityOfPayments = DayCount / periodicityOfPayments;

                if (SubjectRole.Contains("Заёмщик") || SubjectRole.Contains("Заемщик") ||
                     SubjectRole.Contains("Созаемщик") || SubjectRole.Contains("Созаёмщик"))
                {
                    {
                        string payCurrentStr = Contract.SelectSingleNode("//MonthlyInstalmentAmount/@value").Value;
                        payCurrent = payCurrent + FindAmountFromStr(payCurrentStr, out Currency) * periodicityOfPayments;
                    }
                }
            }

            return payCurrent;
        }

        private int GetNumberOfOverdueInstalments(XmlDocument Contract)
        {
            string OverdueAmount = Contract.SelectSingleNode("//NumberOfOverdueInstalments/@value").Value;
            if (OverdueAmount != "" && OverdueAmount != "_" && OverdueAmount != "-")
            {
                return int.Parse(OverdueAmount);
            }
            return 0;
        }


        private double GetCurrentPDPAmount(XmlDocument Contract)
        {
            string OverdueAmount = Contract.SelectSingleNode("//OverdueAmount/@value").Value;
            if (OverdueAmount != "" && OverdueAmount != "_" && OverdueAmount != "-")
            {
                string Currency = "";
                return FindAmountFromStr(OverdueAmount, out Currency);
            }
            return 0;
        }
        //ищем текущую  просрочку в календаре 
        private int SearchOverdueInCalendar(XmlDocument Contract, ref double CurrentOverdueAmount/*, ref double fineAmount, ref double PenaltyAmount*/)
        {
            string lastUpdatestr = Contract.SelectSingleNode("//LastUpdate/@value").Value;
            if (lastUpdatestr == "-" || lastUpdatestr == "_" || string.IsNullOrEmpty(lastUpdatestr))
            {
                return 0;
            }
            DateTime lastUpdate = DateTime.Parse(Contract.SelectSingleNode("//LastUpdate/@value").Value);
            int maxDayPDP = 0;
            string Currency = "";
            int CurrentYear = lastUpdate.Year; //CliInfo.RequestDate.Year;
            int CurrentMonth = lastUpdate.Month;

            int YearCount = Contract.SelectNodes("//PaymentsCalendar/Year").Count;
            for (int i = 0; i < YearCount; i++)
            {
                int year = int.Parse(Contract.SelectNodes("//PaymentsCalendar/Year")[i].SelectSingleNode("@title").Value);
                if (year == CurrentYear)
                {
                    XmlDocument Year = new XmlDocument();
                    Year.LoadXml(Contract.SelectNodes("//PaymentsCalendar/Year")[i].OuterXml);
                    for (int j = 0; j < 12; j++)
                    {
                        int PaymentMonths = int.Parse(Year.SelectNodes("//Payment")[j].SelectSingleNode("@number").Value);
                        if (PaymentMonths == CurrentMonth && year == CurrentYear)
                        {
                            string currentPDP = Year.SelectNodes("//Payment")[j].SelectSingleNode("@value").Value;
                            string currentPDPAmount = Year.SelectNodes("//Payment")[j].SelectSingleNode("@overdue").Value;

                            //string fine = Year.SelectNodes("//Payment")[j].SelectSingleNode("@fine").Value;
                            //string penalty = Year.SelectNodes("//Payment")[j].SelectSingleNode("@penalty").Value;

                            if (currentPDP != "" && currentPDP != "_" && currentPDP != "-")
                            {
                                maxDayPDP = int.Parse(currentPDP);
                            }

                            if (currentPDPAmount != "" && currentPDPAmount != "_" &&
                                currentPDPAmount != "-" && currentPDPAmount != "0" &&
                                currentPDPAmount != "0,00" && currentPDPAmount != "0.00")
                            {
                                CurrentOverdueAmount = FindAmountFromStr(currentPDPAmount, out Currency);
                            }
                            break;
                        }
                    }
                }
            }
            return maxDayPDP;
        }

        //пеня
        private double GetCurrentFine(XmlDocument Contract)
        {
            string OverdueAmount = Contract.SelectSingleNode("//Fine/@value").Value;
            if (OverdueAmount != "" && OverdueAmount != "_" && OverdueAmount != "-")
            {
                string Currency = "";
                return FindAmountFromStr(OverdueAmount, out Currency);
            }
            return 0;
        }

        //штраф
        private double GetCurrentPenalty(XmlDocument Contract)
        {
            string OverdueAmount = Contract.SelectSingleNode("//Penalty/@value").Value;
            if (OverdueAmount != "" && OverdueAmount != "_" && OverdueAmount != "-")
            {
                string Currency = "";
                return FindAmountFromStr(OverdueAmount, out Currency);
            }
            return 0;
        }

        private static double FindAmountFromStr(string NPay, out string Currency)
        {
            Currency = "KZT";
            int ValIndex = 0;
            double NPayCurrent;
            if (NPay == "")
            {
                return 1;
            }
            if (NPay.IndexOf("KZT", StringComparison.Ordinal) > 0)
            {
                ValIndex = NPay.IndexOf("KZT", StringComparison.Ordinal);
                Currency = "KZT";
            }
            else if (NPay.IndexOf("USD", StringComparison.Ordinal) > 0)
            {
                ValIndex = NPay.IndexOf("USD", StringComparison.Ordinal);
                Currency = "USD";
            }
            else if (NPay.IndexOf("EUR", StringComparison.Ordinal) > 0)
            {
                ValIndex = NPay.IndexOf("EUR", StringComparison.Ordinal);
                Currency = "EUR";
            }
            else if (NPay.IndexOf("RUB", StringComparison.Ordinal) > 0)
            {
                ValIndex = NPay.IndexOf("RUB", StringComparison.Ordinal);
                Currency = "RUB";
            }
            else if (NPay.IndexOf("RUR", StringComparison.Ordinal) > 0)
            {
                ValIndex = NPay.IndexOf("RUR", StringComparison.Ordinal);
                Currency = "RUR";
            }
            string PaySum = NPay.Substring(0, ValIndex - 1);
            if (double.TryParse(PaySum, out NPayCurrent))
            {
                return NPayCurrent;
            }
            return 0;
        }


    }
}
