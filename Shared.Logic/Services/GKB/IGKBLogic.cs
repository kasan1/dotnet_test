using Agro.Shared.Logic.Primitives;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Shared.Logic.GKB
{
    public interface IGKBLogic
    {
        Task<IDictionary<ReportTypes, string>> GetCreditReportTypes(string iin);
        Task<Guid?> GetGKBX(string iin, string reportName);
        Task<byte[]> GetGKBFile(string iin, bool isFL = true, CancellationToken cancellation = default);
        Task<Guid> GetGKBNew(string iin, string reportName, bool isFL = true);

    }
}
