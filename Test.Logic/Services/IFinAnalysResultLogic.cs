using System;
using System.Threading.Tasks;

namespace Agro.Okaps.Logic
{
    public interface IFinAnalysResultLogic
    {
        Task<object> GetFinAnalysResult(Guid ApplicationId);
        Task<object> GetFinAnalysResultForClient(Guid ApplicationId);
    }
}