using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;
using static Agro.Shared.Data.Context.PolicyRules;

namespace Agro.Scoring.Logic.Scoring
{
    public interface IOverdueCheckLogic
    {
        Task<PolicyRules.PolicyResult> CallExistenceDPDPastInToYears(Guid outServiceId);
        Task<PolicyRules.PolicyResult> CallExistenceDPDPastInToYears(XmlDocument MainXml);
        Task<PolicyRules.PolicyResult> CallExistenceOfAmountDPD(Guid outServiceId);
        PolicyRules.PolicyResult CallExistenceOfAmountDPD(XmlDocument MainXml);
        double CallGetAnnualPay(Guid outServiceId);
        double CallGetAnnualPay(XmlDocument MainXml);

        List<MonthlyPay> CallMonthlyPayByFinInstitut(Guid outServiceId);
        List<MonthlyPay> CallMonthlyPayByFinInstitut(XmlDocument MainXml);
    }
}