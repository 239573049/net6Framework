using Core.Entitys;
using Core.Entitys.OrderForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorys.OrderForms
{
    public interface ICollectsRepository : IMasterDbRepositoryBase<Collects>
    {
    }
    public class CollectsRepository : MasterDbRepositoryBase<Collects>, ICollectsRepository
    {
        public CollectsRepository(MasterDbContext dbContext) : base(dbContext)
        {
        }
    }
}
