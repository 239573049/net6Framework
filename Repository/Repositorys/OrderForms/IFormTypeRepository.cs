using Core.Entitys.OrderForms;

namespace Repository.Repositorys.OrderForms
{

    public interface IFormTypeRepository : IMasterDbRepositoryBase<FormType>
    {
    }
    public class FormTypeRepository : MasterDbRepositoryBase<FormType>, IFormTypeRepository
    {
        public FormTypeRepository(MasterDbContext dbContext) : base(dbContext)
        {
        }
    }
}
