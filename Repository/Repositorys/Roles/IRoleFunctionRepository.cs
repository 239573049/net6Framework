using Core.Entitys.Roles;

namespace Repository.Repositorys.Roles
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
