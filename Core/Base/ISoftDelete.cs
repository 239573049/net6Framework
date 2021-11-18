using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Base
{
    public interface ISoftDelete: IHaveDeleteTime
    {
        bool IsDeleted { get; set; }
    }

    public interface IHaveDeleteTime
    {
        DateTime? DeletedTime { get; set; }
    }
}
