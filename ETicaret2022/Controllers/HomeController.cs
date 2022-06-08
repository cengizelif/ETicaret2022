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

        public ActionResult Kategori(int id)
        {
            Kategori kat=db.Kategori.Find(id);

            ViewBag.KategoriAd = kat.KategoriAdi;

            ViewBag.Kategoriler = db.Kategori.ToList();

            return View(db.Urunler.Where(x=>x.KategoriID==id).OrderBy(x=>x.UrunAdi).ToList());
        }
        public ActionResult Urun(int id)
        {
            ViewBag.Kategoriler = db.Kategori.ToList();
            return View(db.Urunler.Find(id));
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