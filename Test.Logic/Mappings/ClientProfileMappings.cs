using Agro.Okaps.Logic.Models;
using Agro.Shared.Data.Context;
using AutoMapper;

namespace Agro.Okaps.Logic.Mappings
{
    public class ClientProfileMappings : Profile
    {
        public ClientProfileMappings()
        {
            CreateMap<ClientProfile, ClientProfileInDto>();
            CreateMap<ClientProfileInDto, ClientProfile>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.UserId, opt => opt.Ignore());
        }
    }
}