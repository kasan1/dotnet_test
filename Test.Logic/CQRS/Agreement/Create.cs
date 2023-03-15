using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using MediatR;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Data.Primitives;

namespace Agro.Okaps.Logic.CQRS.Agreement
{
    public class Create
    {
        public class Command : IRequest<Response<Guid>>
        {
            public Guid? UserId { get; set; }
            public string SignedXml { get; set; }
            public AgreementTypeEnum AgreementType { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Response<Guid>>
        {
            private readonly DataContext _dataContext;
            private readonly IMediator _mediator;

            public CommandHandler(DataContext dataContext, IMediator mediator)
            {
                _dataContext = dataContext;
                _mediator = mediator;
            }

            public async Task<Response<Guid>> Handle(Command request, CancellationToken cancellationToken)
            {
                await _mediator.Send(new Shared.Logic.CQRS.Kalkan.Check.Command
                {
                    SignedXml = request.SignedXml
                });

                var agreement = new Shared.Data.Entities.Identity.Agreement
                {
                    AgreementType = request.AgreementType,
                    SignedXml = request.SignedXml
                };

                await _dataContext.Agreements.AddAsync(agreement, cancellationToken);
                await _dataContext.SaveChangesAsync(cancellationToken);

                return Response.Success("Запрос выполнен успешно", agreement.Id);
            }
        }
    }
}
