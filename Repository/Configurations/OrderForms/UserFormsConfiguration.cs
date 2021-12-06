using Core.Entitys.OrderForms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations.OrderForms
{
    public class UserFormsConfiguration : EntityConfiguration<UserForms>
    {
        public override void Configure(EntityTypeBuilder<UserForms> builder)
        {
            builder.ToTable("UserForms");
            builder.HasKey(t => t.Id);
            builder.Property(a=>a.Price).HasColumnType("decimal(18, 2)");
            builder.Property(a => a.OriginalPrice).HasColumnType("decimal(18,2)");
            base.Configure(builder);
        }
    }
}
