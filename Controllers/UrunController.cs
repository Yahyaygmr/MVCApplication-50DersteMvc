using MVCApplication.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MVCApplicationDbEntities db = new MVCApplicationDbEntities();
        public ActionResult Index()
        {
            var urunler = db.Urunler.ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> kategoriler = (from k in db.Kategoriler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = k.KategoriAd,
                                                    Value = k.KategoriId.ToString()
                                                }).ToList();
            ViewBag.Kategoriler = kategoriler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urunler urun)
        {
            db.Urunler.Add(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urun = db.Urunler.Find(id);
            db.Urunler.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}