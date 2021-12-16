using Core.Entitys.Roles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations.Roles
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
