using MVCApplication.Models.Entity;
using PagedList;
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
        public ActionResult Index(int sayfa=1)
        {
            var urunler = db.Urunler.ToList().ToPagedList(sayfa,10);
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
        [HttpGet]
        public ActionResult UrunGuncelle(int id)
        {
            List<SelectListItem> kategoriler = (from k in db.Kategoriler.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = k.KategoriAd,
                                                    Value = k.KategoriId.ToString()
                                                }).ToList();
            ViewBag.Kategoriler = kategoriler;
            var urun = db.Urunler.Find(id);
            return View(urun);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Urunler urun)
        {
            var eskUrun = db.Urunler.Find(urun.UrunId);
            eskUrun.UrunAd = urun.UrunAd;
            eskUrun.Marka = urun.Marka;
            eskUrun.UrunKategori = urun.UrunKategori;
            eskUrun.Fiyat = urun.Fiyat;
            eskUrun.Stok = urun.Stok;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}