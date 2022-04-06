using Token.Core.Entitys.Roles;

namespace Token.EntityFrameworkCore.Repositorys.Roles
{
    public interface IRoleFunctionRepository : IMasterDbRepositoryBase<RoleFunction>
    {
    }
    public class RoleFunctionRepository : MasterDbRepositoryBase<RoleFunction>, IRoleFunctionRepository
    {
        public RoleFunctionRepository(MasterDbContext dbContext) : base(dbContext)
        {
        }
    }
}
