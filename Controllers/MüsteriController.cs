using MVCApplication.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class MüsteriController : Controller
    {
        // GET: Müsteri
        MVCApplicationDbEntities db = new MVCApplicationDbEntities();
        public ActionResult Index()
        {
            var musteriler = db.Musteriler.ToList();
            return View(musteriler);
        }
        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(Musteriler musteri)
        {
            db.Musteriler.Add(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MusteriSil(int id)
        {
            var musteri = db.Musteriler.Find(id);
            db.Musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult MusteriGuncelle(int id)
        {
            var musteri = db.Musteriler.Find(id);

            return View("MusteriGuncelle",musteri);
        }
        [HttpPost]
        public ActionResult MusteriGuncelle(Musteriler musteri)
        {
            var eskMusteri = db.Musteriler.Find(musteri.MusteriId);
            eskMusteri.MusteriAd = musteri.MusteriAd;
            eskMusteri.MusteriSoyad = musteri.MusteriSoyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}