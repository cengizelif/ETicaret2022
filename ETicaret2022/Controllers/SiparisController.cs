using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETicaret2022.Models;

namespace ETicaret2022.Controllers
{
    public class SiparisController : Controller
    {
        ETicaret2022Entities db = new ETicaret2022Entities();
        public ActionResult Index()
        {                       
            return View(db.Siparis.ToList());
        }
    }
}