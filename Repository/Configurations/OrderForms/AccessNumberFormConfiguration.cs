using Core.Entitys.OrderForms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations.OrderForms
{
    public class AccessNumberFormConfiguration : EntityConfiguration<AccessNumberForm>
    {
        public override void Configure(EntityTypeBuilder<AccessNumberForm> builder)
        {
            builder.ToTable("AccessNumberForm");
            builder.HasKey(t => t.Id);
            base.Configure(builder);
        }
    }
}
