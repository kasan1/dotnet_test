using Agro.Shared.Logic.Models.User.Identity;
using Agro.Shared.Logic.Models.User.Profile;

namespace Agro.Okaps.Logic.CQRS.Users.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Register.Command, UserRegisterForm>()
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.Roles, opt => opt.Ignore());

            CreateMap<Register.Command, CreateProfileForm>()
                .ForMember(d => d.Phone, opt => opt.MapFrom(s => s.PhoneNumber))
                .ForMember(d => d.Image, opt => opt.Ignore())
                .ForMember(d => d.CertificateStartDate, opt => opt.MapFrom(s => s.CertificateDateFrom))
                .ForMember(d => d.CertificateEndDate, opt => opt.MapFrom(s => s.CertificateDateTo));
        }
    }
}
