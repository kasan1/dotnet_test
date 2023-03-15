using Agro.Shared.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Shared.Data.Repos.FinAnalysis
{
    public class FinAnalysisRepo : BaseRepo<Context.FinAnalysis>, IFinAnalysisRepo
    {
        public FinAnalysisRepo(DataContext context) : base(context)
        {
        }
    }
}
