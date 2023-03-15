using System.Collections.Generic;

namespace Agro.Bpm.Logic.CQRS.Comments.Dto
{
    public class ListResponse
    {
        public List<CommentDto> List { get; set; } = new List<CommentDto> { };

        public long Count { get; set; }
    }
}
