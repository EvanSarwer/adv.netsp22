using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationEF.Models.Database;

namespace WebApplicationEF.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            AdvWebEntities db = new AdvWebEntities();
            var data = db.News.ToList();
            return View(data);
        }
        [HttpGet]
        public ActionResult Create()
        {

            return View(new News());
        }
        [HttpPost]
        public ActionResult Create(News n)
        {
            if (ModelState.IsValid)
            {
                AdvWebEntities db = new AdvWebEntities();
                n.PublishDate = DateTime.Now;
                db.News.Add(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            AdvWebEntities db = new AdvWebEntities();
            var news = (from n in db.News where n.Id == id select n).FirstOrDefault();
            return View(news);
        }
        [HttpPost]
        public ActionResult Edit(News n)
        {
            if (ModelState.IsValid)
            {
                AdvWebEntities db = new AdvWebEntities();
                n.PublishDate = DateTime.Now;
                var news = (from i in db.News where i.Id == n.Id select i).FirstOrDefault();
                db.Entry(news).CurrentValues.SetValues(n);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }
        public ActionResult Delete(int id)
        {
            AdvWebEntities db = new AdvWebEntities();
            var news = (from n in db.News where n.Id == id select n).FirstOrDefault();
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}