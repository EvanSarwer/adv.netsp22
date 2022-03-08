using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntroMVC.Models;
using System.Data.SqlClient;

namespace IntroMVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Create()
        {
            return View(new Student());
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if (ModelState.IsValid)
            {
                String connString = "";
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                string query = "";
                SqlCommand cmd = new SqlCommand(query,conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                //database operation
                return RedirectToAction("List", "Person");

                /*return RedirectToAction("Submit");*/   //same controller er method e pass korle
            }
            return View(s);
        }
        [HttpPost]
        public ActionResult Submit(Student s)
        {
            /*Student s = new Student();
            s.Name = Request["Name"];
            s.Id = Request["Id"];
            s.Dob = Request["Dob"];
            s.Email = Request["Email"];
            s.Password = Request["Password"];*/

            /*Student s = new Student();
            s.Name = form["Name"];
            s.Id = form["Id"];                   //Submit(FormCollection form) use kore
            s.Dob = form["Dob"];
            s.Email = form["Email"];
            s.Password = form["Password"];*/

            /*Student s = new Student();
            s.Name = Name;
            s.Id = Id;                          //Submit(string Name, string Id, string Dob, string Email, string Password)
            s.Dob = Dob;
            s.Email = Email;
            s.Password = Password;*/


            return View(s); 
        }

    }
}