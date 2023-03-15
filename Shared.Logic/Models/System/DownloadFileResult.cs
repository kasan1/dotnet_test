using System.IO;

namespace Agro.Shared.Logic.Models.System
{
    public class DownloadFileResult
    {
        public string Filename { get; set; }
        public string ContentType { get; set; }
        public Stream Stream { get; set; }
    }
}
