using Agro.Shared.Logic.Primitives;
using Agro.Shared.Data;
using Agro.Shared.Data.Repos.OutService;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Threading;
using Agro.Shared.Logic.Common.Exceptions;

namespace Agro.Shared.Logic.GKB
{
    public class GKBLogic : IGKBLogic
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<AppSettings> _conf;
        private readonly IOutServiceRepo _repo;

        public GKBLogic(IHttpClientFactory httpClientFactory,
            IOptions<AppSettings> conf,
            IOutServiceRepo repo)
        {
            _httpClientFactory = httpClientFactory;
            _conf = conf;
            _repo = repo;
        }

        /// <summary>
        /// Получение типов кредитных отчетов доступных у пользователя
        /// </summary>
        /// <param name="iin"></param>
        /// <returns></returns>
        public async Task<IDictionary<ReportTypes, string>> GetCreditReportTypes(string iin)
        {
            IDictionary<ReportTypes, string> result = new Dictionary<ReportTypes, string>();
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml($"<?xml version=\"1.0\" encoding=\"utf-8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:rep=\"http://report.chdb.scb.kz\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                    $"<soapenv:Header><userId>{_conf.Value.Integrations.GKB.UserId}</userId></soapenv:Header>" +
                    $"<soapenv:Body><rep:getCreditReportTypes><reportParams xsi:type=\"rep:personCreditReportParams\">" +
                    $"<iin>{iin}</iin><consentConfirmed>true</consentConfirmed></reportParams>" +
                    $"</rep:getCreditReportTypes></soapenv:Body></soapenv:Envelope>");

                var httpContent = new StringContent(doc.InnerXml.ToString(), Encoding.UTF8);
                var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.GKB));
                var _ = await _httpClient.PostAsync(_conf.Value.Integrations.GKB.Url, httpContent);
                var _content = await _.Content.ReadAsStringAsync();

                int firstIndex = _content.IndexOf("<soap:Envelope"),
                    lastIndex = _content.LastIndexOf("</soap:Envelope>");

                var xml = _content.Substring(firstIndex, lastIndex - firstIndex + "</soap:Envelope>".Length);

                doc.LoadXml(xml);
                var elements = doc.GetElementsByTagName("availableReportTypes");
                for (var i = 0; i < elements.Count; i++)
                {
                    var reportType = ReportType.KeyValuePair(elements[i].InnerText);
                    if (result.ContainsKey(reportType.Key)) continue;

                    result.Add(reportType);
                }
                return result;
            }
            catch (Exception e)
            {
                throw new ArgumentException($"Сервис ГКБ получение типов отчетов не ответил (ИИН - {iin}): " + e.Message);
            }
        }

        /// <summary>
        /// Получение данных из ГКБ
        /// </summary>
        /// <param name="iin">иин</param>
        /// <param name="reportName">наименование запрашиваемого отчета</param>
        /// <returns></returns>
        [Obsolete("Не использовать устаревший сервиса")]
        public async Task<Guid?> GetGKBX(string iin, string reportName)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml($"<?xml version=\"1.0\" encoding=\"utf-8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:rep=\"http://report.chdb.scb.kz\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                    $"<soapenv:Header><userId>{_conf.Value.Integrations.GKB.UserId}</userId></soapenv:Header>" +
                    $"<soapenv:Body><rep:requestXmlCreditReportX><reportRequest><generationParams><language>ru</language>" +
                    $"<outputFormats>XML</outputFormats><reportType>{reportName}</reportType></generationParams>" +
                    $"<reportParams xsi:type=\"rep:personCreditReportParams\"><new>true</new><iin>{iin}</iin>" +
                    $"<consentConfirmed>true</consentConfirmed></reportParams></reportRequest>" +
                    $"</rep:requestXmlCreditReportX></soapenv:Body></soapenv:Envelope>");

                var httpContent = new StringContent(doc.InnerXml.ToString(), Encoding.UTF8);
                var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.GKB));
                var _ = await _httpClient.PostAsync(_conf.Value.Integrations.GKB.Url, httpContent);
                var _content = await _.Content.ReadAsStringAsync();
                int firstIndex = _content.IndexOf("<soap:Envelope"),
                    lastIndex = _content.LastIndexOf("</soap:Envelope>");
                var xml = _content.Substring(firstIndex, lastIndex - firstIndex + "</soap:Envelope>".Length);

                if (_.StatusCode == HttpStatusCode.OK)
                {
                    return await _repo.Add(new Data.Context.OutService
                    {
                        IIN = iin,
                        ResponseContent = xml,
                        Type = Data.Primitives.OutServiceEnum.GKB
                    });
                }
                else
                {
                    await _repo.Add(new Data.Context.OutService
                    {
                        IIN = iin,
                        Type = Data.Primitives.OutServiceEnum.GKB,
                        Error = true,
                        ErrorContent = xml,
                    });
                    return null;
                }
            }
            catch (Exception e)
            {
                await _repo.Add(new Shared.Data.Context.OutService
                {
                    IIN = iin,
                    Type = Shared.Data.Primitives.OutServiceEnum.GKB,
                    Error = true,
                    ErrorContent = e.Message
                });
                throw new ArgumentException($"Сервис ГКБ не ответил (ИИН - {iin}): " + e.Message);
            }
        }

        public async Task<byte[]> GetGKBFile(string identifier, bool isFL = true, CancellationToken cancellation = default)
        {
            var reportType = "extendedReport";
            var subjectType = "personCreditReportParams";
            var identificationTag = "iin";
            if (!isFL)
            {
                subjectType = "organizationCreditReportParams";
                identificationTag = "bin";
            }
            var doc = new XmlDocument();
            doc.LoadXml($@"<?xml version='1.0' encoding='UTF-8'?>
<soapenv:Envelope xmlns:rep='http://report.chdb.scb.kz' xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance'>
    <soapenv:Header>
        <userId>{_conf.Value.Integrations.GKB.UserId}</userId>
    </soapenv:Header>
    <soapenv:Body>
        <rep:requestCreditReport>
            <reportRequest>
                <generationParams>
                    <language>ru</language>
                    <outputFormats>PDF</outputFormats>
                    <reportType>{reportType}</reportType>
                </generationParams>
                <reportParams xsi:type='rep:{subjectType}'>
                    <{identificationTag}>{identifier}</{identificationTag}>
                    <consentConfirmed>true</consentConfirmed>
                </reportParams>
            </reportRequest>
        </rep:requestCreditReport>
    </soapenv:Body>
</soapenv:Envelope>");
            var httpContent = new StringContent(doc.InnerXml.ToString(), Encoding.UTF8);
            var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.GKB));
            var _ = await _httpClient.PostAsync(_conf.Value.Integrations.GKB.Url, httpContent, cancellation);
            var _content = await _.Content.ReadAsByteArrayAsync();
            var _string = Encoding.Default.GetString(_content);
            if (!_.IsSuccessStatusCode)
                throw new RestException(HttpStatusCode.InternalServerError, $"GKB service error: {_string}");

            int firstIndex = _string.IndexOf("%PDF-1.5");
            var _byte = _content.Skip(firstIndex).ToArray();
            return _byte;
        }

        public async Task<Guid> GetGKBNew(string iin, string reportName, bool isFL = true)
        {
            try
            {
                var subjectType = "personCreditReportParams";
                var identificationTag = "iin";
                if (!isFL)
                {
                    subjectType = "organizationCreditReportParams";
                    identificationTag = "bin";
                }

                var doc = new XmlDocument();
                doc.LoadXml($"<?xml version=\"1.0\" encoding=\"UTF-8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:rep=\"http://report.chdb.scb.kz\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                    $"<soapenv:Header><userId>{_conf.Value.Integrations.GKB.UserId}</userId></soapenv:Header>" +
                    $"<soapenv:Body><rep:requestXmlCreditReport><reportRequest><generationParams><language>ru</language><outputFormats>XML</outputFormats>" +
                    $"<reportType>{reportName}</reportType></generationParams><reportParams xsi:type=\"rep:{subjectType}\"><{identificationTag}>{iin}</{identificationTag}><new>true</new>" +
                    $"<consentConfirmed>true</consentConfirmed></reportParams></reportRequest></rep:requestXmlCreditReport></soapenv:Body></soapenv:Envelope>");

                var httpContent = new StringContent(doc.InnerXml.ToString(), Encoding.UTF8);
                var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.GKB));
                var _ = await _httpClient.PostAsync(_conf.Value.Integrations.GKB.Url, httpContent);
                var _response = await _.Content.ReadAsStringAsync();
                var _content = _response;
                int firstIndex = _content.IndexOf("<soap:Envelope"),
                    lastIndex = _content.LastIndexOf("</soap:Envelope>");
                var xml = _content.Substring(firstIndex, lastIndex - firstIndex + "</soap:Envelope>".Length);

                if (_.StatusCode == HttpStatusCode.OK)
                {
                    return await _repo.Add(new Data.Context.OutService
                    {
                        IIN = iin,
                        ResponseContent = xml,
                        Type = Data.Primitives.OutServiceEnum.GKBNew
                    });
                }
                else
                {
                    return await _repo.Add(new Data.Context.OutService
                    {
                        IIN = iin,
                        Type = Data.Primitives.OutServiceEnum.GKBNew,
                        Error = true,
                        ErrorContent = xml,
                    });
                }
            }
            catch (Exception e)
            {
                await _repo.Add(new Data.Context.OutService
                {
                    IIN = iin,
                    Type = Data.Primitives.OutServiceEnum.GKBNew,
                    Error = true,
                    ErrorContent = e.Message
                });
                throw new ArgumentException($"Сервис ГКБ не ответил (ИИН - {iin}): " + e.Message);
            }
        }

    }
}
