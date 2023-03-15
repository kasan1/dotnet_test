using Agro.Identity.Logic;
using Agro.Integration.Logic.OutService.GBDFL.Parse;
using Agro.Shared.Logic.Primitives;
using Agro.Okaps.Logic;
using Agro.Okaps.Logic.Models;
using Agro.Shared.Data;
using Agro.Shared.Data.Repos.Branch;
using Agro.Shared.Data.Repos.LoanApplication;
using Agro.Shared.Data.Repos.OutService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Agro.Shared.Data.Enums.Identity;

namespace Agro.Integration.Logic.OutService.GBDFL
{
    public class GBDFLLogic : IGBDFLLogic
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<AppSettings> _conf;
        private readonly IOutServiceRepo _repo;
        private readonly ILoanApplicationRepo _loanApplicationRepo;
        private readonly IClientProfileLogic _clientProfileLogic;
        private readonly IAccountLogic _accountLogic;
        private readonly IBranchRepo _branchRepo;

        public GBDFLLogic(
            IHttpClientFactory httpClientFactory, 
            IOptions<AppSettings> conf, 
            IOutServiceRepo repo,
            ILoanApplicationRepo loanApplicationRepo,
            IClientProfileLogic clientProfileLogic,
            IAccountLogic accountLogic,
            IBranchRepo branchRepo
            )
        {
            _httpClientFactory = httpClientFactory;
            _conf = conf;
            _repo = repo;
            _loanApplicationRepo = loanApplicationRepo;
            _clientProfileLogic = clientProfileLogic;
            _accountLogic = accountLogic;
            _branchRepo = branchRepo;
        }

