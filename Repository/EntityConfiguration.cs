using Core.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}
