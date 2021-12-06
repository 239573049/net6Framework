using Core.Entitys.OrderForms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations.OrderForms
{
    public class CollectsConfiguration : EntityConfiguration<Collects>
    {
        public override void Configure(EntityTypeBuilder<Collects> builder)
        {
            builder.ToTable("Collects");
            builder.HasKey(t => t.Id);
            base.Configure(builder);
        }
    }
}
