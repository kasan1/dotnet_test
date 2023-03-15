using Agro.Shared.Logic.Models.User.Identity;
using Agro.Shared.Logic.Models.User.Profile;

namespace Agro.Bpm.Logic.CQRS.Users.Mappings
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<Register.Command, UserRegisterForm>()
                .ForMember(d => d.Username, opt => opt.MapFrom(s => s.Identifier))
                .ForMember(d => d.PhoneNumber, opt => opt.Ignore())
                .ForMember(d => d.UserAudienceType, opt => opt.Ignore())
                .ForMember(d => d.EssenceType, opt => opt.Ignore())
                .ForMember(d => d.AgreementId, opt => opt.Ignore());

            CreateMap<Register.Command, CreateProfileForm>()
                .ForMember(d => d.Phone, opt => opt.Ignore())
                .ForMember(d => d.Image, opt => opt.Ignore())
                .ForMember(d => d.BirthDate, opt => opt.Ignore())
                .ForMember(d => d.CertificateStartDate, opt => opt.Ignore())
                .ForMember(d => d.CertificateEndDate, opt => opt.Ignore());
        }
    }
}
