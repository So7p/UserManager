using UserManager.Business.DTOs.User;

namespace UserManager.Business.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<UserForViewDto>> GetAllAsync();
        Task<UserForViewDto?> GetByIdAsync(int id);
        Task<UserForViewDto?> GetByEmailAsync(string email);
        Task CreateAsync(UserForCreationDto userForCreationDto);
        Task UpdateAsync(UserForUpdateDto userForUpdateDto);
        Task DeleteAsync(int id);
    }
}