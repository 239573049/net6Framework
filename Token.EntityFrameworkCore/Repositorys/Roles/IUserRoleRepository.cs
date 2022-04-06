using Token.Core.Entitys.Roles;

namespace Token.EntityFrameworkCore.Repositorys.Roles
{
    public interface IUserRoleRepository : IMasterDbRepositoryBase<UserRole>
    {
    }
    public class UserRoleRepository : MasterDbRepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(MasterDbContext dbContext) : base(dbContext)
        {
        }
    }
}