        /// <summary>
        /// Получение данных из ГБД ФЛ
        /// </summary>
        /// <param name="iin">иин</param>
        /// <returns></returns>
        public async Task<Guid> GetGBDFL(string iin)
        {
            try
            {
                var doc = GetRequestXml(iin);
                var httpContent = new StringContent(doc.InnerXml.ToString(), Encoding.UTF8);
                var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.GBDFL));
                var _ = await _httpClient.PostAsync(_conf.Value.Integrations.GBDFL.Url, httpContent);
                var _content = await _.Content.ReadAsStringAsync();
                if (_.StatusCode == HttpStatusCode.OK)
                {
                    return await _repo.Add(new Shared.Data.Context.OutService
                    {
                        IIN = iin,
                        ResponseContent = _content,
                        Type = Shared.Data.Primitives.OutServiceEnum.GBDFL
                    });
                }
                else
                {
                    return await _repo.Add(new Shared.Data.Context.OutService
                    {
                        IIN = iin,
                        Type = Shared.Data.Primitives.OutServiceEnum.GBDFL,
                        Error = true,
                        ErrorContent = _content,
                    });
                }
            }
            catch (Exception e)
            {
                await _repo.Add(new Shared.Data.Context.OutService
                {
                    IIN = iin,
                    Type = Shared.Data.Primitives.OutServiceEnum.GBDFL,
                    Error = true,
                    ErrorContent = e.Message
                });
                throw new ArgumentException($"Сервис ГБДФЛ не ответил (ИИН - {iin}): " + e.Message);
            }
        }


        public async Task<GBDFLPerson> GetGBDFLByIIN(string iin)
        {
            var doc = GetRequestXml(iin);
            var httpContent = new StringContent(doc.InnerXml.ToString(), Encoding.UTF8);
            var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.GBDFL));
            var _ = await _httpClient.PostAsync(_conf.Value.Integrations.GBDFL.Url, httpContent);
            var _content = await _.Content.ReadAsStringAsync();
            if (_.StatusCode == HttpStatusCode.OK)
            {
                await _repo.Add(new Shared.Data.Context.OutService
                {
                    IIN = iin,
                    ResponseContent = _content,
                    Type = Shared.Data.Primitives.OutServiceEnum.GBDFL
                });
            }
            else
            {
                await _repo.Add(new Shared.Data.Context.OutService
                {
                    IIN = iin,
                    Type = Shared.Data.Primitives.OutServiceEnum.GBDFL,
                    Error = true,
                    ErrorContent = _content,
                });
            }
            var _response = Parse(_content, out GBDFLPerson person, out string errorMessage);
            if (!_response)
                throw new ArgumentException("Ошибка при получении данных из ГБД ФЛ: " + errorMessage);
            return person;
        }

        public async Task<object> GetGBDByApplicationId(string ApplicationId)
        {
            var loan = await _loanApplicationRepo
                   .Base()
                   .Include(x => x.User)
                   .AsNoTracking()
                   .Select(x => new
                   {
                       x.Id,
                       x.UserId,
                       Iin = x.User.UserName,
                       IsPhysical = x.User.EssenceType == EssenceType.Individual
                   })
                   .SingleOrDefaultAsync(x => x.Id == Guid.Parse(ApplicationId) && x.IsPhysical);

            GBDFLPerson person = await GetGBDFLByIIN(loan.Iin);
            ClientProfileInDto clientModel = new ClientProfileInDto();
            clientModel.BirthPlaceKz = person.BirthPlace.GetAddressTxtKZ;
            clientModel.BirthPlaceRu = person.BirthPlace.GetAddressTxt;
            clientModel.RegistrationAddressDistrictCode = person.RegAddress.District.Code;
            clientModel.RegistrationAddressRegionCode = person.RegAddress.Region.Code;
            clientModel.RegistrationAddressRu = person.RegAddress.GetAddressTxt;
            clientModel.RegistrationAddressKz = person.RegAddress.GetAddressTxtKZ;
            clientModel.Gender = Enum.Parse<Shared.Data.Primitives.Gender>(person.Gender.Code);
            GBDFLIdDocument document = null;
            if (person.Documents.Where(m => m.Type.Code == "002" && m.Status.Code == "00").Count() > 0)
                document = person.Documents.Where(m => m.Type.Code == "002" && m.Status.Code == "00").FirstOrDefault(); // УДОСТОВЕРЕНИЕ РК и ДОКУМЕНТ ДЕЙСТВИТЕЛЕН
            else
                document = person.Documents.Where(m => m.Type.Code == "001" && m.Status.Code == "00").FirstOrDefault(); // ПАСПОРТ РК и ДОКУМЕНТ ДЕЙСТВИТЕЛЕН
            clientModel.DocumentTypeName = document.Type.Name;
            clientModel.DocumentOrganizationName = document.IssueOrganization.Name;
            clientModel.DocumentNumber = document.Number;
            clientModel.DocumentBeginDate = document.BeginDate;
            clientModel.DocumentEndDate = document.EndDate;
            clientModel.UserId = loan.UserId;

            if(await _clientProfileLogic.CheckExistsByUserId(loan.UserId))
            {
                await _clientProfileLogic.UpdateClientProfile(clientModel);
            } else
            {
                await _clientProfileLogic.AddClientProfile(clientModel);
            }

            
            var branchCode = _branchRepo
                .GetQueryable(x => x.CodeGBDFL == (clientModel.RegistrationAddressDistrictCode)) // г. Астана не привязан на обл
                .Select(x =>  x.AlterBranchId??x.Id)
                .FirstOrDefault();

            // Обновление BranchId у User
            await _accountLogic.UpdateBranchId(loan.UserId, branchCode);

            return new
            {
                result = "ok"
            };
        }


        private XmlDocument GetRequestXml(string iin)
        {
            var doc = new XmlDocument();
            doc.LoadXml($"<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                $"<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:data=\"http://data.gbd.chdb.scb.kz/\">" +
                $"<soapenv:Header><userId>{_conf.Value.Integrations.GBDFL.UserId}</userId></soapenv:Header>" +
                $"<soapenv:Body><data:getPerson><iin>{iin}</iin><consentConfirmed>true</consentConfirmed>" +
                $"</data:getPerson></soapenv:Body></soapenv:Envelope>");
            return doc;
        }



        /// <summary>
        /// Парсинг полученных данных
        /// </summary>
        /// <param name="person"></param>
        /// <param name="response"></param>
        /// <param name="messageId"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private bool Parse(string response, out GBDFLPerson person, out string errorMessage)
        {
            person = null;
            errorMessage = string.Empty;

            XmlDocument responseXml = new XmlDocument();
            responseXml.LoadXml(response);
            if (responseXml.SelectSingleNode("//faultcode") != null || responseXml.SelectSingleNode("//faultstring") != null)
            {
                if (responseXml.SelectSingleNode("//faultstring") != null)
                {
                    errorMessage = responseXml.SelectSingleNode("//faultstring").InnerText;
                }
                return false;
            }

            string statusCode = string.Empty;
            if (responseXml.SelectSingleNode("//responseInfo") != null)
            {
                if (responseXml.SelectSingleNode("//responseInfo/status/code") != null)
                {
                    if (!string.IsNullOrEmpty(responseXml.SelectSingleNode("//responseInfo/status/code").InnerText))
                    {
                        statusCode = responseXml.SelectSingleNode("//responseInfo/status/code").InnerText;
                    }
                }
            }

            if (statusCode != "SCSE001")
            {
                if (responseXml.SelectSingleNode("//responseData/data/persons") != null && responseXml.SelectSingleNode("//responseData/data/persons/person") != null)
                {
                    if (responseXml.SelectNodes("//responseData/data/persons/person").Count > 0)
                    {
                        person = new GBDFLPerson(responseXml);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
