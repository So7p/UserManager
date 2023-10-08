using UserManager.Business.DTOs.RoleUser;

namespace UserManager.Business.Services.Contracts
{
    public interface IRoleUserService
    {
        Task<IEnumerable<RoleUserForViewDto>> GetAllAsync();
        Task<RoleUserForViewDto?> GetByIdAsync(int id);
        Task CreateAsync(RoleUserForCreationDto roleUserForCreationDto);
        Task UpdateAsync(RoleUserForUpdateDto roleUserForUpdateDto);
        Task DeleteAsync(int id);
    }
}