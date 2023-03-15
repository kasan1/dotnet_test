using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Integration.Logic.OutService.GCVP
{
    public interface IGCVPLogic
    {
        Task<Guid?> GetGCVP(string iin);
    }
}
