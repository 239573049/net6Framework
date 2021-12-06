using Core.Entitys.OrderForms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations.OrderForms
{
    public class AppealFailedsConfiguration : EntityConfiguration<AppealFaileds>
    {
        public override void Configure(EntityTypeBuilder<AppealFaileds> builder)
        {
            builder.ToTable("AppealFaileds");
            builder.HasKey(t => t.Id);
            base.Configure(builder);
        }
    }
}
