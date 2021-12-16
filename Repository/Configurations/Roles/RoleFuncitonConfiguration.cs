using Core.Entitys.Roles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations.Roles
{
    public class RoleFuncitonConfiguration : EntityConfiguration<RoleFunction>
    {
        public override void Configure(EntityTypeBuilder<RoleFunction> builder)
        {
            builder.ToTable("RoleFunction");
            builder.HasKey(t => t.Id);
            base.Configure(builder);
        }
    }
}
