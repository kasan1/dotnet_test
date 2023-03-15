using System;
using System.Threading.Tasks;

namespace Agro.Scoring.Logic.FinAnalysis
{
    public interface IFinAnalysisLogic
    {
        Task Start(Guid applicationId);
    }
}
