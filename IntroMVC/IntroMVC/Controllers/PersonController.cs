using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntroMVC.Models;

namespace IntroMVC.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Home()
        {
            /*ViewBag.Name = "Sarwer";
            ViewBag.Id = 234;
            ViewData["Dob"] = DateTime.Now;*/

            Person p = new Person();
            p.Name = "Rahiim";
            p.Id = 123;
            p.Dob = DateTime.Now;

            return View(p);
        }
        public ActionResult List()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 100; i++)
            {
                var p = new Person
                {
                    Id = i + 1,
                    Name = "Person " + (i + 1),
                    Dob = DateTime.Now
                };
                persons.Add(p);
            }
            return View(persons);
        }
    }
}