using UserManager.Business.DTOs.Role;

namespace UserManager.Business.Services.Contracts
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleForViewDto>> GetAllAsync();
        Task<RoleForViewDto?> GetByIdAsync(int id);
        Task CreateAsync(RoleForCreationDto roleForCreationDto);
        Task UpdateAsync(RoleForUpdateDto roleForUpdateDto);
        Task DeleteAsync(int id);
    }
}