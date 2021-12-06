using Core.Entitys.Userinfo;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations.Userinfo
{
    public class FreezeDetailConfigration : EntityConfiguration<FreezeDetail>
    {
        public override void Configure(EntityTypeBuilder<FreezeDetail> builder)
        {
            builder.ToTable("FreezeDetail");
            builder.HasKey(t => t.Id);
            builder.Property(a => a.Money).HasColumnType("decimal(18, 2)");
            base.Configure(builder);
        }
    }
}
