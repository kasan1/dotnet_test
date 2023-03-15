using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Agro.Shared.Logic.Common.Exceptions;
using System.Net;
using System;
using Agro.Shared.Data.Context.LoanApplications.Activity;
using Agro.Shared.Data.Primitives;
using Agro.Shared.Logic.CQRS.ClientActivities.DTOs;

namespace Agro.Shared.Logic.CQRS.ClientActivities
{
    public class Create
    {
        public class CreateActivityCommand : ActivityDto, IRequest<Response<Unit>>
        {
            public Guid LoanApplicationId { get; set; }
        }

        public class CreateCommandHandler : IRequestHandler<CreateActivityCommand, Response<Unit>>
        {
            private readonly Data.Context.DataContext _dataContext;
            private List<DicLandType> _dicLandTypes;
            private List<DicOwnershipType> _dicOwnershipTypes;
            private List<DicLivestockType> _dicLivestockTypes;
            private List<Data.Context.FloraCulture> _dicFloraCultures;

            public CreateCommandHandler(Data.Context.DataContext dataContext)
            {
                _dataContext = dataContext;
            }

            public async Task<Response<Unit>> Handle(CreateActivityCommand request, CancellationToken cancellationToken)
            {
                var application = await _dataContext.LoanApplications.FirstOrDefaultAsync(x => !x.IsDeleted && x.Id == request.LoanApplicationId);
                if (application == null)
                    throw new RestException(HttpStatusCode.NotFound, "Заявка не найдена");

                if (application.Status != ApplicationTypeEnum.Temp)
                    throw new RestException(HttpStatusCode.BadRequest, "Заявка уже в работе, вы не можете вносить изменения");

                _dicLandTypes = await _dataContext.DicLandTypes.ToListAsync();
                _dicOwnershipTypes = await _dataContext.DicOwnershipTypes.ToListAsync();
                _dicLivestockTypes = await _dataContext.DicLivestockTypes.ToListAsync();
                _dicFloraCultures = await _dataContext.FloraCultures.ToListAsync();
                                
                Activity activity = null;
                List<LandActivity> landActivities = null;
                List<FloraActivity> floraActivities = null;
                List<LivestockActivity> livestockActivities = null;
                List<TechnicActivity> technicActivities = null;

                if (request.Id.HasValue)
                {
                    activity = await _dataContext.Activities.FirstOrDefaultAsync(x => x.Id == request.Id);

                    landActivities = await _dataContext.LandActivity.Where(x => x.ActivityId == request.Id).ToListAsync();
                    floraActivities = await _dataContext.FloraActivity
                        .Include(xx => xx.Productivities)
                        .Where(x => x.ActivityId == request.Id).ToListAsync();
                    livestockActivities = await _dataContext.LivestockActivity.Where(x => x.ActivityId == request.Id).ToListAsync();
                    technicActivities = await _dataContext.TechnicActivity.Where(x => x.ActivityId == request.Id).ToListAsync();
                }

                if (activity != null)
                {
                    var deleteLandActivities = landActivities.Where(x => !request.LandActivities?.Any(xx => xx.Id == x.Id) ?? true).ToList();
                    if (deleteLandActivities.Any())
                        _dataContext.LandActivity.RemoveRange(deleteLandActivities);
                    
                    var deleteFloraActivities = floraActivities.Where(x => !request.FloraActivities?.Any(xx => xx.Id == x.Id) ?? true).ToList();
                    if (deleteFloraActivities.Any())
                        _dataContext.FloraActivity.RemoveRange(deleteFloraActivities);

                    var deleteLivestockActivities = livestockActivities.Where(x => !request.LivestockActivities?.Any(xx => xx.Id == x.Id) ?? true).ToList();
                    if (deleteLivestockActivities.Any())
                        _dataContext.LivestockActivity.RemoveRange(deleteLivestockActivities);

                    var deleteTechnicActivities = technicActivities.Where(x => !request.TechnicActivities?.Any(xx => xx.Id == x.Id) ?? true).ToList();
                    if (deleteTechnicActivities.Any())
                        _dataContext.TechnicActivity.RemoveRange(deleteTechnicActivities);
                    
                }
                else
                {
                    activity = new Activity
                    {
                        Id = Guid.NewGuid(),
                        LoanApplicationId = application.Id
                    };
                    await _dataContext.Activities.AddAsync(activity);
                }

                if (request.LandActivities?.Any() ?? false)
                    foreach (var landActivityDto in request.LandActivities)
                        await CreateLandActivity(activity.Id, landActivities, landActivityDto);


                if (request.FloraActivities?.Any() ?? false)
                    foreach (var floraActivityDto in request.FloraActivities)
                        await CreateFloraActivity(activity.Id, floraActivities, floraActivityDto);

                if (request.LivestockActivities?.Any() ?? false)
                    foreach (var livestockActivityDto in request.LivestockActivities)
                        await CreateLivestockActivity(activity.Id, livestockActivities, livestockActivityDto);

                if (request.TechnicActivities?.Any() ?? false)
                    foreach (var technicActivityDto in request.TechnicActivities)
                        await CreateTechnicActivity(activity.Id, technicActivities, technicActivityDto);

                await _dataContext.SaveChangesAsync();
                
                return Response.Success("Запрос выполнен успешно", Unit.Value);
            }

