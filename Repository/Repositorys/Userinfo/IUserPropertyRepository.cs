using Core.Entitys.Userinfo;

namespace Repository.Repositorys.Userinfo
{
    public interface IUserPropertyRepository : IMasterDbRepositoryBase<UserProperty>
    {
    }
    public class UserPropertyRepository : MasterDbRepositoryBase<UserProperty>, IUserPropertyRepository
    {
        public UserPropertyRepository(MasterDbContext dbContext) : base(dbContext)
        {
        }
    }
}
