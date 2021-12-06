using Core.Entitys;
using Core.Entitys.OrderForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositorys.OrderForms
{
    public interface IAppealFailedsRepository : IMasterDbRepositoryBase<AppealFaileds>
    {
    }
    public class AppealFailedsRepository : MasterDbRepositoryBase<AppealFaileds>, IAppealFailedsRepository
    {
        public AppealFailedsRepository(MasterDbContext dbContext) : base(dbContext)
        {
        }
    }
}
