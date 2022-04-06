using Token.Core.Entitys.Roles;

namespace Token.EntityFrameworkCore.Repositorys.Roles
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
