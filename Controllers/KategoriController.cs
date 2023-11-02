using MVCApplication.Models.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApplication.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kato
        MVCApplicationDbEntities db = new MVCApplicationDbEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var kategoriler = db.Kategoriler.ToList().ToPagedList(sayfa, 10);
            return View(kategoriler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(Kategoriler kategori)
        {
            db.Kategoriler.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KategoriSil(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult KategoriGuncelle(int id)
        {
            var kategori = db.Kategoriler.Find(id);
            return View(kategori);
        }
        [HttpPost]
        public ActionResult KategoriGuncelle(Kategoriler kategori)
        {
            var eskKategori = db.Kategoriler.Find(kategori.KategoriId);
            eskKategori.KategoriAd = kategori.KategoriAd;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}