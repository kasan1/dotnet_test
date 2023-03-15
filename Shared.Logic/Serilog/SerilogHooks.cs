using System.IO.Compression;
using Serilog.Sinks.File.Archive;

namespace Agro.Shared.Logic.Serilog
{
    public class SerilogHooks
    {
        public static ArchiveHooks MyArchiveHooks = new ArchiveHooks(CompressionLevel.Fastest, "C:\\Logs\\Archived");
    }
}
