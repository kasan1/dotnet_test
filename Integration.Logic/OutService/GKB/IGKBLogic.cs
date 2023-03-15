using Agro.Shared.Logic.Primitives;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Agro.Integration.Logic.OutService.GKB
{
    public interface IGKBLogic
    {
        Task<IDictionary<ReportTypes, string>> GetCreditReportTypes(string iin);
        Task<Guid?> GetGKBX(string iin, string reportName);
        Task<byte[]> GetGKBFile(string iin, string reportName);
        Task<Guid> GetGKBNew(string iin, string reportName, bool isFL = true);

    }
}
