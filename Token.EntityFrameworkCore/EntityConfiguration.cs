using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Token.Core.Base;

namespace Token.EntityFrameworkCore
{
    public abstract class EntityConfiguration<T> : IEntityTypeConfiguration<T> where T : Entity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(m => m.Id);
        }
    }
}
