using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Data.Enums.System;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.Common.Delegates;
using Agro.Shared.Logic.Common.Enums;
using Agro.Shared.Logic.Common.Exceptions;
using Agro.Shared.Logic.CQRS.ClientActivities.DTOs;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.File;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using OfficeOpenXml;

namespace Agro.Shared.Logic.CQRS.FinancialAnalysis
{
    public class FillTemplateFile
    {
        public class Command : IRequest<Response<Unit>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Response<Unit>>
        {
            private readonly Data.Context.DataContext _dataContext;
            private readonly IHostEnvironment _hostEnvironment;
            private readonly IMediator _mediator;
            private readonly IFileService _fileService;

            private static readonly string _fileName = "Express_Analysis";
            private static readonly string _fileExtension = "xlsx";

            private static readonly string _templateFileName = $"{_fileName}.{_fileExtension}";

            public CommandHandler(
                Data.Context.DataContext dataContext,
                IHostEnvironment hostEnvironment,
                IMediator mediator,
                Delegates.FileServiceResolver fileServiceResolver
            )
            {
                _dataContext = dataContext;
                _hostEnvironment = hostEnvironment;
                _mediator = mediator;
                _fileService = fileServiceResolver(FileServiceTypeEnum.Database);
            }

            public async Task<Response<Unit>> Handle(Command request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications
                    .Include(x=>x.DicLoanType)
                    .FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId);
                if (application == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                if (application.DicLoanType.Value == LoanTypeEnum.StandartLeasing)
                    return Response.Success("Файл экспресс анализа не формируется для стандартного лизинга", Unit.Value);

                var details = await _dataContext.LoanApplicationDetails
                    .Include(x => x.DetailsPersonalities)
                    .FirstOrDefaultAsync(x => x.LoanApplicationId == application.Id);
                if (details == null)
                    throw new RestException(HttpStatusCode.NotFound, "Детали заявки еще не заполнены");

                var organizationPersonalityDetails = details.DetailsPersonalities
                    .FirstOrDefault(x => x.PersonalityType == PersonalityTypeEnum.Organization);
                var organization = await _dataContext.Organizations
                    .Where(x => x.PersonalityId == organizationPersonalityDetails.PersonalityId)
                    .Select(x => new {
                        x.Personality.FullName,
                        //Oked = x.OKED.Select(xx => xx.DicOKED.NameRu)
                    })
                    .FirstOrDefaultAsync();

                if (organization == null)
                    throw new RestException(HttpStatusCode.NotFound, "Организация не найдена");

                var headPersonality = details.DetailsPersonalities
                    .FirstOrDefault(x => x.PersonalityType == PersonalityTypeEnum.Head);
                var person = await _dataContext.People
                    .Where(x => x.PersonalityId == headPersonality.PersonalityId)
                    .Select(x => new {
                        WorkExperience = x.Personality.WorkExperience.Agriculture
                    })
                    .FirstOrDefaultAsync();

                if (person == null)
                    throw new RestException(HttpStatusCode.NotFound, "Руководитель не найден");

                var contracts = await (from c in _dataContext.Contracts.Include(x => x.Calculator)
                                       where c.LoanApplicationId == application.Id
                                       select c).ToListAsync();

                var assets = await _mediator.Send(new ClientActivities.Get.GetActivitiesQuery { LoanApplicationId = request.LoanApplicationId });

                var filePath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "docs", "templates", _templateFileName);
                int nameRow = 5, nameColumn = 4,
                    dateRow = 5, dateColumn = 13,
                    regionRow = 9, regionColumn = 4,
                    experienceTotalRow = 16, experienceTotalColumn = 4,
                    //mainDeptRow = 11, mainDeptColumn = 15,
                    typeOfActivityRow = 14, typeOfActivityColumn = 4,

                    contractRow = 21, contractNameColumn = 3, contractSumColumn = 4, contractPeriodColumn = 5,
                    contractFromChinaColumn = 6, contractCoFinancingColumn = 7, contractRateColumn = 10,

                    landSquareRow = 34, landFloraSquareColumn =14, landLivestockSquareColumn = 12, landOtherSquare = 16,

                    floraRow = 41, floraNameColumn = 3, floraCurrentProductivityColumn = 4,
                    floraBefore1yearProductivityColumn = 10,
                    floraBefore2yearProductivityColumn = 8,
                    floraBefore3yearProductivityColumn = 6,
                    floraCultureRow = 66, floraSeedingRateRow = 67, floraPriceRealizationRow = 69, floraCostRow = 71, floraSecondaryStartColumn = 4,

