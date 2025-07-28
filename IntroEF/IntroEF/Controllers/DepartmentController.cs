using AutoMapper;
using IntroEF.DTOs;
using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Sum25_AEntities db = new Sum25_AEntities();

        public static Mapper GetMapper() {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<DepartmentDTO, Department>().ReverseMap();
                cfg.CreateMap<Department, DepartmentStudentDTO>().ReverseMap();
                cfg.CreateMap<Student, StudentDTO>().ReverseMap();
            });
            var mapper = new Mapper(config);
            return mapper;
        }
        public ActionResult Index()
        {
            var list = db.Departments.ToList();
            

            var data = GetMapper().Map<List<DepartmentDTO>>(list);
            return View(data);
        }
        [HttpGet]
        public ActionResult Create() { 
            return View();
        }
        [HttpPost]
        public ActionResult Create(DepartmentDTO d) {

            var data = GetMapper().Map<Department>(d);
            db.Departments.Add(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id) {
            var data = db.Departments.Find(id);
            return View(data);
        }
        [HttpPost]
        public ActionResult Edit(Department d) {
            var exobj = db.Departments.Find(d.Id);
            exobj.Name = d.Name;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id) {
            var obj = (from d in db.Departments.Include("Students")
                      where d.Id == id
                      select d).SingleOrDefault();
            var data = GetMapper().Map<DepartmentStudentDTO>(obj);
            return View(data);
        }
    }

}