            #region land
            public async Task<Guid> CreateLandActivity(Guid activityId, List<LandActivity> landActivities, LandActivityDto landActivityDto)
            {
                if (!_dicLandTypes.Any(x => x.Id == landActivityDto.LandTypeId))
                    throw new RestException(HttpStatusCode.NotFound, "Справочник тип земельного актива не найден");

                if (!_dicOwnershipTypes.Any(x => x.Id == landActivityDto.OwnershipTypeId))
                    throw new RestException(HttpStatusCode.NotFound, "Справочник тип собственности не найден");

                LandActivity landActivity = null;
                if (landActivityDto.Id.HasValue)
                {
                    landActivity = landActivities?.FirstOrDefault(x => x.Id == landActivityDto.Id);
                    if (landActivity != null)
                        SetLandActivityProps(landActivity, landActivityDto);
                }

                if (landActivity == null)
                {
                    landActivity = SetLandActivityProps(new LandActivity
                    {
                        Id = Guid.NewGuid(),
                        ActivityId = activityId,
                    }, landActivityDto);
                    await _dataContext.LandActivity.AddAsync(landActivity);
                }

                return landActivity.Id;
            }

            private LandActivity SetLandActivityProps(LandActivity mdb, LandActivityDto dto)
            {
                mdb.LandTypeId = dto.LandTypeId;
                mdb.OwnershipTypeId = dto.OwnershipTypeId;
                mdb.Square = dto.Square;
                return mdb;
            }
            #endregion

            #region flora
            public async Task<Guid> CreateFloraActivity(Guid activityId, List<FloraActivity> floraActivities, FloraActivityDto floraActivityDto)
            {
                if (!_dicFloraCultures.Any(x => x.Id == floraActivityDto.CultureId))
                    throw new RestException(HttpStatusCode.NotFound, "Справочник культуры не найден");

                FloraActivity floraActivity = null;
                if (floraActivityDto.Id.HasValue)
                {
                    floraActivity = floraActivities?.FirstOrDefault(x => x.Id == floraActivityDto.Id);
                    if (floraActivity != null)
                        SetFloraActivityProps(floraActivity, floraActivityDto);
                }

                if (floraActivity == null)
                {
                    floraActivity = SetFloraActivityProps(new FloraActivity
                    {
                        Id = Guid.NewGuid(),
                        ActivityId = activityId
                    }, floraActivityDto);
                    await _dataContext.FloraActivity.AddAsync(floraActivity);

                }

                SetFloraProductivity(floraActivity, DateTime.Now.Year, floraActivityDto.ProductivityCurrentYear);
                SetFloraProductivity(floraActivity, DateTime.Now.Year-1, floraActivityDto.ProductivityLastYear);
                SetFloraProductivity(floraActivity, DateTime.Now.Year - 2, floraActivityDto.ProductivityBeforeLastYear);

                return floraActivity.Id;
            }

