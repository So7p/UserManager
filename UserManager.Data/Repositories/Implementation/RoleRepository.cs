using Microsoft.EntityFrameworkCore;
using UserManager.Data.Contexts.Contracts;
using UserManager.Data.Entities;
using UserManager.Data.Repositories.Contracts;

namespace UserManager.Data.Repositories.Implementation
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository
    {
        public RoleRepository(IApplicationDbContext appContext) : base(appContext)
        {
        }

        public override async Task<IEnumerable<Role>> GetAllAsync() =>
            await appContext.Set<Role>()
            .AsNoTracking()
            .Include(r => r.RoleUsers)
            .ToListAsync();

        public override async Task<Role?> GetByIdAsync(int id) =>
            await appContext.Set<Role>()
            .AsNoTracking()
            .Include(r => r.RoleUsers)
            .FirstOrDefaultAsync(r => r.Id == id);

        public async Task<Role?> GetByRoleNameAsync(string roleName) =>
            await appContext.Set<Role>()
            .AsNoTracking()
            .Include(r => r.RoleUsers)
            .FirstOrDefaultAsync(r => r.RoleName == roleName);
    }
}