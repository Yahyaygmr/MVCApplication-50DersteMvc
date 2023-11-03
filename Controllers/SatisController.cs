using MVCApplication.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        MVCApplicationDbEntities db = new MVCApplicationDbEntities();
        public ActionResult Index()
        {
            List<SelectListItem> urunler = (from u in db.Urunler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = u.UrunAd,
                                                Value = u.UrunId.ToString()
                                            }).ToList();
            ViewBag.Urunler = urunler;
            List<SelectListItem> musteriler = (from m in db.Musteriler.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = m.MusteriAd + " " + m.MusteriSoyad,
                                                   Value = m.MusteriId.ToString()
                                               }).ToList();
            ViewBag.Musteriler = musteriler;
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(Satislar satis)
        {
            db.Satislar.Add(satis);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisListesi()
        {
            var satialer = db.Satislar.ToList();
            return View(satialer);
        }
    }
}