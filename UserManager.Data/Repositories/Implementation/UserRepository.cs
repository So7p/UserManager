using Microsoft.EntityFrameworkCore;
using UserManager.Data.Contexts.Contracts;
using UserManager.Data.Entities;
using UserManager.Data.Repositories.Contracts;

namespace UserManager.Data.Repositories.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<User>> GetAllAsync() =>
            await appContext.Set<User>()
            .AsNoTracking()
            .Include(u => u.Roles)
            .ToListAsync();

        public override async Task<User?> GetByIdAsync(int id) =>
            await appContext.Set<User>()
            .AsNoTracking()
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Id == id);

        public async Task<User?> GetByEmailAsync(string email) =>
            await appContext.Set<User>()
            .AsNoTracking()
            .Include(u => u.Roles)
            .FirstOrDefaultAsync(u => u.Email == email);
    }
}