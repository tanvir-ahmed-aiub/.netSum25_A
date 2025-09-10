using DAL.EF.Tables;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class StudentRepoV2 : IStudentRepo
    {
        public bool Create(Student s)
        {
            throw new NotImplementedException();
        }

        public void CreateStudent(Student s) { }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Student> Get()
        {
            throw new NotImplementedException();
        }

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Student s)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent() { }

    }
}
