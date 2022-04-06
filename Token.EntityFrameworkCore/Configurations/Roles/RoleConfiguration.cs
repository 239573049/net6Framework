using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Token.Core.Entitys.Roles;

namespace Token.EntityFrameworkCore.Configurations.Roles
{
    public class RoleConfiguration : EntityConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role");
            builder.HasKey(t => t.Id);
            base.Configure(builder);
        }
    }
}
