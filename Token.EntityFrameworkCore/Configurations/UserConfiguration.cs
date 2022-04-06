using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Token.Core.Entitys;

namespace Token.EntityFrameworkCore.Configurations
{
    public class UserConfiguration:EntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(t => t.Id);
            base.Configure(builder);
        }
    }
}
