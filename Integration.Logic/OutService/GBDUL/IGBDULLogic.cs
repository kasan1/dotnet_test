using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Integration.Logic.OutService.GBDUL
{
    public interface IGBDULLogic
    {
        Task<Guid> GetGBDUL(string bin);
    }
}
