using Core.Base;
using Repository.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorys
{
    public interface IMasterDbRepositoryBase<TEntity> : IRepository<MasterDbContext, TEntity, Guid> where TEntity : Entity<Guid>
    {
    }

    public interface IMasterDbRepositoryBase<TEntity, TKey> : IRepository<MasterDbContext, TEntity, TKey> where TEntity : Entity<TKey> { }
}
