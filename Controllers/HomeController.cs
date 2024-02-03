using MVCApplication.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class HomeController : Controller
    {
        MVCApplicationDbEntities db = new MVCApplicationDbEntities();
        public ActionResult Index()
        {
            int mmusteriSayisi = db.Musteriler.Count();
            int urunSayisi = db.Urunler.Count();
            int satisSayisi = db.Satislar.Count();
            List<Satislar> satislar = db.Satislar.ToList();
            decimal topSatis = 0;
            foreach (var item in satislar)
            {
                topSatis += item.Fiyat.Value;
            }
            ViewBag.topSatis = topSatis;
            ViewBag.MusteriSayisi = mmusteriSayisi;
            ViewBag.UrunSayisi = urunSayisi;
            ViewBag.SatisSayisi = satisSayisi;
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
        public ActionResult Deneme()
        {
 

            return View();
        }
    }
}