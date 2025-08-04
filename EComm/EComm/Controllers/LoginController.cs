using EComm.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EComm.Controllers
{
    public class LoginController : Controller
    {
        EComm_Sum25_AEntities db = new EComm_Sum25_AEntities();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string username, string password, string ReturnUrl) {
            password = GetMd5Hash(password);
            var user = (from u in db.Users
                        where u.Username.Equals(username) &&
                        u.Password.Equals(password)
                        select u).SingleOrDefault();
            if (user != null && user.Type.Equals("Customer")) {
                user.Password = null;
                Session["User"] = user;
                if (ReturnUrl != null) {
                    return RedirectToAction("ShowCart", "Order");
                }
                return RedirectToAction("Index","Customer");
            }
            TempData["Msg"] = "Username Password Invalid";
            TempData["Class"] = "danger";
            
            return View();
        }

        static string GetMd5Hash(string input)
        {
            // Create MD5 instance
            using (MD5 md5 = MD5.Create())
            {
                // Convert input string to byte array
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                // Compute the MD5 hash
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (var b in hashBytes)
                    sb.Append(b.ToString("x2"));  // x2 = lowercase hex format

                return sb.ToString();
            }
        }
    }


}