using IntroMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace IntroMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            ViewBag.MTitle = "Student List";
            Student s1 = new Student() { 
                Id = 1,
                Name = "S1",
                Address= "Dhaka",
                Email = "m.a@gmail.com"

            };
            Student s2 = new Student()
            {
                Id = 2,
                Name = "S2",
                Address = "Dhaka",
                Email = "m.a@gmail.com"

            };
            List<Student> students = new List<Student>();
            students.Add(s1);
            students.Add(s2);

            return View(students);
        }
        public ActionResult Create() {
            ViewBag.MTitle = "Create Student";
            return View();
            //return Redirect("https://www.aiub.edu");
            //TempData["Msg"] = "Redirected From Student";
            //return RedirectToAction("Index","home");
        }
        
    }
}