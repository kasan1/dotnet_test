using Agro.Shared.Logic.Primitives;
using Agro.Shared.Data;
using Agro.Shared.Data.Repos.OutService;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Serilog;
using System.IO;
using Agro.Shared.Data.Primitives;
using System.Threading;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.Services.System.File;

namespace Agro.Shared.Logic.OutService.PKB
{
    public class PKBLogic : IPKBLogic
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<AppSettings> _conf;
        private readonly IOutServiceRepo _repo;
        private readonly IFileService _fileService;

        public PKBLogic(IHttpClientFactory httpClientFactory, 
            IOptions<AppSettings> conf, 
            IOutServiceRepo repo,
            Delegates.FileServiceResolver fileServiceResolver)
        {
            _httpClientFactory = httpClientFactory;
            _conf = conf;
            _repo = repo;
            _fileService = fileServiceResolver(FileServiceTypeEnum.Database);
        }

        /// <summary>
        /// Получение данных с ПКБ
        /// </summary>
        /// <param name="iin">ИИН</param>
        /// <returns>true - хорошо, false - ошибка</returns>
        public async Task<Guid?> GetPKBXml(string iin, CancellationToken cancellationToken = default)
        {
            try
            {
                var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.PKB));
                var content = await _httpClient.GetStringAsync($"{_conf.Value.Integrations.PKB.Url}/{iin}.xml");
                return await _repo.Add(new Data.Context.OutService
                {
                    IIN = iin,
                    ResponseContent = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + content,
                    Type = OutServiceEnum.PKB
                });
            }
            catch (TaskCanceledException e)
            {
                await CatchLogWrite(iin, e.Message);
                return null;
            }
            catch (HttpRequestException e)
            {
                await CatchLogWrite(iin, e.Message);
                return null;
            }
            catch (Exception e)
            {
                await CatchLogWrite(iin, e.Message);
                return null;
            }
        }

        /// <summary>
        /// Получение данных с ПКБ
        /// </summary>
        /// <param name="iin">ИИН</param>
        /// <returns>true - хорошо, false - ошибка</returns>
        public async Task<Stream> GetPKBFile(string iin, CancellationToken cancellationToken = default)
        {
            try
            {
                var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.PKB));
                var response = await _httpClient.GetAsync($"{_conf.Value.Integrations.PKB.Url}/{iin}.pdf", cancellationToken);

                var stream = new MemoryStream();
                await response.Content.CopyToAsync(stream);

                return stream;
            }
            catch (Exception e)
            {
                await CatchLogWrite(iin, e.Message);
                return null;
            }
        }

        /// <summary>
        /// Получение данных о ИП
        /// </summary>
        /// <returns></returns>
        public async Task<PkbIpInfo> GetIpInfoByPKB(string iin)
        {
            try
            {
                var _httpClient = _httpClientFactory.CreateClient(Enum.GetName(typeof(IntegrationType), IntegrationType.PKB));
                var _ = await _httpClient.GetStringAsync(_conf.Value.Integrations.PKB.Url.Replace("ChangeIIN", iin));
                await _repo.Add(new Shared.Data.Context.OutService
                {
                    IIN = iin,
                    ResponseContent = _,
                    Type = Shared.Data.Primitives.OutServiceEnum.PKB
                });
                return ParseIpInfo(_);
            }
            catch (TaskCanceledException e)
            {
                await CatchLogWrite(iin, e.Message);
                return null;
            }
            catch (HttpRequestException e)
            {
                await CatchLogWrite(iin, e.Message);
                return null;
            }
            catch (Exception e)
            {
                await CatchLogWrite(iin, e.Message);
                return null;
            }
        }


        private PkbIpInfo ParseIpInfo(string xml)
        {
            var _pkbIpInfo = new PkbIpInfo();
            var _responseXml = new XmlDocument();
            _responseXml.LoadXml(xml);
            if (_responseXml.SelectNodes("//Root/StatDoc") != default)
            {
                if (_responseXml.SelectSingleNode("//Root/StatDoc/Status/@id")?.InnerText == "1")
                {
                    if (_responseXml.SelectSingleNode("//StatDoc/Companies/Company/BIN")?.InnerText != default
                        && _responseXml.SelectSingleNode("//StatDoc/Companies/Company/BIN/@value")?.InnerText != null)
                        _pkbIpInfo.Bin = _responseXml.SelectSingleNode("//StatDoc/Companies/Company/BIN/@value")?.InnerText;

                    if (_responseXml.SelectSingleNode("//StatDoc/Companies/Company/Name")?.InnerText != default
                        && _responseXml.SelectSingleNode("//StatDoc/Companies/Company/Name/@value")?.InnerText != null)
                        _pkbIpInfo.Name = _responseXml.SelectSingleNode("//StatDoc/Companies/Company/Name/@value")?.InnerText;

                    if (_responseXml.SelectSingleNode("//StatDoc/Companies/Company/RegistrationDate")?.InnerText != default
                        && _responseXml.SelectSingleNode("//StatDoc/Companies/Company/RegistrationDate/@value")?.InnerText != null)
                        _pkbIpInfo.RegistrationDate = Convert.ToDateTime(_responseXml.SelectSingleNode("//StatDoc/Companies/Company/RegistrationDate/@value")?.InnerText);

                    if (_responseXml.SelectSingleNode("//StatDoc/Companies/Company/OkedCode")?.InnerText != default
                        && _responseXml.SelectSingleNode("//StatDoc/Companies/Company/OkedCode/@value")?.InnerText != null)
                        _pkbIpInfo.OkedCode = _responseXml.SelectSingleNode("//StatDoc/Companies/Company/OkedCode/@value")?.InnerText;

                    if (_responseXml.SelectSingleNode("//StatDoc/Companies/Company/KatoCode")?.InnerText != default
                        && _responseXml.SelectSingleNode("//StatDoc/Companies/Company/KatoCode/@value")?.InnerText != null)
                        _pkbIpInfo.KatoCode = _responseXml.SelectSingleNode("//StatDoc/Companies/Company/KatoCode/@value")?.InnerText;

                    if (_responseXml.SelectSingleNode("//StatDoc/Companies/Company/KatoAddress")?.InnerText != default
                        && _responseXml.SelectSingleNode("//StatDoc/Companies/Company/KatoAddress/@value")?.InnerText != null)
                        _pkbIpInfo.KatoAddress = _responseXml.SelectSingleNode("//StatDoc/Companies/Company/KatoAddress/@value")?.InnerText;
                }
            }
            return _pkbIpInfo;
        }

        private async Task CatchLogWrite(string iin, string messagse)
        {
            Log.Error("Ошибка получения данных ПКБ: " + messagse);
            await _repo.Add(new Data.Context.OutService
            {
                IIN = iin,
                Type = OutServiceEnum.PKB,
                Error = true,
                ErrorContent = messagse
            });
        }

        private string GetFileUploadPath(string fileName)
        {
            string folderName = "Uploads";
            string webRootPath = Environment.CurrentDirectory;
            string newPath = Path.Combine(webRootPath, folderName, "PKB");
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }

            return Path.Combine(newPath, fileName);
        }

    }
}