            private FloraActivity SetFloraActivityProps(FloraActivity mdb, FloraActivityDto dto)
            {
                mdb.Cost = dto.Cost;
                mdb.FloraCultureId = dto.CultureId;
                mdb.PriceRealization = dto.PriceRealization;
                mdb.PlannedSquare = dto.PlannedSquare;
                mdb.SeedingRate = dto.SeedingRate;
                return mdb;
            }

            public async void SetFloraProductivity(FloraActivity floraActivity, int year, decimal? value)
            {
                var current = floraActivity.Productivities?.FirstOrDefault(x => x.Year == year);
                if (current == null)
                {
                    await _dataContext.FloraProductivity.AddAsync(new FloraProductivity
                    {
                        Id = Guid.NewGuid(),
                        FloraActivityId = floraActivity.Id,
                        Value = value,
                        Year = year
                    });
                }
                else
                    current.Value = value;
            }
            #endregion

            #region livstock
            public async Task<Guid> CreateLivestockActivity(Guid activityId, List<LivestockActivity> livestockActivities, LivestockActivityDto livestockActivityDto)
            {
                if (!_dicLivestockTypes.Any(x => x.Id == livestockActivityDto.LivestockTypeId && x.ParentId.HasValue))
                    throw new RestException(HttpStatusCode.NotFound, "Справочник вид скота не найден");

                LivestockActivity livestockActivity = null;

                if (livestockActivityDto.Id.HasValue)
                {
                    livestockActivity = livestockActivities?.FirstOrDefault(x => x.Id == livestockActivityDto.Id);
                    if (livestockActivity != null)
                        SetLivestockActivityProps(livestockActivity, livestockActivityDto);
                }

                if (livestockActivity == null)
                {
                    livestockActivity = SetLivestockActivityProps(new LivestockActivity
                    {
                        Id = Guid.NewGuid(),
                        ActivityId = activityId
                    }, livestockActivityDto);

                    await _dataContext.LivestockActivity.AddAsync(livestockActivity);
                }

                return livestockActivity.Id;
            }
            private LivestockActivity SetLivestockActivityProps(LivestockActivity mdb, LivestockActivityDto dto)
            {
                mdb.LivestockTypeId = dto.LivestockTypeId;
                mdb.Count = dto.Count;
                mdb.LiveWeight = dto.LiveWeight;
                mdb.SlaughterWeight = dto.SlaughterWeight;
                mdb.LivePrice = dto.LivePrice;
                mdb.SlaughterPrice = dto.SlaughterPrice;
                return mdb;
            }
            #endregion

            #region technic
            public async Task<Guid> CreateTechnicActivity(Guid activityId, List<TechnicActivity> technicActivities, TechnicActivityDto technicActivityDto)
            {
                TechnicActivity technicActivity = null;

                if (technicActivityDto.Id.HasValue)
                {
                    technicActivity = technicActivities.FirstOrDefault(x => x.Id == technicActivityDto.Id);
                    if (technicActivity != null)
                        SetTechnicActivityProps(technicActivity, technicActivityDto);
                }

                if (technicActivity == null)
                {
                    technicActivity = SetTechnicActivityProps(new TechnicActivity
                    {
                        Id = Guid.NewGuid(),
                        ActivityId = activityId
                    }, technicActivityDto);

                    await _dataContext.TechnicActivity.AddAsync(technicActivity);
                }
                return technicActivity.Id;
            }

            private TechnicActivity SetTechnicActivityProps(TechnicActivity mdb, TechnicActivityDto dto)
            {
                mdb.Count = dto.Count;
                mdb.CountOfCorrect = dto.CountOfCorrect;
                mdb.DateIssue = dto.DateIssue;
                mdb.IsPledged = dto.IsPledged;
                mdb.PledgeDescription = dto.PledgeDescription ?? "";
                mdb.Fullname = dto.Fullname;
                return mdb;
            }

            #endregion
        }
    }
}
