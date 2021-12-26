using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webprogramlama2.Models.Entity;

namespace Webprogramlama2.Controllers
{
    public class UyelerController : Controller
    {
        // GET: Uyeler
        DB_KUTUPHANEEntities db = new DB_KUTUPHANEEntities();
        public ActionResult Index()
        {
            var degerler = db.TBL_UYELER.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult UyelerEkle()
        {
            return View();
        }

        public ActionResult UyelerEkle(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("UyelerEkle");
            }
            db.TBL_UYELER.Add(p);
            db.SaveChanges();
            return View();
        }
        public ActionResult UyelerSil(int id)
        {
            var uye= db.TBL_UYELER.Find(id);
            db.TBL_UYELER.Remove(uye);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyelerGetir(int id)
        {
            var uye = db.TBL_UYELER.Find(id);
            return View("UyelerGetir", uye);
        }
        public ActionResult UyelerGuncelle(TBL_UYELER p)
        {
            var uye = db.TBL_UYELER.Find(p.ID);
            uye.AD = p.AD;
            uye.SOYAD = p.SOYAD;
            uye.MAIL = p.MAIL;
            uye.KULLANICIADI = p.KULLANICIADI;
            uye.SIFRE = p.SIFRE;
            uye.OKUL = p.OKUL;
            uye.TELEFON = p.TELEFON;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}