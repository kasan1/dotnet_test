using Agro.Integration.Logic.OutService.GKB;
using Agro.Shared.Data.Repos.OutService;
using DocumentFormat.OpenXml.Office2013.Word;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using static Agro.Shared.Data.Context.PolicyRules;

namespace Agro.Scoring.Logic.Scoring.GKB
{
    public class GKBOverdueCheckLogic : IGKBOverdueCheckLogic
    {
        private readonly IOutServiceRepo _outServiceRepo;
        public GKBOverdueCheckLogic(IOutServiceRepo outServiceRepo)
        {
            _outServiceRepo = outServiceRepo;
        }

        /// <summary>
        /// расчет текущих обязательств относительно ежемесячного платежа 
        /// </summary>
        /// <returns></returns>
        public async Task<List<MonthlyPay>> CallMonthlyPayByFinInstitut(Guid id)
        {
            var _outService = await _outServiceRepo.GetQueryable(x => x.Id == Guid.Parse("5f83d4ea-c8c8-485b-9256-08d8554ef7c7")).FirstOrDefaultAsync();
            if (_outService == default && _outService.ResponseContent == default)
                throw new ArgumentException("GKB Xml документ не найден");
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(_outService.ResponseContent);
            var _ = CallMonthlyPayByFinInstitut(xmlDocument);
            return _;
        }

        /// <summary>
        /// расчет текущих обязательств относительно ежемесячного платежа 
        /// </summary>
        /// <returns></returns>
        public List<MonthlyPay> CallMonthlyPayByFinInstitut(XmlDocument xml)
        {
            return GetMonthlyPayByFinInstitut(xml);
        }

        /// <summary>
        /// расчет текущих обязательств относительно ежемесячного платежа 
        /// </summary>
        /// <returns></returns>
        private List<MonthlyPay> GetMonthlyPayByFinInstitut(XmlDocument MainXml)
        {
            var _monthPays = new List<MonthlyPay>();
            XmlNodeList _details;
            if (MainXml.SelectNodes("//creditReportContent/detailsDto") != default)
            {
                _details = MainXml.SelectNodes("//creditReportContent/detailsDto");
            }
            else
            {
                return _monthPays;
            }
            foreach (XmlNode _detailNode in _details)
            {
                var _contracts = new XmlDocument();
                _contracts.LoadXml(_detailNode.OuterXml);
                //только действующие договора
                if (_contracts.SelectSingleNode("//creditPhaseCode").InnerText != "4")
                    continue;
                foreach (XmlNode _contractNode in _contracts.SelectNodes("//detailsDto/contractDetails"))
                {
                    var _contractNodes = new XmlDocument();
                    _contractNodes.LoadXml(_contractNode.OuterXml);
                    //Кредитный договор
                    if (_contractNodes.SelectSingleNode("//contractDetails/creditDiscriminatorCode")?.InnerText == "1")
                    {
                        var _payments = _contractNodes.SelectSingleNode("//contractDetails/monthlyInstalmentAmountDto/monthlyInstalmentAmount")?.InnerText;
                        var _currency = _contractNodes.SelectSingleNode("//contractDetails/monthlyInstalmentAmountDto/currency")?.InnerText;
                        var _finInstitut = _contractNodes.SelectSingleNode("//contractDetails/creditor")?.InnerText;
                        var _periodPayments = _contractNodes.SelectSingleNode("//contractDetails/additionalCreditInformation/dateDeadlines/periodPaymentDebt")?.InnerText;

                        _monthPays.Add(new MonthlyPay
                        {
                            Currency = _currency,
                            FinInstitut = _finInstitut,
                            Payments = Convert.ToDouble(_payments?.Replace(".", ",")),
                            PeriodPayments = 0,
                            PeriodPaymentsName = _periodPayments
                        });
                    }
                    //Рассроченный договор
                    else if (_contractNodes.SelectSingleNode("//contractDetails/creditDiscriminatorCode")?.InnerText == "2")
                    {
                        var _payments = _contractNodes.SelectSingleNode("//contractDetails/instalmentAmountDto/instalmentAmount")?.InnerText;
                        var _currency = _contractNodes.SelectSingleNode("//contractDetails/instalmentAmountDto/currency")?.InnerText;
                        var _finInstitut = _contractNodes.SelectSingleNode("//contractDetails/creditor")?.InnerText;
                        var _periodPayments = _contractNodes.SelectSingleNode("//contractDetails/additionalCreditInformation/dateDeadlines/periodPaymentDebt")?.InnerText;

                        _monthPays.Add(new MonthlyPay
                        {
                            Currency = _currency,
                            FinInstitut = _finInstitut,
                            Payments = Convert.ToDouble(_payments?.Replace(".", ",")),
                            PeriodPayments = 0,
                            PeriodPaymentsName = _periodPayments
                        });
                    }
                    //Не рассроченный договор(устареыший и не используется по письму ГКБ)
                    else
                    {
                        // not impl
                    }
                }
            }
            return _monthPays;
        }



        /// <summary>
        /// расчет текущих обязательств
        /// </summary>
        /// <returns></returns>
        public async Task<double> CallGetAnnualPay(Guid id)
        {
            var _outService = await _outServiceRepo.GetQueryable(x => x.Id == Guid.Parse("5f83d4ea-c8c8-485b-9256-08d8554ef7c7")).FirstOrDefaultAsync();
            if (_outService == default && _outService.ResponseContent == default)
                throw new ArgumentException("GKB Xml документ не найден");
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(_outService.ResponseContent);
            var _ = GetAnnualPay(xmlDocument);
            return _;
        }

        /// <summary>
        /// расчет текущих обязательств
        /// </summary>
        /// <returns></returns>
        public double CallGetAnnualPay(XmlDocument xml)
        {
            return GetAnnualPay(xml);
        }

        /// <summary>
        /// расчет текущих обязательств
        /// </summary>
        /// <returns></returns>
        private double GetAnnualPay(XmlDocument xml)
        {
            double _payCurrent = 0;
            XmlNodeList _details;
            if (xml.SelectNodes("//creditReportContent/detailsDto") != default)
            {
                _details = xml.SelectNodes("//creditReportContent/detailsDto");
            }
            else
            {
                return _payCurrent;
            }
            foreach (XmlNode _detailNode in _details)
            {
                var _contracts = new XmlDocument();
                _contracts.LoadXml(_detailNode.OuterXml);
                //только действующие договора
                if (_contracts.SelectSingleNode("//creditPhaseCode").InnerText != "4")
                    continue; 


            } 
            return _payCurrent;
        }


        /// <summary>
        /// Получение цифры из строки
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        private int GetNumberByString(string param)
        {
            int.TryParse(string.Join("", param.Where(c => char.IsDigit(c))), out int value);
            return value;
        }

        /// <summary>
        /// Получение периодичности коду
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        private int GetPeriodicityOfPayments(string x)
        {
            return x switch
            {
                "1" => 15,
                "2" => 30,
                "3" => 60,
                "4" => 90,
                "5" => 120,
                "6" => 150,
                "7" => 180,
                "8" => 360,
                "9" => 360,
                "10" => 360,
                "11" => 7,
                _ => 360,
            };
        }
    }
}
