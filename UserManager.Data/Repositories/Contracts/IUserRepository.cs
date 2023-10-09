using UserManager.Data.Entities;

namespace UserManager.Data.Repositories.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<IEnumerable<User>> GetByUserNameAsync(string userName);
        Task<IEnumerable<User>> GetByAgeAsync(int age);
        Task<User?> GetByEmailAsync(string email); 
    }
}