using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.Data.Entities;

namespace UserManager.Data.Configurations
{
    public class RoleUserConfiguration : IEntityTypeConfiguration<RoleUser>
    {
        public void Configure(EntityTypeBuilder<RoleUser> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id).UseIdentityColumn(1, 1).ValueGeneratedOnAdd();

            builder.Property(r => r.UserId).IsRequired();
            builder.Property(r => r.RoleId).IsRequired();
        }
    }
}