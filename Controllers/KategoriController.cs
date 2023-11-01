using MVCApplication.Models.Entity;
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
        public ActionResult Index()
        {
            var kategoriler = db.Kategoriler.ToList();
            return View(kategoriler);
        }
    }
}