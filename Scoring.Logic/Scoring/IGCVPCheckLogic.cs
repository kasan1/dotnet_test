using System;
using System.Collections.Generic;
using System.Text;

namespace Agro.Scoring.Logic.Scoring
{
    public interface IGCVPCheckLogic
    {
        GCVP CallCheckPublicSources(Guid outServiceId);
    }
}
