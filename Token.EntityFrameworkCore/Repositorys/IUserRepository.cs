using Token.Core.Entitys;

namespace Token.EntityFrameworkCore.Repositorys
{
    public interface IUserRepository: IMasterDbRepositoryBase<User>
    {
    }
    public class UserRepository : MasterDbRepositoryBase<User>, IUserRepository
    {
        public UserRepository(MasterDbContext dbContext) : base(dbContext)
        {
        }
    }
}
