using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Token.Core.Entitys.Roles;

namespace Token.EntityFrameworkCore.Configurations.Roles
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
