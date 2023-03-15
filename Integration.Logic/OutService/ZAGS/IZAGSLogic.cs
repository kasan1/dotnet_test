using Agro.Integration.Logic.OutService.ZAGS.Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Integration.Logic.OutService.ZAGS
{
    public interface IZAGSLogic
    {
        Task<Guid?> GetZAGS(string iin);
        Task<ZagsPersonInfo> GetZAGSByIin(string iin);
    }
}
