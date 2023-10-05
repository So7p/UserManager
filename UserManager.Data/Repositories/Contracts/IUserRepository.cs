using UserManager.Data.Entities;

namespace UserManager.Data.Repositories.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}