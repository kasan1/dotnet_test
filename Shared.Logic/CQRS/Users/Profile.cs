using System.Threading;
using System.Threading.Tasks;
using Agro.Shared.Logic.CQRS.Users.DTOs;
using Agro.Shared.Logic.Models.Common;
using Agro.Shared.Logic.Services.System.Security;
using Agro.Shared.Logic.Services.System.User.Profile;
using AutoMapper;
using MediatR;

namespace Agro.Bpm.Logic.CQRS.Users
{
    public class Profile
    {
        public class Query : IRequest<Response<ProfileDto>>
        {
        }

        public class QueryHandler : IRequestHandler<Query, Response<ProfileDto>>
        {
            private readonly IUserProfileService _userProfileService;
            private readonly IUserAccessor _userAccessor;
            private readonly IMapper _mapper;

            public QueryHandler(IUserProfileService userProfileService, 
                IUserAccessor userAccessor,
                IMapper mapper)
            {
                _userProfileService = userProfileService;
                _userAccessor = userAccessor;
                _mapper = mapper;
            }

            public async Task<Response<ProfileDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var profile = await _userProfileService.Get(_userAccessor.GetCurrentUserId(), cancellationToken);

                return Response.Success("Профиль успешно загружен", _mapper.Map<ProfileDto>(profile));
            }
        }
    }
}
