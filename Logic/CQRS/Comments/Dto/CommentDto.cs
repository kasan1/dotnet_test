using System;
using System.Collections.Generic;
using Agro.Shared.Logic.CQRS.Files.DTOs;

namespace Agro.Bpm.Logic.CQRS.Comments.Dto
{
    public class CommentDto
    {
        public Guid CommentId { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Text { get; set; }
        public IEnumerable<FileDto> Files { get; set; }
    }
}
