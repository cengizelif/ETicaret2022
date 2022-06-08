using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret2022.Models;
using Microsoft.AspNet.Identity;

namespace ETicaret2022.Controllers
{
    public class SepetController : Controller
    {

        ETicaret2022Entities db = new ETicaret2022Entities();
        public ActionResult SepeteEkle(int? adet,int id)
        {
            Urunler urun = db.Urunler.Find(id);

            Sepet sepettekiurun = db.Sepet.FirstOrDefault(x => x.UrunID == id);

            string userID = User.Identity.GetUserId();

            if(sepettekiurun==null)
            {
                Sepet yeniurun = new Sepet()
                {
                    Adet = adet??1,
                    UrunID=id,
                    ToplamTutar=urun.UrunFiyati*(adet??1),
                    UserID=userID                     
                };
                db.Sepet.Add(yeniurun);              
            }
            else
            {
                sepettekiurun.Adet = sepettekiurun.Adet + (adet??1);
                sepettekiurun.ToplamTutar = sepettekiurun.Adet * urun.UrunFiyati;
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}