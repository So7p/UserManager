using UserManager.Business.DTOs.RoleUser;

namespace UserManager.Business.Services.Contracts
{
    public interface IRoleUserService
    {
        Task<IEnumerable<RoleUserForViewDto>> GetAllAsync();
        Task<RoleUserForViewDto?> GetByIdAsync(int id);
        Task<IEnumerable<RoleUserForViewDto>> GetByUserIdAsync(int userId);
        Task<IEnumerable<RoleUserForViewDto>> GetByUserNameAsync(string userName);
        Task<IEnumerable<RoleUserForViewDto>> GetByUserAgeAsync(int userAge);
        Task<IEnumerable<RoleUserForViewDto>> GetByUserEmailAsync(string userEmail);
        Task<IEnumerable<RoleUserForViewDto>> GetByUserRoleNameAsync(string userRoleName);
        Task CreateAsync(RoleUserForCreationDto roleUserForCreationDto);
        Task UpdateAsync(RoleUserForUpdateDto roleUserForUpdateDto);
        Task DeleteAsync(int id);
    }
}