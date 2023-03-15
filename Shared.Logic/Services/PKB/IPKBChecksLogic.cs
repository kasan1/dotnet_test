using Agro.Shared.Data.Context;
using System;
using System.Threading.Tasks;
using System.Xml;

namespace Agro.Shared.Logic.OutService.PKB
{
    public interface IPKBChecksLogic
    {
        /// <summary>
        /// проверка из публичных источников
        /// </summary>
        Task<PolicyRules.PolicyResult> CallCheckPublicSources(Guid outServiceId);
        Task<PolicyRules.PolicyResult> CallCheckPublicSources(XmlDocument PublicSources);
    }
}