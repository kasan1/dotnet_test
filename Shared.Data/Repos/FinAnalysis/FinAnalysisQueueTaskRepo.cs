using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.FinAnalysis
{
    public class FinAnalysisQueueTaskRepo : BaseRepo<FinAnalysisQueueTask>, IFinAnalysisQueueTaskRepo
    {
        public FinAnalysisQueueTaskRepo(DataContext context) : base(context)
        {
        }
    }
}