                    livestockRow = 79, 
                    krsCountColumn = 4, krsLiveWeightColumn = 5, krsSlaughterWeightColumn = 6,
                    horseCountColumn = 9, horseLiveWeightColumn = 10, horseSlaughterWeightColumn = 11,
                    mrsCountColumn = 14, mrsLiveWeightColumn = 15, mrsSlaughterWeightColumn = 16,
                    
                    livePriceColumn = 11, slaughterPriceColumn = 12;
                
                using ExcelPackage p = new ExcelPackage(new FileInfo(filePath));

                var mainWS = p.Workbook.Worksheets[0];
                var livestockWS = p.Workbook.Worksheets[1];

                mainWS.Cells[nameRow, nameColumn].Value = organization.FullName;
                mainWS.Cells[dateRow, dateColumn].Value = DateTime.Now.ToLongDateString();
                mainWS.Cells[regionRow, regionColumn].Value = "Акмолинская";
                mainWS.Cells[experienceTotalRow, experienceTotalColumn].Value = person.WorkExperience;
                //ws.Cells[mainDeptRow, mainDeptColumn].Value = 5 * 1000000; //размер ОД по текущим договорам перед обществом
                mainWS.Cells[typeOfActivityRow, typeOfActivityColumn].Value = GetActivityDirection(assets.Data); //направление деятельности

                foreach (var (contract, index) in contracts.Select((contract, index) => (contract, index)))
                {
                    mainWS.Cells[contractRow + index, contractNameColumn].Value = $"Предмет лизинга {index + 1}";
                    mainWS.Cells[contractRow + index, contractSumColumn].Value = contract.Calculator.Sum;
                    mainWS.Cells[contractRow + index, contractPeriodColumn].Value = contract.Calculator.Period;
                    mainWS.Cells[contractRow + index, contractFromChinaColumn].Value = "нет"; // TODO: check in DB query by joins
                    mainWS.Cells[contractRow + index, contractCoFinancingColumn].Value = contract.Calculator.CoFinancing / 100;
                    mainWS.Cells[contractRow + index, contractRateColumn].Value = contract.Calculator.Rate / 100;
                }

                mainWS.Cells[landSquareRow, landLivestockSquareColumn].Value = assets.Data.LandActivities?.FirstOrDefault(x => x.LandTypeCode == "2")?.Square ?? 0;
                mainWS.Cells[landSquareRow, landFloraSquareColumn].Value = assets.Data.LandActivities?.FirstOrDefault(x => x.LandTypeCode == "1")?.Square ?? 0;
                mainWS.Cells[landSquareRow, landOtherSquare].Value = assets.Data.LandActivities?.FirstOrDefault(x => x.LandTypeCode == "3")?.Square ?? 0;

                foreach (var (asset, index) in assets.Data.FloraActivities?.Select((asset, index) => (asset, index)))
                {
                    mainWS.Cells[floraRow + index * 2, floraNameColumn].Value = asset.Culture;
                    mainWS.Cells[floraRow + index * 2, floraCurrentProductivityColumn].Value = asset.PlannedSquare;
                    mainWS.Cells[floraRow + index * 2, floraBefore3yearProductivityColumn].Value = asset.ProductivityBeforeLastYear;
                    mainWS.Cells[floraRow + index * 2, floraBefore2yearProductivityColumn].Value = asset.ProductivityLastYear;
                    mainWS.Cells[floraRow + index * 2, floraBefore1yearProductivityColumn].Value = asset.ProductivityCurrentYear;

                    mainWS.Cells[floraCultureRow, floraSecondaryStartColumn + index].Value = asset.Culture;
                    mainWS.Cells[floraSeedingRateRow, floraSecondaryStartColumn + index].Value = asset.SeedingRate;
                    mainWS.Cells[floraPriceRealizationRow, floraSecondaryStartColumn + index].Value = asset.PriceRealization;
                    mainWS.Cells[floraCostRow, floraSecondaryStartColumn + index].Value = asset.Cost;
                }

