using System;

namespace Agro.Shared.Logic.Models.System
{
    public class FileMetaData
    {
        public Guid Id { get; set; }
        public Guid EntityId { get; set; }
        public string Filename { get; set; }
        public string ContentType { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
    }
}
