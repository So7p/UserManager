using Microsoft.EntityFrameworkCore;
using UserManager.Data.Contexts.Contracts;
using UserManager.Data.Entities;
using UserManager.Data.Repositories.Contracts;

namespace UserManager.Data.Repositories.Implementation
{
    public class RoleUserRepository : BaseRepository<RoleUser>, IRoleUserRepository
    {
        public RoleUserRepository(IApplicationDbContext appContext) : base(appContext) 
        { 
        }

        public override async Task<IEnumerable<RoleUser>> GetAllAsync() =>
            await appContext.Set<RoleUser>()
            .AsNoTracking()
            .Include(r => r.User)
            .Include(r => r.Role)
            .ToListAsync();

        public override async Task<RoleUser?> GetByIdAsync(int id) =>
            await appContext.Set<RoleUser>()
            .AsNoTracking()
            .Include(r => r.User)
            .Include(r => r.Role)
            .FirstOrDefaultAsync();
    }
}