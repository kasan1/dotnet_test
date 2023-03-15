using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Agro.Shared.Logic.Common.Exceptions;
using System.Net;
using System;
using System.Collections.Generic;
using Agro.Shared.Logic.CQRS.ClientActivities.DTOs;

namespace Agro.Shared.Logic.CQRS.ClientActivities
{
    public class Get
    {
        public class GetActivitiesQuery : IRequest<Response<ActivityDto>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class GetActivitiesQueryHandler : IRequestHandler<GetActivitiesQuery, Response<ActivityDto>>
        {
            private readonly Data.Context.DataContext _dataContext;

            public GetActivitiesQueryHandler(Data.Context.DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<ActivityDto>> Handle(GetActivitiesQuery request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId);
                if (application == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");
                
                var activityDto = await _dataContext.Activities
                    .Where(x => x.LoanApplicationId == request.LoanApplicationId)
                    .Select(x => new ActivityDto { Id = x.Id }).FirstOrDefaultAsync();
                if (activityDto == null)
                    throw new RestException(HttpStatusCode.NotFound, "Активы не найдены");

                activityDto.LandActivities = await _dataContext.LandActivity.Where(x => x.ActivityId == activityDto.Id).Select(l => new LandActivityDto
                {
                    Id = l.Id,
                    LandTypeId = l.LandTypeId,
                    LandType = l.DicLandType.GetName(),
                    LandTypeCode = l.DicLandType.Code,
                    OwnershipTypeId = l.OwnershipTypeId,
                    OwnershipType = l.DicOwnershipType.GetName(),
                    Square = l.Square
                }).ToListAsync();

                var floraActivities = await _dataContext.FloraActivity
                        .Include(xx => xx.Productivities)
                        .Include(xx => xx.FloraCulture)
                        .Where(x => x.ActivityId == activityDto.Id)
                        .ToListAsync();

                var floraActivitiesDto = new List<FloraActivityDto>();
                foreach (var f in floraActivities)
                {
                    var productivities = f.Productivities.OrderByDescending(x => x.Year);
                    floraActivitiesDto.Add(new FloraActivityDto
                    {
                        Id = f.Id,
                        Cost = f.Cost,
                        PlannedSquare = f.PlannedSquare,
                        PriceRealization = f.PriceRealization,
                        SeedingRate = f.SeedingRate,
                        CultureId = f.FloraCultureId,
                        Culture = f.FloraCulture?.Name,
                        ProductivityCurrentYear = productivities?.FirstOrDefault()?.Value,
                        ProductivityLastYear = productivities?.Skip(1)?.FirstOrDefault()?.Value,
                        ProductivityBeforeLastYear = productivities?.Skip(2)?.FirstOrDefault()?.Value
                    });
                }
                activityDto.FloraActivities = floraActivitiesDto;

                activityDto.LivestockActivities = await _dataContext.LivestockActivity.Where(x => x.ActivityId == activityDto.Id)
                    .Select(ls => new LivestockActivityDto
                    {
                        Id = ls.Id,
                        Count = ls.Count,
                        LiveWeight = ls.LiveWeight,
                        SlaughterWeight = ls.SlaughterWeight,
                        LivePrice = ls.LivePrice,
                        SlaughterPrice = ls.SlaughterPrice,
                        LivestockTypeId = ls.LivestockTypeId,
                        LivestockType = ls.DicLivestockType.GetName(),
                        LivestockTypeParentId = ls.DicLivestockType.ParentId
                    }).ToListAsync();

                activityDto.TechnicActivities = await _dataContext.TechnicActivity.Where(x => x.ActivityId == activityDto.Id).Select(t => new TechnicActivityDto
                {
                    Id = t.Id,
                    Fullname = t.Fullname,
                    Count = t.Count,
                    CountOfCorrect = t.CountOfCorrect,
                    DateIssue = t.DateIssue,
                    IsPledged = t.IsPledged,
                    PledgeDescription = t.PledgeDescription
                }).ToListAsync();
                                           
                return Response.Success("Запрос выполнен успешно", activityDto);
            }
        }
    }
}