                var livestockTypes = await _dataContext.DicLivestockTypes.ToListAsync();
                foreach (var group in assets.Data.LivestockActivities.GroupBy(x => x.LivestockTypeParentId))
                {
                    var parentLivestockType = livestockTypes.Single(x => x.Id == group.Key);

                    if (parentLivestockType.Code == "1") // КРС
                    {
                        FillLivestockTableAssets(mainWS, group, livestockTypes, livestockRow, krsCountColumn, krsLiveWeightColumn, krsSlaughterWeightColumn);                        
                    } 
                    else if (parentLivestockType.Code == "2") // Лошади
                    {
                        FillLivestockTableAssets(mainWS, group, livestockTypes, livestockRow, horseCountColumn, horseLiveWeightColumn, horseSlaughterWeightColumn);
                    }
                    else if (parentLivestockType.Code == "3") // МРС
                    {
                        FillLivestockTableAssets(mainWS, group, livestockTypes, livestockRow, mrsCountColumn, mrsLiveWeightColumn, mrsSlaughterWeightColumn);
                    }

                    FillLivestockSheetAssets(livestockWS, group, livestockTypes, livePriceColumn, slaughterPriceColumn);
                }

                var fileStream = new MemoryStream(p.GetAsByteArray());
                var formFile = new FormFile(fileStream, 0, fileStream.Length, _fileName, _templateFileName)
                {
                    Headers = new HeaderDictionary(),
                    ContentType = "application/pdf"
                };

                var files = await _fileService.GetEntityFiles(EntityType.LoanApplication, application.Id);
                var existingFileInfo = files.FirstOrDefault(x => x.Filename == _templateFileName);
                if (existingFileInfo != null)
                    await _fileService.RemoveAsync(existingFileInfo.Id);

                await _fileService.UploadAsync(formFile, EntityType.LoanApplication, application.Id);

                //return new DownloadFileResult
                //{
                //    ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                //    Filename = $"Экспресс-анализ_{DateTime.Now:HHmmss}.xlsx",
                //    Stream = new MemoryStream(p.GetAsByteArray())
                //};

                return Response.Success("Файл экспресс анализа сформирован успешно", Unit.Value);
            }

            private string GetActivityDirection(ActivityDto assets)
            {
                if (assets.FloraActivities.Any() && !assets.LivestockActivities.Any())
                {
                    return "Растениеводство";
                }
                else if (assets.LivestockActivities.Any() && !assets.FloraActivities.Any())
                {
                    return "Животноводство";
                }

                return "Смешанное";
            }

            private int? GetLivestockMainTableRowOffset(DicLivestockType livestockType)
            {
                // TODO: Migtrate new types and filfull all cases
                return livestockType.Code switch
                {
                    _ when livestockType.Code == "101" || livestockType.Code == "201" || livestockType.Code == "301" => 0,
                    _ when livestockType.Code == "102" || livestockType.Code == "202" => 1,
                    _ when livestockType.Code == "302" => 2,
                    _ => null
                };
            }

            private int? GetLivestockSecondaryTableRowOffset(DicLivestockType livestockType)
            {
                // TODO: Migtrate new types and filfull all cases
                return livestockType.Code switch
                {
                    // КРС
                    "101" => 5,
                    "102" => 6,
                    // МРС
                    "201" => 29,
                    "202" => 30,
                    // Лошади
                    "301" => 18,
                    "302" => 20,
                    _ => null,
                };
            }
            
            private void FillLivestockTableAssets(ExcelWorksheet ws, 
                IGrouping<Guid?, 
                LivestockActivityDto> group, 
                List<DicLivestockType> livestockTypes, 
                int row, 
                int countColumn, int liveWeightColumn, int slaughterWeightColumn)
            {
                foreach (var asset in group.ToList())
                {
                    var liveStockType = livestockTypes.Single(x => x.Id == asset.LivestockTypeId);

                    var rowIndex = GetLivestockMainTableRowOffset(liveStockType);
                    if (rowIndex.HasValue)
                    {
                        ws.Cells[row + rowIndex.Value, countColumn].Value = asset.Count;
                        ws.Cells[row + rowIndex.Value, liveWeightColumn].Value = asset.LiveWeight;
                        ws.Cells[row + rowIndex.Value, slaughterWeightColumn].Value = asset.SlaughterWeight;
                    }
                }
            }
            
            private void FillLivestockSheetAssets(ExcelWorksheet ws, 
                IGrouping<Guid?, 
                LivestockActivityDto> group, 
                List<DicLivestockType> livestockTypes, 
                int livePriceColumn, int slaughterPriceColumn)
            {
                foreach (var asset in group.ToList())
                {
                    var liveStockType = livestockTypes.Single(x => x.Id == asset.LivestockTypeId);
                    var rowIndex = GetLivestockSecondaryTableRowOffset(liveStockType);
                    if (rowIndex.HasValue)
                    {
                        ws.Cells[rowIndex.Value, livePriceColumn].Value = asset.LivePrice;
                        ws.Cells[rowIndex.Value, slaughterPriceColumn].Value = asset.SlaughterPrice;
                    }
                }
            }
        }
    }
}
