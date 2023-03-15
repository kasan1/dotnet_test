using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Models.System;
using MediatR;

namespace Agro.Bpm.Logic.CQRS.Integrations._1C
{
    public class MonitoringReport
    {
        public class DownloadCommand : IRequest<Response<DownloadFileResult>>
        {
            public string Identifier { get; set; }
            public DateTime DateFrom { get; set; } 
            public DateTime DateTo { get; set; } 
        }

        public class Handler : IRequestHandler<DownloadCommand, Response<DownloadFileResult>>
        {
            private readonly IHttpClientFactory _httpClientFactory;
            
            public Handler(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }

            public async Task<Response<DownloadFileResult>> Handle(DownloadCommand request, CancellationToken cancellationToken)
            {

                using var client = _httpClientFactory.CreateClient("C1");

                var response = await client.GetAsync($"kaz10/hs/bpm/database/GetMonitorIIN/{request.Identifier}/{request.DateFrom:yyyy-MM-dd}/{request.DateTo:yyyy-MM-dd}", cancellationToken);

                if (!response.IsSuccessStatusCode)
                    throw new RestException(HttpStatusCode.NotFound, "Не удалось найти отчет");

                return Response.Success("Отчет успешно сформирован", new DownloadFileResult
                {
                    Filename = $"MonitoringReport{request.Identifier}_{request.DateFrom:ddMMyyyy}-{request.DateTo:ddMMyyyy}.zip",
                    ContentType = "application/zip",
                    Stream = await response.Content.ReadAsStreamAsync()
                });
            }
        }
    }
}
