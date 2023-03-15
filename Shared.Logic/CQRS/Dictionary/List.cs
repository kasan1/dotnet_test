using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Data.Context;
using Agro.Shared.Data.Context.Dictionary;
using Agro.Shared.Logic.Models.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Agro.Shared.Logic.Common.Exceptions;
using System.Net;
using Agro.Shared.Data.Entities.Dictionaries;
using Agro.Shared.Logic.CQRS.Dictionary.DTOs;
using Microsoft.AspNetCore.Identity;
using Agro.Shared.Data.Entities.Identity;

namespace Agro.Shared.Logic.CQRS.Dictionary
{
    public class List
    {
        public class Query : ListFilter, IRequest<Response<ListResponse>>
        { 
            public string Code { get; set; }
        }

        public class QueryHandler : IRequestHandler<Query, Response<ListResponse>>
        {
            private readonly DataContext _dataContext;
            private readonly RoleManager<AppRole> _roleManager;

            public QueryHandler(DataContext dataContext, RoleManager<AppRole> roleManager)
            {
                _dataContext = dataContext;
                _roleManager = roleManager;
            }

            public async Task<Response<ListResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
                var code = "dic" + request.Code.ToLower();
                var count = 0;
                var list = new List<DictionaryDto>();
                if (code == nameof(DicOwnershipForm).ToLower())
                {
                    var query = _dataContext.DicOwnershipForms.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Code = x.Code,
                              Name = x.GetName()
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == nameof(DicMariageStatus).ToLower())
                {
                    var query = _dataContext.DicMariageStatuses.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Code = x.Code,
                              Name = x.GetName()
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == nameof(DicOKED).ToLower())
                {
                    var query = _dataContext.DicOKED.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Code = x.Code,
                              Name = x.GetName()
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == nameof(DicOrganizationType).ToLower())
                {
                    var query = _dataContext.DicOrganizationTypes.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Code = x.Code,
                              Name = x.GetName()
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == nameof(DicOwnershipType).ToLower())
                {
                    var query = _dataContext.DicOwnershipTypes.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Code = x.Code,
                              Name = x.GetName()
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == nameof(DicLandType).ToLower())
                {
                    var query = _dataContext.DicLandTypes.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Code = x.Code,
                              Name = x.GetName()
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == nameof(DicLivestockType).ToLower())
                {
                    var query = _dataContext.DicLivestockTypes.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Code = x.Code,
                              Name = x.GetName(),
                              ParentId = x.ParentId
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == $"dic{nameof(FloraCulture)}".ToLower())
                {
                    var query = _dataContext.FloraCultures.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Name = x.Name,
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == $"{nameof(DicCountry)}".ToLower())
                {
                    var query = _dataContext.DicCountries.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Name = x.GetName(),
                              Code = x.Code
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == $"{nameof(DicRegion)}".ToLower())
                {
                    var query = _dataContext.DicRegions.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Name = x.GetName(),
                              Code = x.Code
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == $"{nameof(DicTaxTreatment)}".ToLower())
                {
                    var query = _dataContext.DicTaxTreatments.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Name = x.GetName(),
                              Code = x.Code
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == $"diclegalForm".ToLower())
                {
                    var query = _dataContext.DicOrganizationAndLegalForms.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Name = x.GetName(),
                              Code = x.Value == Data.Primitives.OrganizationAndLegalFormEnum.Juridical ? "1" : "0"
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == $"{nameof(DicSubjectOfEntrepreneur)}".ToLower())
                {
                    var query = _dataContext.DicSubjectOfEntrepreneur.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Name = x.GetName(),
                              Code = x.Code
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == $"{nameof(DicProvisionType)}".ToLower())
                {
                    var query = _dataContext.DicProvisionTypes.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Name = x.GetName(),
                              Code = x.Code
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == $"{nameof(DicProvisionDescription)}".ToLower())
                {
                    var query = _dataContext.DicProvisionDescription.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .OrderBy(x => x.Sort)
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Name = x.GetName(),
                              Code = x.Code
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == $"dic{nameof(Branch)}".ToLower())
                {
                    var query = _dataContext.Branches.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Name = x.NameRu,
                              Code = x.Code
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == $"{nameof(DicPosition)}".ToLower())
                {
                    var query = _dataContext.DicPositions.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Name = x.GetName(),
                              Code = x.Code
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == $"dicrole".ToLower())
                {
                    var query = _roleManager.Roles.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Name = x.NameRu,
                              Code = x.Name
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else if (code == nameof(DicCheckingListType).ToLower())
                {
                    var query = _dataContext.DicCheckingListTypes.AsQueryable();
                    list = await query
                          .AsNoTracking()
                          .Select(x => new DictionaryDto
                          {
                              Id = x.Id,
                              Name = x.NameRu,
                              Code = x.Code
                          })
                          .ToListAsync();

                    count = await query.CountAsync();
                }
                else
                    throw new RestException(HttpStatusCode.NotFound, "Справочник не найден");

                return Response.Success("Запрос выполнен успешно", new ListResponse
                {
                    List = list,
                    Count = count
                });
            }
        }
    }
}
