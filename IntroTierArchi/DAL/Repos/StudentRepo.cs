using DAL.EF;
using DAL.EF.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class StudentRepo
    {
        UMSContext db;
        public StudentRepo() {
            db = new UMSContext();
        }
        public bool Create(Student s) {
            db.Students.Add(s);
            return db.SaveChanges()>0;
        }
        public List<Student> Get() {
            return db.Students.ToList();
        }
        public Student Get(int id) {
            return db.Students.Find(id);
        }
        public bool Update(Student s) {
            var exobj = Get(s.Id);
            db.Entry(exobj).CurrentValues.SetValues(s);
            return db.SaveChanges()>0;
        }
        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Students.Remove(exobj);
            return db.SaveChanges() > 0;
        }
    }
}
