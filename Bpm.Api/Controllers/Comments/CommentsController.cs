using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.Comments;
using System;
using Agro.Shared.Api.Controllers;

namespace Agro.Bpm.Api.Controllers.Values
{
    public class CommentsController : MediatrControllerBase
    {
        [HttpPost]
        [Route(ApiRoutes.Comments.AddComment)]
        public async Task<IActionResult> AddComment([FromForm] AddComment.AddCommentCommand command, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(command, cancellationToken));
        }

        [HttpGet]
        [Route(ApiRoutes.Comments.List)]
        public async Task<IActionResult> List([FromQuery] List.ListQuery query, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(query, cancellationToken));
        }

        [HttpDelete]
        [Route(ApiRoutes.Comments.Remove)]
        public async Task<IActionResult> Remove([FromRoute] Guid commentId, CancellationToken cancellationToken)
        {
            return Ok(await Mediator.Send(new Remove.Command() { CommentId = commentId }, cancellationToken));
        }
    }
}
