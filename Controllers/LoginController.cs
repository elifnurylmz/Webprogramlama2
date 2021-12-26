using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webprogramlama2.Models.Entity;
using System.Web.Security;

namespace Webprogramlama2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DB_KUTUPHANEEntities db = new DB_KUTUPHANEEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBL_UYELER p)
        {
            var bilgiler = db.TBL_UYELER.FirstOrDefault(x => x.MAIL == p.MAIL && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                Session["id"] = bilgiler.ID.ToString();
                Session["Ad"] = bilgiler.AD.ToString();
                Session["Soyad"] = bilgiler.SOYAD.ToString();
                Session["KullanıcıAdı"] = bilgiler.KULLANICIADI.ToString();
                Session["Şifre"] = bilgiler.SIFRE.ToString();
                Session["Telefon"] = bilgiler.TELEFON.ToString();
                Session["Okul"] = bilgiler.OKUL.ToString();
               
                
                return RedirectToAction("Index", "Profilim");
            }
            else
            {
                return View();
            }
          
            
        }

    }
}