using Core.Entitys.Userinfo;

namespace Repository.Repositorys.Userinfo
{
    public interface IFreezeDetailRepository : IMasterDbRepositoryBase<FreezeDetail>
    {
    }
    public class FreezeDetailRepository : MasterDbRepositoryBase<FreezeDetail>, IFreezeDetailRepository
    {
        public FreezeDetailRepository(MasterDbContext dbContext) : base(dbContext)
        {
        }
    }
}
