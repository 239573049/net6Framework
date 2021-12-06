using Core.Entitys.OrderForms;

namespace Repository.Repositorys.OrderForms
{
    public interface IUserFormsRepository : IMasterDbRepositoryBase<UserForms>
    {
    }
    public class UserFormsRepository : MasterDbRepositoryBase<UserForms>, IUserFormsRepository
    {
        public UserFormsRepository(MasterDbContext dbContext) : base(dbContext)
        {
        }
    }
}
