using Core.Entitys.Roles;

namespace Repository.Repositorys.Roles
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
