using UserManager.Business.DTOs.Role;
using UserManager.Data.Entities;

namespace UserManager.Business.MappingProfiles
{
    public class RoleMappingProfile : AutoMapper.Profile
    {
        public RoleMappingProfile() 
        {
            CreateMap<Role, RoleForViewDto>();
            CreateMap<RoleForCreationDto, Role>();
            CreateMap<RoleForUpdateDto, Role>();
        }
    }
}