using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Token.Core.Entitys.Roles;

namespace Token.EntityFrameworkCore.Configurations.Roles
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
