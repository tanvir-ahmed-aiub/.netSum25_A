using IntroEF.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IntroEF.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        Sum25_AEntities db = new Sum25_AEntities();
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create() { 
            return View();
        }
        public ActionResult Create(Student s) { 
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id) {
            var data = db.Students.Find(id); //searches with PK
            return View(data);
        }
    }
}