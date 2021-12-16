using Core.Entitys.Roles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations.Roles
{
    public class UserRoleConfiguration : EntityConfiguration<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable("UserRole");
            builder.HasKey(t => t.Id);
            base.Configure(builder);
        }
    }
}
