using Core.Base;
using Repository.Core;

namespace Repository.Repositorys
{
    public interface IMasterDbRepositoryBase<TEntity> : IRepository<MasterDbContext, TEntity, Guid> where TEntity : Entity<Guid>
    {
    }

    public interface IMasterDbRepositoryBase<TEntity, TKey> : IRepository<MasterDbContext, TEntity, TKey> where TEntity : Entity<TKey> { }
}
