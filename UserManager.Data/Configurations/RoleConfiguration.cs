using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.Data.Entities;

namespace UserManager.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(r => r.RoleName).IsRequired();
            builder.HasIndex(r => r.RoleName).IsUnique();
        }
    }
}