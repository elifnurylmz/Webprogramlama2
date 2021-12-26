using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webprogramlama2.Models.Entity;
namespace Webprogramlama2.Controllers
{
    public class ProfilimController : Controller
    {
        DB_KUTUPHANEEntities db = new DB_KUTUPHANEEntities();
        // GET: Profilim
        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TBL_UYELER.FirstOrDefault(z => z.MAIL == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TBL_UYELER p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = p.SIFRE;
            db.SaveChanges();
            return View();
        }
    }
}