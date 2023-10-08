using UserManager.Business.DTOs.RoleUser;
using UserManager.Data.Entities;

namespace UserManager.Business.MappingProfiles
{
    public class RoleUserMappingProfile : AutoMapper.Profile
    {
        public RoleUserMappingProfile() 
        {
            CreateMap<RoleUser, RoleUserForViewDto>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name))
                .ForMember(dest => dest.UserAge, opt => opt.MapFrom(src => src.User.Age))
                .ForMember(dest => dest.UserEmail, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.UserRoleName, opt => opt.MapFrom(src => src.Role.RoleName));

            CreateMap<RoleUserForCreationDto, RoleUser>();
            CreateMap<RoleUserForUpdateDto, RoleUser>();
        }
    }
}