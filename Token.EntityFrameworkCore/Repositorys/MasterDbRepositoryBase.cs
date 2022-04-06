using Token.Core.Base;
using Token.EntityFrameworkCore.Core;

namespace Token.EntityFrameworkCore.Repositorys
{
    public class MasterDbRepositoryBase<TEntity> : EfRepository<MasterDbContext, TEntity, Guid>, IMasterDbRepositoryBase<TEntity, Guid> where TEntity : Entity<Guid>
    {
        public MasterDbRepositoryBase(MasterDbContext dbContext)
            : base(dbContext)
        {

        }
    }
    public class MasterDbRepositoryBase<TEntity, TKey> : EfRepository<MasterDbContext, TEntity, TKey>, IMasterDbRepositoryBase<TEntity, TKey> where TEntity : Entity<TKey>
    {
        public MasterDbRepositoryBase(MasterDbContext dbContext)
            : base(dbContext)
        {

        }
    }
}
