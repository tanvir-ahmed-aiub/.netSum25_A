using Form_Submission.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Form_Submission.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create() {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Create(Student student) {
            if (ModelState.IsValid) //model validation
            {
                return RedirectToAction("Contact","Home");
            }
            return View(student);
        }
        //public ActionResult Create(string Name, string Id, string Email) {
        //    ViewBag.Name = Name;
        //    ViewBag.Id = Id;
        //    ViewBag.Email = Email;
        //    return View();
        //}
        //public ActionResult Create(FormCollection fc)
        //{
        //    ViewBag.Name = fc["Name"];
        //    ViewBag.Id = fc["Id"];
        //    ViewBag.Email = fc["Email"];
        //    return View();
        //}
    }
}