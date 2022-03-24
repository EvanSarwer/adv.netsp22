using BLL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation_MVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index(int id)
        {
            var stu = StudentService.Get(id);


            return View();
        }
    }
}