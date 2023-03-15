using Agro.Okaps.Logic.Models;
using System;
using System.Threading.Tasks;

namespace Agro.Okaps.Logic
{
    public interface IExpetiseResultLogic
    {
        Task<object> AddExpertiseResult(ExpertiseResultInDto model);
        Task<string> GetExpertiseResultForCamunda(Guid ApplicationId);
        Task<object> GetExpertiseResults(Guid ApplicationId);
        bool GetExpertiseResultsJurist(Guid ApplicationId);
    }
}