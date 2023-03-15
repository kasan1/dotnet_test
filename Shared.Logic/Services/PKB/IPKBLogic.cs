using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Agro.Shared.Logic.OutService.PKB
{
    public interface IPKBLogic
    {
        Task<Guid?> GetPKBXml(string iin, CancellationToken cancellationToken = default);
        Task<Stream> GetPKBFile(string iin, CancellationToken cancellationToken = default);
        Task<PkbIpInfo> GetIpInfoByPKB(string iin);

    }
}
