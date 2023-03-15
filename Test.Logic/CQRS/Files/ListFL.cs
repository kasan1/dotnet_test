using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.CQRS.Files.DTOs;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace Agro.Okaps.Logic.CQRS.Files
{
    public class ListFL
    {
        public class ListFLQuery : IRequest<Response<List<FileDto>>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class QueryHandler : IRequestHandler<ListFLQuery, Response<List<FileDto>>>
        {
            private const string _rootFolderName = "wwwroot";
            private const string _docsFolderName = "docs";
            private const string _destinationFolderName = "fl";
            private readonly IHostEnvironment _env;
            private readonly DataContext _dataContext;

            public QueryHandler(IHostEnvironment env, DataContext dataContext)
            {
                _env = env;
                _dataContext = dataContext;
            }

            public async Task<Response<List<FileDto>>> Handle(ListFLQuery request, CancellationToken cancellationToken)
            {
                var result = new List<FileDto>();

                var application = await _dataContext.LoanApplications
                    .Include(x => x.DicLoanType)
                    .FirstOrDefaultAsync(x => x.Id == request.LoanApplicationId);
                if (application == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                var subFolderName = "Express";
                if (application.DicLoanType.Value == LoanTypeEnum.StandartLeasing)
                    subFolderName = "Standard";

                var directoryInfo = new DirectoryInfo(Path.Combine(_env.ContentRootPath, _rootFolderName, _docsFolderName, _destinationFolderName, subFolderName));
                foreach (var file in directoryInfo.GetFiles())
                {
                    result.Add(new FileDto
                    {
                        Id = Guid.NewGuid(), // Does not matter, only read only files are listed
                        Filename = file.Name,
                        Url = $"{_docsFolderName}/{_destinationFolderName}/{subFolderName}/{file.Name}"
                    });
                }

                return Response.Success("Запрос выполнен успешно", result);
            }
        }
    }
}
