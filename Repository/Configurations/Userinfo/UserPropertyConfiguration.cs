using Core.Entitys.Userinfo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
namespace Repository.Configurations.Userinfo
{
    public class UserPropertyConfiguration : EntityConfiguration<UserProperty>
    {
        public override void Configure(EntityTypeBuilder<UserProperty> builder)
        {
            builder.ToTable("UserProperty");
            builder.HasKey(t => t.Id);
            builder.Property(a => a.FreezeMoney).HasColumnType("decimal(18, 2)");
            builder.Property(a => a.CashPledge).HasColumnType("decimal(18, 2)");
            builder.Property(a => a.TotalMoney).HasColumnType("decimal(18, 2)");
            builder.Property(a => a.Usable).HasColumnType("decimal(18, 2)");
            base.Configure(builder);
        }
    }
}
