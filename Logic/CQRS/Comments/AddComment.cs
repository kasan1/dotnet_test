using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.CQRS.Files;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.Security;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.Comments
{
    public class AddComment
    {
        public class AddCommentCommand : IRequest<Response<Unit>>
        {
            public Guid LoanApplicationTaskId { get; set; }
            public Guid RoleControlsFieldId { get; set; }
            public string Text { get; set; }
            public IFormFileCollection Files { get; set; }
        }

        public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, Response<Unit>>
        {
            private readonly DataContext _dataContext;
            private readonly IUserAccessor _userAccessor;
            private readonly IMediator _mediator;

            public AddCommentCommandHandler(IMediator mediator, DataContext dataContext, IUserAccessor userAccessor)
            {
                _dataContext = dataContext;
                _userAccessor = userAccessor;
                _mediator = mediator;
            }

            public async Task<Response<Unit>> Handle(AddCommentCommand request, CancellationToken cancellationToken)
            {
                var loanApplicationTask = await _dataContext.LoanApplicationTasks
                       .Include(x => x.LoanApplication)
                       .FirstOrDefaultAsync(x => x.Id == request.LoanApplicationTaskId, cancellationToken);

                if (loanApplicationTask == null)
                    throw new RestException(HttpStatusCode.NotFound, "Задача не найдена");

                var comment = new Comment
                {
                    Id = Guid.NewGuid(),
                    RoleControlsFieldId = request.RoleControlsFieldId,
                    ApplicationId = loanApplicationTask.ApplicationId,
                    Text = request.Text,
                    UserId = _userAccessor.GetCurrentUserId()
                };
                await _dataContext.Comments.AddAsync(comment, cancellationToken);

                if (request.Files != null)
                    await _mediator.Send(new Upload.UploadCommand
                    {
                        EntityId = comment.Id,
                        EntityType = EntityType.Comment,
                        Files = request.Files
                    });

                await _dataContext.SaveChangesAsync(cancellationToken);

                return Response.Success("Замечание успешно сохранено", Unit.Value);
            }
        }
    }
}
