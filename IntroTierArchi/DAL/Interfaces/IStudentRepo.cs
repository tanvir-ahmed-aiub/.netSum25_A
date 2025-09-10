using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IStudentRepo
    {
        bool Create(Student s);
        List<Student> Get();
        Student Get(int id);    
        bool Update(Student s);
        bool Delete(int id);
    }
}
