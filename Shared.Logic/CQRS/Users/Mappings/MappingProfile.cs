using Agro.Shared.Logic.CQRS.Files.DTOs;
using Agro.Shared.Logic.CQRS.Users.DTOs;
using Agro.Shared.Logic.Models.User.Identity;
using Agro.Shared.Logic.Models.User.Profile;

namespace Agro.Bpm.Logic.CQRS.Users.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthenticationResult, AuthResultDto>();

            CreateMap<UpdateProfile.Command, CreateProfileForm>();
            CreateMap<ProfileResult, ProfileDto>()
                .ForMember(d => d.Image, 
                opt => opt.MapFrom(s => new FileDto { Id = s.Image.Id, Filename = s.Image.Filename, Url = s.Image.Path }));
        }
    }
}
