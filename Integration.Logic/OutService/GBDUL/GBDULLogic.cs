using Agro.Shared.Logic.Primitives;
using Agro.Shared.Data;
using Agro.Shared.Data.Repos.OutService;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Agro.Integration.Logic.OutService.GBDUL
{
    public class GBDULLogic : IGBDULLogic
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<AppSettings> _conf;
        private readonly IOutServiceRepo _repo;
        public GBDULLogic(IHttpClientFactory httpClientFactory, IOptions<AppSettings> conf, IOutServiceRepo repo)
        {
            _httpClientFactory = httpClientFactory;
            _conf = conf;
            _repo = repo;
        }

        /// <summary>
        /// Получение данных из ГБД ЮЛ
        /// </summary>
        /// <param name="bin">бин</param>
        /// <returns></returns>
        public async Task<Guid> GetGBDUL(string bin)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml($"<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                    $"<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:data=\"http://data.gbd.chdb.scb.kz/\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">" +
                    $"<soapenv:Header><userId>{_conf.Value.Integrations.GBDUL.UserId}</userId></soapenv:Header>" +
                    $"<soapenv:Body><data:getLegalPerson><bin>{bin}</bin><consentConfirmed>true</consentConfirmed>" +
                    $"</data:getLegalPerson></soapenv:Body></soapenv:Envelope>");

                var httpContent = new StringContent(doc.InnerXml.ToString(), Encoding.UTF8);
                var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.GBDUL));
                var _ = await _httpClient.PostAsync(_conf.Value.Integrations.GBDUL.Url, httpContent);
                var _content = await _.Content.ReadAsStringAsync();
                if (_.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return await _repo.Add(new Shared.Data.Context.OutService
                    {
                        IIN = bin,
                        ResponseContent = _content,
                        Type = Shared.Data.Primitives.OutServiceEnum.GBDUL
                    });
                }
                else
                {
                    return await _repo.Add(new Shared.Data.Context.OutService
                    {
                        IIN = bin,
                        Type = Shared.Data.Primitives.OutServiceEnum.GBDUL,
                        Error = true,
                        ErrorContent = _content,
                    });
                }
            }
            catch (Exception e)
            {
                await _repo.Add(new Shared.Data.Context.OutService
                {
                    IIN = bin,
                    Type = Shared.Data.Primitives.OutServiceEnum.GBDUL,
                    Error = true,
                    ErrorContent = e.Message
                });
                throw new ArgumentException($"Сервис ГБДЮЛ не ответил (БИН - {bin}): " + e.Message);
            }
        }
    }
}
