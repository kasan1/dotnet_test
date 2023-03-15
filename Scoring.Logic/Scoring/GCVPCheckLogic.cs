using Agro.Shared.Data.Repos.OutService;
using Serilog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using static Agro.Shared.Data.Context.PolicyRules;

namespace Agro.Scoring.Logic.Scoring
{
    public class GCVPCheckLogic : IGCVPCheckLogic
    {
        private readonly IOutServiceRepo _outServiceRepo;
        public GCVPCheckLogic(IOutServiceRepo outServiceRepo)
        {
            _outServiceRepo = outServiceRepo;
        }


        public GCVP CallCheckPublicSources(Guid outServiceId)
        {
            string responseContent = _outServiceRepo.GetById(outServiceId).Result.ResponseContent;
            var xml = new XmlDocument();
            xml.LoadXml(responseContent);
            return CheckPublicSources(xml);
        }


        public GCVP CheckPublicSources(XmlDocument xml)
        {
            var gcvp = new GCVP();
            try
            {
                if (xml != null)
                {
                    if (xml.SelectSingleNode("//return/response/responseData/data/responseCode") != null && !string.IsNullOrEmpty(xml.SelectSingleNode("//return/response/responseData/data/responseCode").InnerText))
                    {
                        gcvp.Answer = xml.SelectSingleNode("//return/response/responseData/data/responseCode").InnerText;
                    }
                    if (gcvp.Answer == "FOUND")
                    {
                        gcvp.Status = GCVP.GCVPStatus.Found;
                        gcvp.DeductionList = new List<Deductions>();
                        foreach (XmlNode node in xml.SelectNodes("//return/response/responseData/data/deductionsDetailed"))
                        {
                            Deductions deduction = new Deductions();
                            if (node.SelectSingleNode("bin") != null && !string.IsNullOrEmpty(node.SelectSingleNode("bin").InnerText))
                            {
                                deduction.Iin = node.SelectSingleNode("bin").InnerText;
                            }
                            if (node.SelectSingleNode("date") != null && !string.IsNullOrEmpty(node.SelectSingleNode("date").InnerText))
                            {
                                var dateOut = DateTime.MinValue;
                                var canBeParsed = DateTime.TryParse(node.SelectSingleNode("date").InnerText, out dateOut);
                                if (canBeParsed)
                                {
                                    deduction.PaymentDate = dateOut;
                                }
                            }
                            if (node.SelectSingleNode("name") != null && !string.IsNullOrEmpty(node.SelectSingleNode("name").InnerText))
                            {
                                deduction.OrganizationName = node.SelectSingleNode("name").InnerText;
                            }
                            if (node.SelectSingleNode("amount") != null && !string.IsNullOrEmpty(node.SelectSingleNode("amount").InnerText))
                            {
                                deduction.Amount = Decimal.Parse(node.SelectSingleNode("amount").InnerText, CultureInfo.InvariantCulture);
                            }
                            gcvp.DeductionList.Add(deduction);
                        }
                    }
                    else
                    {
                        gcvp.Status = GCVP.GCVPStatus.NotFound;
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error("Ошибка при десериализации xml ГЦВП");
                gcvp.Status = GCVP.GCVPStatus.Error;
            }
            return gcvp;
        }
    }

    public class GCVP
    {
        public string Answer { get; set; }
        public List<Deductions> DeductionList { get; set; }
        public GCVPStatus Status { get; set; }
        public enum GCVPStatus
        {
            Error,
            NotFound,
            Found
        }
    }

    public class Deductions
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string OrganizationName { get; set; }
        public string Iin { get; set; }
    }
}
