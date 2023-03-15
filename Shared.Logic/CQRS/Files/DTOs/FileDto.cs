using System;

namespace Agro.Shared.Logic.CQRS.Files.DTOs
{
    public class FileDto
    {
        public Guid Id { get; set; }
        public string Filename { get; set; }
        public string Url { get; set; }
    }
}
