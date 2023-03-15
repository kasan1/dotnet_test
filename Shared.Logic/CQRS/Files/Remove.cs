using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.File;
using MediatR;

namespace Agro.Shared.Logic.CQRS.Files
{
    public class Remove
    {
        public class RemoveCommand : IRequest<Response<Unit>>
        {
            public Guid FileId { get; set; }
        }

        public class RemoveCommandHandler : IRequestHandler<RemoveCommand, Response<Unit>>
        {
            private readonly IFileService _fileService;

            public RemoveCommandHandler(Delegates.FileServiceResolver fileServiceResolver)
            {
                _fileService = fileServiceResolver(FileServiceTypeEnum.Database);
            }

            public async Task<Response<Unit>> Handle(RemoveCommand request, CancellationToken cancellationToken)
            {
                await _fileService.RemoveAsync(request.FileId);

                return Response.Success("Файл успешно удален", Unit.Value);
            }
        }
    }
}
