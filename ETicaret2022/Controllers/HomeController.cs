using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ETicaret2022.Models;

using Newtonsoft.Json;

namespace ETicaret2022.Controllers
{
    public class HomeController : Controller
    {
        //async Task<ActionResult>
        ETicaret2022Entities db = new ETicaret2022Entities();
        public async Task<ActionResult> Index()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44390/");

            var result = await client.GetAsync("api/Kategoriler");

            var sonuc = await result.Content.ReadAsStringAsync();

            ViewBag.Kategoriler = JsonConvert.DeserializeObject<List<Kategori>>(sonuc);

           // ViewBag.Kategoriler = db.Kategori.ToList();
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