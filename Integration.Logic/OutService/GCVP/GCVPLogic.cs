using Agro.Shared.Logic.Primitives;
using Agro.Shared.Data;
using Agro.Shared.Data.Repos.OutService;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Agro.Integration.Logic.OutService.GCVP
{
    public class GCVPLogic : IGCVPLogic
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<AppSettings> _conf;
        private readonly IOutServiceRepo _repo;
        public GCVPLogic(IHttpClientFactory httpClientFactory, IOptions<AppSettings> conf, IOutServiceRepo repo)
        {
            _httpClientFactory = httpClientFactory;
            _conf = conf;
            _repo = repo;
        }


        /// <summary>
        /// Получение данных из ГЦВП
        /// </summary>
        /// <param name="iin">иин</param>
        /// <returns></returns>
        public async Task<Guid?> GetGCVP(string iin)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml($"<?xml version=\"1.0\" encoding=\"utf-8\"?><soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:data=\"http://data.gbd.chdb.scb.kz/\">" +
                    $"<soapenv:Header><userId>{_conf.Value.Integrations.GCVP.UserId}</userId></soapenv:Header>" +
                    $"<soapenv:Body><data:getPensionInfo><iin>{iin}</iin><requestType>DEDUCTION_6</requestType><requestNumber>{Guid.NewGuid()}</requestNumber>" +
                    $"</data:getPensionInfo></soapenv:Body></soapenv:Envelope>");

                var httpContent = new StringContent(doc.InnerXml.ToString(), Encoding.UTF8);
                var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.GCVP));
                var _ = await _httpClient.PostAsync(_conf.Value.Integrations.GCVP.Url, httpContent);
                var _content = await _.Content.ReadAsStringAsync();
                if (_.StatusCode == HttpStatusCode.OK)
                {
                    return await _repo.Add(new Shared.Data.Context.OutService
                    {
                        IIN = iin,
                        ResponseContent = _content,
                        Type = Shared.Data.Primitives.OutServiceEnum.GCVP
                    });
                }
                else
                {
                    await _repo.Add(new Shared.Data.Context.OutService
                    {
                        IIN = iin,
                        Type = Shared.Data.Primitives.OutServiceEnum.GCVP,
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
                    Type = Shared.Data.Primitives.OutServiceEnum.GCVP,
                    Error = true,
                    ErrorContent = e.Message
                });
                return null;
            }
        }
    }
}
