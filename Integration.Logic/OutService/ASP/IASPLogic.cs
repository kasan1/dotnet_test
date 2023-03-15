using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Integration.Logic.OutService.ASP
{
    public interface IASPLogic
    {
        Task<bool?> GetASP(string iin);
    }
}
