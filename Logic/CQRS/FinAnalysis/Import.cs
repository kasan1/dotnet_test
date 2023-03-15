using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Entities.FinAnalysis;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace Agro.Bpm.Logic.CQRS.FinAnalysis
{
    public class Import
    {
        public class Command : IRequest<Response<Unit>>
        {
            public Guid TypeId { get; set; }

            public IFormFile File { get; set; }
        }

        public class Handler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly DataContext _dataContext;

            public Handler(DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                using var stream = new MemoryStream();
                await request.File.CopyToAsync(stream, cancellationToken);
                using ExcelPackage p = new ExcelPackage(stream);

                var type = await _dataContext.DicCheckingListTypes.FirstOrDefaultAsync(x => x.Id == request.TypeId, cancellationToken);
                if (type == null)
                    throw new RestException(System.Net.HttpStatusCode.BadRequest, "Тип списка не найден");

                //удаление старой информации 
                _dataContext.CheckingList.RemoveRange(_dataContext.CheckingList.Where(x => x.TypeId == request.TypeId));

                int rowIndex = 2,
                    identifierColumnIndex = 2,
                    nameColumnIndex = 3,
                    descriptionColumnIndex = 4; 

                foreach (var sheet in p.Workbook.Worksheets)
                {
                    while (rowIndex < sheet.Dimension.Rows)
                    {
                        var item = new CheckingList
                        {
                            TypeId = request.TypeId,
                            Identifier = sheet.Cells[rowIndex, identifierColumnIndex]?.Value?.ToString() ?? "000000000000",
                            Fullname = sheet.Cells[rowIndex, nameColumnIndex]?.Value?.ToString() ?? "",
                            Description = sheet.Cells[rowIndex, descriptionColumnIndex]?.Value?.ToString()
                        };

                        if (string.IsNullOrEmpty(item.Identifier) && string.IsNullOrEmpty(item.Fullname) && string.IsNullOrEmpty(item.Description))
                            continue;

                        await _dataContext.CheckingList.AddAsync(item, cancellationToken);

                        rowIndex++;
                    }
                }

                await _dataContext.SaveChangesAsync(cancellationToken);

                return Response.Success("Списки загрузились успешно", Unit.Value);
            }
        }
    }
}
