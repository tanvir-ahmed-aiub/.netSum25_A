using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.EF.Tables;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class StudentService
    {
        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Student,StudentDTO>().ReverseMap();
            });
            return new Mapper(config);
        }
        public static List<StudentDTO> Get() {
            var data = DataAccessFactory.StudentData().Get();
            return GetMapper().Map<List<StudentDTO>>(data);
        }
        public static List<StudentDTO> GetSch() {
            var data = DataAccessFactory.StudentData().Get();
            var sch = (from s in data
                       where s.Id >= 1 && s.Id <= 10
                       select s).ToList();
            return GetMapper().Map<List<StudentDTO>>(sch); ;
        }
        public static bool Create(StudentDTO s) {
            var st = GetMapper().Map<Student>(s);
            return DataAccessFactory.StudentData().Create(st);
            
        }
        public static float GetCgpa(int id) { 
            var cgpa = DataAccessFactory.StudentFeature().CalculateCgpa(id);
            return cgpa;
        }
    }
}
