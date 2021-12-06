using Core.Entitys.OrderForms;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configurations.OrderForms
{
    public class FormTypeConfiguration : EntityConfiguration<FormType>
    {
        public override void Configure(EntityTypeBuilder<FormType> builder)
        {
            builder.ToTable("FormType");
            builder.HasKey(t => t.Id);
            base.Configure(builder);
        }
    }
}
