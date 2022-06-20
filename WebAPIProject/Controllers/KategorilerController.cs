using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIProject.Models;

namespace WebAPIProject.Controllers
{
    public class KategorilerController : ApiController
    {
        public List<Kategorim> Get()
        {
            ETicaret2022Entities db = new ETicaret2022Entities();

            //List<Kategori> kategoriler = (from x in db.Kategori
            //                              select new Kategori { KategoriID = x.KategoriID, KategoriAdi = x.KategoriAdi }).ToList();

            List<Kategori> kategoriler = db.Kategori.ToList();

            List<Kategorim> liste = new List<Kategorim>();

            foreach (var item in kategoriler)
            {
                liste.Add(new Kategorim() { KategoriID = item.KategoriID, KategoriAdi = item.KategoriAdi }) ;
            }

            return liste;
        }
    }
}
