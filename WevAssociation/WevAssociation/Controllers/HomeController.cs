using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WevAssociation.Auth;
using WevAssociation.Models.Database;
using WevAssociation.Models.Entities;

namespace WevAssociation.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        //[AllowAnonymous]
        public ActionResult Index()
        {
            
            AdvWeb1Entities db = new AdvWeb1Entities();
            var dept = (from d in db.Departments where d.Id == 1 select d).FirstOrDefault();
            DepartmentModel de = new DepartmentModel();
            de.Name = dept.Name;
            de.Id = dept.Id;
            return View(dept);   
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Login(User user)
        {
            AdvWeb1Entities db = new AdvWeb1Entities();
            var data = (from u in db.Users 
                        where u.Password.Equals(user.Password) && 
                        u.Username.Equals(user.Username) 
                        select u).FirstOrDefault();
            if(data != null)
            {
                FormsAuthentication.SetAuthCookie(data.Username,false);
                Session["role"]= data.Role;
                return RedirectToAction("Index");
            }

            TempData["msg"] = "Invalid Credentials";
            return RedirectToAction("Login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        [AdminAccess]
        public ActionResult Userlist()
        {
            AdvWeb1Entities db = new AdvWeb1Entities();
            return View(db.Users.ToList());

        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}