using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Scoring.Logic.FinAnalysis
{
    public interface IQueueScheduler
    {
        Task FindTask();
    }
}
