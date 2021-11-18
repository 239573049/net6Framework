using Core.Entitys;

namespace Repository.Repositorys
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
