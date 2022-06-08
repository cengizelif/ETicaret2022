using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret2022.Models;

namespace ETicaret2022.Controllers
{
    public class HomeController : Controller
    {
        ETicaret2022Entities db = new ETicaret2022Entities();
        public ActionResult Index()
        {
            ViewBag.Kategoriler = db.Kategori.ToList();
            ViewBag.Urunler = db.Urunler.OrderByDescending(x => x.UrunID).Take(10).ToList();

            return View();
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