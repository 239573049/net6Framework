using Core.Entitys.OrderForms;

namespace Repository.Repositorys.OrderForms
{
    public interface IAccessNumberFormRepository : IMasterDbRepositoryBase<AccessNumberForm>
    {
    }
    public class AccessNumberFormRepository : MasterDbRepositoryBase<AccessNumberForm>, IAccessNumberFormRepository
    {
        public AccessNumberFormRepository(MasterDbContext dbContext) : base(dbContext)
        {
        }
    }
}
