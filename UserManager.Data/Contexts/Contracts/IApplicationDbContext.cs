using Microsoft.EntityFrameworkCore;
using UserManager.Data.Entities;

namespace UserManager.Data.Contexts.Contracts
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set;}
        DbSet<RoleUser> RoleUsers { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync();
    }
}