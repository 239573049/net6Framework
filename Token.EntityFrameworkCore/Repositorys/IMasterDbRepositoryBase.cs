using Token.Core.Base;
using Token.EntityFrameworkCore.Core;

namespace Token.EntityFrameworkCore.Repositorys
{
    public interface IMasterDbRepositoryBase<TEntity> : IRepository<MasterDbContext, TEntity, Guid> where TEntity : Entity<Guid>
    {
    }

    public interface IMasterDbRepositoryBase<TEntity, TKey> : IRepository<MasterDbContext, TEntity, TKey> where TEntity : Entity<TKey> { }
}
