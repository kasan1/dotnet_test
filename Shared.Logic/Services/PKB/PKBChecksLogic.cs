using System;
using System.Xml;
using static Agro.Shared.Data.Context.PolicyRules;
using Agro.Shared.Data.Repos.OutService;
using System.Threading.Tasks;
using Agro.Shared.Logic.OutService.PKB;

namespace Agro.Shared.Logic.Scoring
{
    public class PKBChecksLogic : IPKBChecksLogic
    {
        private readonly IOutServiceRepo _outServiceRepo;

        public PKBChecksLogic(IOutServiceRepo outServiceRepo)
        {
            _outServiceRepo = outServiceRepo;
        }

        public Task<PolicyResult> CallCheckPublicSources(Guid outServiceId)
        {
            string responseContent = _outServiceRepo.GetById(outServiceId).Result.ResponseContent;
            XmlDocument xml = new XmlDocument();
            xml.LoadXml(responseContent);
            var result = new PolicyResult()
            {
                vars = new PolicyVars()
            };
            return CheckPublicSources(xml, result);
        }

        public Task<PolicyResult> CallCheckPublicSources(XmlDocument PublicSources)
        {
            var result = new PolicyResult() 
            { 
                vars = new PolicyVars()
            };
            return CheckPublicSources(PublicSources, result);
        }

        //Наличие в списках по данным из публичных источников
        private async Task<PolicyResult> CheckPublicSources(XmlDocument PublicSources, PolicyResult result)
        {
            //d.Перечень налогоплательщиков, осуществивших лжепредпринимательскую деятельность. KGD02
            result = await CheckPublicSource(PublicSources, result, "FalseBusi/Status");
            result.vars.FalseBusi = result.isReject ? result.CheckStatus : RejectStatuses.Correct;

            //e.Списки несостоятельных должников/Список банкротов.  KGD03
            result = await CheckPublicSource(PublicSources, result, "Bankruptcy/Status");
            result.vars.Bankruptcy = result.isReject ? result.CheckStatus : RejectStatuses.Correct;

            //Розыск Комитетом государственных доходов Министерства Финансов РК KGD05
            result = await CheckPublicSource(PublicSources, result, "KgdWanted/Status");
            result.vars.KgdWanted = result.isReject ? result.CheckStatus : RejectStatuses.Correct;

            //Список налогоплательщиков, признанных банкротами  KGD12
            result = await CheckPublicSource(PublicSources, result, "BankruptKgd/Status");
            result.vars.BankruptKgd = result.isReject ? result.CheckStatus : RejectStatuses.Correct;

            //Розыск преступников, должников, без вести пропавших лиц Комитетом по правовой статистике и специальным учетам ГП РК KPS01
            result = await CheckPublicSource(PublicSources, result, "QamqorList/Status");
            result.vars.QamqorList = result.isReject ? result.CheckStatus : RejectStatuses.Correct;

            //Сведения о лицах, привлеченные к уголовной отвественности за совершение уголовных правонарушений против половой неприкосновенности несовершеннолетних EGV01
            result = await CheckPublicSource(PublicSources, result, "Pedophile/Status");
            result.vars.Pedophile = result.isReject ? result.CheckStatus : RejectStatuses.Correct;

            //c.Перечень организаций и лиц, связанных с финансированием терроризма и экстремизма
            result = await CheckPublicSource(PublicSources, result, "TerrorList/Status");
            result.vars.TerrorList = result.isReject ? result.CheckStatus : RejectStatuses.Correct;

            //Список налогоплательщиков, признанных бездействующими
            result = await CheckPublicMinorSource(PublicSources, result, "Inactive/Status");
            result.vars.Inactive = result.isReject ? result.CheckStatus : RejectStatuses.Correct;

            //Розыск алиментщиков Комитетом по правовой статистике и специальным учетам ГП РК
            result = await CheckPublicMinorSource(PublicSources, result, "QamqorAlimony/Status");
            result.vars.QamqorAlimony = result.isReject ? result.CheckStatus : RejectStatuses.Correct;

            //Сведения об отсутствии (наличии) задолженности, учет по которым ведется в органах государственных доходов
            result = await CheckPublicMinorSource(PublicSources, result, "TaxArrear/Status");
            result.vars.TaxArrear = result.isReject ? result.CheckStatus : RejectStatuses.Correct;

            return result;
        }
        private async Task<PolicyResult> CheckPublicSource(XmlDocument PublicSources, PolicyResult result, string path)
        {
            try
            {
                if (PublicSources.SelectSingleNode(path) != null)
                {
                    string publicSourceCode = PublicSources.SelectSingleNode(path + "/@id").InnerText;
                    if (publicSourceCode != "2")
                    {
                        result.isReject = true;
                        
                        result.PolicyRejectReason = "Отказано. Негативная информация по заявителю из публичных источников";
                        result.CheckStatus = RejectStatuses.Critical;
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = 1;
            }
            return result;
        }

        private async Task<PolicyResult> CheckPublicMinorSource(XmlDocument PublicSources, PolicyResult result, string path)
        {
            try
            {
                int count = 0;
                if (PublicSources.SelectSingleNode(path) != null)
                {
                    string publicSourceCode = PublicSources.SelectSingleNode(path + "/@id").InnerText;
                    if (publicSourceCode != "2")
                    {
                        if(path == "TaxArrear/Status")
                        {
                            if (PublicSources.SelectSingleNode("TaxArrear/Companies") != null && PublicSources.SelectSingleNode("TaxArrear/Companies/Company") != null && PublicSources.SelectNodes("TaxArrear/Companies/Company").Count > 0)
                            {
                                foreach (XmlNode node in PublicSources.SelectNodes("TaxArrear/Companies/Company"))
                                {
                                    count += Convert.ToInt32(node.SelectSingleNode("TotalDeby").InnerText);
                                }
                                if (count > 0)
                                {
                                    result.isReject = true;
                                    result.CheckStatus = RejectStatuses.Minor;
                                }
                            }
                        }
                        else
                        {
                            result.isReject = true;
                            result.CheckStatus = RejectStatuses.Minor;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.ErrorCode = 1;
            }
            return result;
        }
    }
}
