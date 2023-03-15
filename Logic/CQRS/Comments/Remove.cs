using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.CQRS.Files;
using Agro.Shared.Logic.Models.Common;
using MediatR;

namespace Agro.Bpm.Logic.CQRS.Comments
{
    public class Remove
    {
        public class Command : IRequest<Response<Unit>>
        {
            public Guid CommentId { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IMediator _mediator;

            public CommandHandler(DataContext dataContext, IMediator mediator)
            {
                _dataContext = dataContext;
                _mediator = mediator;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var comment = await _dataContext.Comments.FindAsync(request.CommentId);
                if (comment == null)
                    throw new RestException(HttpStatusCode.NotFound, "Комментарий не найден");

                var commentFiles = (await _mediator.Send(new ListByEntity.Query
                {
                    EntityId = comment.Id,
                    EntityType = EntityType.Comment
                }, cancellationToken)).Data;

                foreach (var file in commentFiles)
                {
                    await _mediator.Send(new Shared.Logic.CQRS.Files.Remove.RemoveCommand() { FileId = file.Id }, cancellationToken);
                }

                _dataContext.Comments.Remove(comment);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return Response.Success("Комментарий успешно удален", Unit.Value);
            }
        }
    }
}
