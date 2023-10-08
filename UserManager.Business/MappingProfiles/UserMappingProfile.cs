using UserManager.Business.DTOs.User;
using UserManager.Data.Entities;

namespace UserManager.Business.MappingProfiles
{
    public class UserMappingProfile : AutoMapper.Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<User, UserForViewDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}