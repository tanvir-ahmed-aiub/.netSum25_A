using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public interface IRepo<CLASS,PK,RET>
    {
        List<CLASS> Get();
        CLASS Get(PK id);
        RET Create(CLASS obj);
        RET Update(CLASS obj);
        bool Delete(PK id);
        
    }
}
