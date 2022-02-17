using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IntroMVC.Models;

namespace IntroMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Home()
        {
            /*ViewBag.Name = "Pen";
            ViewBag.Id = 321;
            ViewData["Price"] = 350;*/

            Product p = new Product();
            p.Name = "Shirt";
            p.Id = 432;
            p.Price = 750.60;

            return View(p);
        }
        public ActionResult List()
        {
            /*string[] names = { "Shirt", "Pen", "Paper", "Watch" };
            ViewBag.Names = names;*/

            List<Product> products = new List<Product>();
            for (int i = 0; i < 10; i++)
            {
                Product p = new Product
                {
                    Name = "Product " + (i + 1),
                    Id = (i + 1),
                    Price = (i + 500) / 6,
                };
                products.Add(p);
            }

            return View(products);
        }

    }
}