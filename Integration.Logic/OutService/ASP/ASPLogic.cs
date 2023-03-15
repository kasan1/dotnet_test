using Agro.Shared.Logic.Primitives;
using Agro.Shared.Data;
using Agro.Shared.Data.Repos.OutService;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Agro.Integration.Logic.OutService.ASP
{
    public class ASPLogic : IASPLogic
    {
        private readonly IOptions<AppSettings> _conf;
        private readonly IOutServiceRepo _repo;
        private readonly IHttpClientFactory _httpClientFactory;
        public ASPLogic(IOptions<AppSettings> conf, IOutServiceRepo repo, IHttpClientFactory httpClientFactory)
        {
            _conf = conf;
            _repo = repo;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Получение данных АСП
        /// </summary>
        /// <param name="iin">иин</param>
        /// <returns></returns>
        public async Task<bool?> GetASP(string iin)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml($"<?xml version=\"1.0\" encoding=\"utf-8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:data=\"http://data.mtszn.scb.kz/\">" +
                    $"<soapenv:Header><userId>{_conf.Value.Integrations.ASP.UserId}</userId></soapenv:Header>" +
                    $"<soapenv:Body><data:getAddressSocialAssistance><iin>{iin}</iin><requestNumber>{Guid.NewGuid()}</requestNumber>" +
                    $"</data:getAddressSocialAssistance></soapenv:Body></soapenv:Envelope>");

                var httpContent = new StringContent(doc.InnerXml.ToString(), Encoding.UTF8);
                var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.ASP));
                var _ = await _httpClient.PostAsync(_conf.Value.Integrations.ASP.Url, httpContent);
                var _content = await _.Content.ReadAsStringAsync();
                if (_.StatusCode == HttpStatusCode.OK)
                {
                    await _repo.Add(new Shared.Data.Context.OutService
                    {
                        IIN = iin,
                        ResponseContent = _content,
                        Type = Shared.Data.Primitives.OutServiceEnum.ASP
                    });
                    return IsASA(_content);
                }
                else
                {
                    await _repo.Add(new Shared.Data.Context.OutService
                    {
                        IIN = iin,
                        Type = Shared.Data.Primitives.OutServiceEnum.ASP,
                        Error = true,
                        ErrorContent = _content,
                    });
                    return null;
                }
            }
            catch (Exception e)
            {
                await _repo.Add(new Shared.Data.Context.OutService
                {
                    IIN = iin,
                    Type = Shared.Data.Primitives.OutServiceEnum.ASP,
                    Error = true,
                    ErrorContent = e.Message
                });
                return null;
            }
        }


        private bool IsASA(string response)
        {
            var responseXml = new XmlDocument();
            responseXml.LoadXml(response);
            if (responseXml.SelectSingleNode("//faultcode") != null || responseXml.SelectSingleNode("//faultstring") != null)
            {
                if (responseXml.SelectSingleNode("//faultstring") != null)
                {
                    Log.Error("Ошибка при получении данных АСП: " + responseXml.SelectSingleNode("//faultstring").InnerText);
                }
                return false;
            }
            var data = responseXml.SelectSingleNode("//data").InnerText;
            responseXml.LoadXml(XmlConvert.DecodeName(data));
            if (responseXml.SelectSingleNode("//state") != null)
            {
                return responseXml.SelectSingleNode("//state").InnerText == "ok";
            }
            return false;
        }
    }
}
