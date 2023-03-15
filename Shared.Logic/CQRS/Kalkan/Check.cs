using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Common.Exceptions;
using KalkanCryptCOMLib;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Agro.Shared.Logic.CQRS.Kalkan
{
    public class Check
    {
        public class Command : IRequest<Unit>
        {
            public string SignedXml { get; set; }
            public string Identifier { get; set; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly string _signatureOkResult;
            private readonly ILogger<Check> _logger;
            public Handler(ILogger<Check> logger)
            {
                _signatureOkResult = "Signature is OK";
                _logger = logger;
            }

            public Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var kalkan = new KalkanCryptCOM();
                kalkan.Init();
                kalkan.VerifyXML("", 0, request.SignedXml, out string result);

                kalkan.GetLastErrorString(out string error, out uint rv);
                if (!string.IsNullOrEmpty(error))
                    _logger.LogInformation("kalkan.VerifyXML ERROR: " + error);

                if (result?.Length > _signatureOkResult.Length)
                {
                    var signatureResult = result.Substring(result.Length - _signatureOkResult.Length - 1, _signatureOkResult.Length);
                    if (signatureResult != _signatureOkResult)
                        throw new RestException(HttpStatusCode.BadRequest, "Ошибка подписи");

                    if (!string.IsNullOrEmpty(request.Identifier))
                    {
                        var identifier = result.Substring(result.Length - _signatureOkResult.Length - 14, 12);
                        if (identifier != request.Identifier)
                            throw new RestException(HttpStatusCode.BadRequest, "Некорректный ИИН/БИН");
                    }
                }
                else
                    throw new RestException(HttpStatusCode.BadRequest, "Не удалось выполнить проверку подписи");
                
                return Task.FromResult(Unit.Value);
            }
        }
    }
}
