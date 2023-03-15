using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Bpm.Logic.CQRS.Comments.Dto;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.CQRS.Files;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Agro.Bpm.Logic.CQRS.Comments
{
    public class List
    {
        public class ListQuery : ListFilter, IRequest<Response<ListResponse>>
        {
            public Guid RoleControlsFieldId { get; set; }

            public Guid LoanApplicationTaskId { get; set; }
        }

        public class ListQueryHandler : IRequestHandler<ListQuery, Response<ListResponse>>
        {
            private readonly DataContext _dataContext;
            private readonly IMediator _mediator;

            public ListQueryHandler(IMediator mediator, DataContext dataContext)
            {
                _mediator = mediator;
                _dataContext = dataContext;
            }

            public async Task<Response<ListResponse>> Handle(ListQuery request, CancellationToken cancellationToken)
            {
                var loanApplicationTask = await _dataContext.LoanApplicationTasks.FirstOrDefaultAsync(x => x.Id == request.LoanApplicationTaskId);
                if (loanApplicationTask == null)
                    throw new RestException(HttpStatusCode.NotFound, "Задача не найдена");

                var query = _dataContext.Comments
                   .Where(x => x.ApplicationId == loanApplicationTask.ApplicationId 
                        && x.RoleControlsFieldId == request.RoleControlsFieldId && !x.IsDeleted)
                   .AsQueryable();

                var list = await query
                      .AsNoTracking()
                      .OrderByDescending(x => x.CreatedDate)
                      .Skip(request.Skip)
                      .Take(request.PageLimit)
                      .Select(x => new CommentDto
                      {
                          Author = x.User.Profile.GetShortName(),
                          CommentId = x.Id,
                          Date = x.CreatedDate,
                          Text = x.Text
                      })
                      .ToListAsync();

                //TODO: пересмотреть реализацию получения списка файлов
                foreach (var comment in list)
                    comment.Files = (await _mediator.Send(new ListByEntity.Query
                    {
                        EntityId = comment.CommentId,
                        EntityType = EntityType.Comment
                    }, cancellationToken)).Data;

                var result = new ListResponse
                {
                    List = list.OrderBy(x => x.Date).ToList(),
                    Count = await query.CountAsync()
                };

                return Response.Success("Запрос выполнен успешно", result);
            }
        }
    }
}
