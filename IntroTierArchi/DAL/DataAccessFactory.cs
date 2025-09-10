using DAL.EF.Tables;
using DAL.Interfaces;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Student, int, bool> StudentData() {
            return new StudentRepo();
        }
        public static IStudentFeature StudentFeature() {
            return new StudentRepo();
        }
        public static IRepo<Department, int, Department> DepartmentData() {
            return new DepartmentRepo();
        }
        public static IRepo<Course, int, bool> CourseData()
        {
            return new CourseRepo();
        }
    }
}
