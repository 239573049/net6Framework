using MongoDBCore.Base;

namespace MongoDBRepository.Repositorys;

public interface IMasterDbRepositoryBase<TEntity> : IRepository<MongoDBContext, TEntity> where TEntity : Entity
{
}
public class MasterDbRepositoryBase<TEntity> : Repository<MongoDBContext, TEntity>, IMasterDbRepositoryBase<TEntity> where TEntity : Entity
{
    public MasterDbRepositoryBase(MongoDBContext context) : base(context)
    {
    }
}