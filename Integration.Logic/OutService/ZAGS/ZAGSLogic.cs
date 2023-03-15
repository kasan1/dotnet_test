using Agro.Integration.Logic.OutService.ZAGS.Parse;
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

namespace Agro.Integration.Logic.OutService.ZAGS
{
    public class ZAGSLogic : IZAGSLogic
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<AppSettings> _conf;
        private readonly IOutServiceRepo _repo;
        public ZAGSLogic(IHttpClientFactory httpClientFactory, IOptions<AppSettings> conf, IOutServiceRepo repo)
        {
            _httpClientFactory = httpClientFactory;
            _conf = conf;
            _repo = repo;
        }

        /// <summary>
        /// Получение данных из ЗАГС
        /// </summary>
        /// <param name="iin">иин</param>
        /// <returns></returns>
        public async Task<Guid?> GetZAGS(string iin)
        {
            try
            {
                var _ = await CallService(iin);
                if (_.Item1.StatusCode == HttpStatusCode.OK)
                {
                    return await _repo.Add(new Shared.Data.Context.OutService
                    {
                        IIN = iin,
                        ResponseContent = _.Item2,
                        Type = Shared.Data.Primitives.OutServiceEnum.ZAGS
                    });
                }
                else
                {
                    await _repo.Add(new Shared.Data.Context.OutService
                    {
                        IIN = iin,
                        Type = Shared.Data.Primitives.OutServiceEnum.ZAGS,
                        Error = true,
                        ErrorContent = _.Item2,
                    });
                    return null;
                }
            }
            catch (Exception e)
            {
                await _repo.Add(new Shared.Data.Context.OutService
                {
                    IIN = iin,
                    Type = Shared.Data.Primitives.OutServiceEnum.ZAGS,
                    Error = true,
                    ErrorContent = e.Message
                });
                return null;
            }
        }


        public async Task<ZagsPersonInfo> GetZAGSByIin(string iin)
        {
            var _ = await CallService(iin);
            if (_.Item1.StatusCode == HttpStatusCode.OK)
            {
                await _repo.Add(new Shared.Data.Context.OutService
                {
                    IIN = iin,
                    ResponseContent = _.Item2,
                    Type = Shared.Data.Primitives.OutServiceEnum.ZAGS
                });
            }
            else
            {
                await _repo.Add(new Shared.Data.Context.OutService
                {
                    IIN = iin,
                    Type = Shared.Data.Primitives.OutServiceEnum.ZAGS,
                    Error = true,
                    ErrorContent = _.Item2,
                });
            }
            return Parse(_.Item2);
        }

        private async Task<(HttpResponseMessage, string)> CallService(string iin)
        {
            var doc = new XmlDocument();
            doc.LoadXml($"<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                $"<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:data=\"http://data.gbd.chdb.scb.kz/\">" +
                $"<soapenv:Header><userId>{_conf.Value.Integrations.ZAGS.UserId}</userId></soapenv:Header>" +
                $"<soapenv:Body><data:getFamilyInfo><iin>{iin}</iin><consentConfirmed>true</consentConfirmed>" +
                $"</data:getFamilyInfo></soapenv:Body></soapenv:Envelope>");

            var httpContent = new StringContent(doc.InnerXml.ToString(), Encoding.UTF8);
            var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.ZAGS));
            var _ = await _httpClient.PostAsync(_conf.Value.Integrations.ZAGS.Url, httpContent);
            var _content = await _.Content.ReadAsStringAsync();
            return (_,_content);
        }

        private ZagsPersonInfo Parse(string response)
        {
            var _ = new ZagsPersonInfo();
            var _responseXml = new XmlDocument();
            _responseXml.LoadXml(response);
            if(_responseXml.SelectSingleNode("//responseData/data/messageResult/code").InnerText == "00001")
            {
                return _;
            }
            int childCount = 0;
            foreach (XmlNode item in _responseXml.SelectNodes("//responseData/data/familyInfoList"))
            {
                var _item = new XmlDocument();
                _item.LoadXml(item.OuterXml);
                if(_item.SelectSingleNode("//birthInfos/childBirthDate")?.InnerText != default 
                    && _item.SelectSingleNode("//birthInfos/childBirthDate")?.InnerText != "")
                {
                    var _birth = Convert.ToDateTime(_item.SelectSingleNode("//birthInfos/childBirthDate")?.InnerText);
                    if (GetAge(_birth) < 18)
                        childCount++;
                }
            }

            _.FamilyCount = (int)_responseXml.SelectNodes("//responseData/data/familyInfoList")?.Count;
            _.IsMarriage = _responseXml.SelectNodes("//responseData/data/familyInfoList/marriageInfos")?.Count >= 1;
            _.IsDivorce = _responseXml.SelectNodes("//responseData/data/familyInfoList/divorceInfos")?.Count >= 1;
            _.ChildrenUnder18YearsOld = childCount;
            return _;
        }

        private int GetAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;

            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;
            var _ = (a - b) / 10000;
            return _;
        }

    }
}
