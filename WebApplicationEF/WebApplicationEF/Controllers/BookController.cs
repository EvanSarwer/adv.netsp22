using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationEF.Models.Database;

namespace WebApplicationEF.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            AdvWebEntities db = new AdvWebEntities();
            var data = db.Books.ToList();   // (from b  in db.Books where b.Author.Contains("Kazi") select b).ToList();
            return View(data);
        } 
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book b)
        {
            if (ModelState.IsValid)
            {
                //do the db insertion
                AdvWebEntities db = new AdvWebEntities();
                db.Books.Add(b);
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(b);
        }
    }
}