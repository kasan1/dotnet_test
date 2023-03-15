using Agro.Shared.Logic.OutService.PKB;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.Services.System.File;
using Agro.Shared.Data.Enums.System;

namespace Agro.Bpm.Logic.CQRS.Integrations.PKB
{
    public class UploadFileByIin
    {
        public class Command : IRequest<Unit>
        {
            public string Iin { get; set; }
            public Guid LoanApplicationId { get; set; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly IPKBLogic _pKBLogic;
            private readonly IFileService _fileService;

            public Handler(IPKBLogic pKBLogic, Delegates.FileServiceResolver fileServiceResolver)
            {
                _pKBLogic = pKBLogic;
                _fileService = fileServiceResolver(FileServiceTypeEnum.Database);
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                using var fileStream = await _pKBLogic.GetPKBFile(request.Iin, cancellationToken);

                var formFile = new FormFile(fileStream, 0, fileStream.Length, "PKB", "PKB.pdf") 
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/pdf"
                };

                await _fileService.UploadAsync(formFile, EntityType.PKB, request.LoanApplicationId);

                return Unit.Value;
            }
        }
    }
}
