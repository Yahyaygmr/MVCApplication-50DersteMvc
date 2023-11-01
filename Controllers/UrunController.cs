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
    }
}