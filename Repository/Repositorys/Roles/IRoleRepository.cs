using Core.Entitys.Roles;

namespace Repository.Repositorys.Roles
{
    public interface IRoleRepository : IMasterDbRepositoryBase<Role>
    {
    }
    public class RoleRepository : MasterDbRepositoryBase<Role>, IRoleRepository
    {
        public RoleRepository(MasterDbContext dbContext) : base(dbContext)
        {
        }
    }
}
