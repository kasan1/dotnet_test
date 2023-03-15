using Agro.Integration.Logic.OutService.GBDFL.Parse;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Integration.Logic.OutService.GBDFL
{
    public interface IGBDFLLogic
    {
        Task<Guid> GetGBDFL(string iin);
        Task<GBDFLPerson> GetGBDFLByIIN(string iin);
        Task<object> GetGBDByApplicationId(string ApplicationId);
    }
}
