using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webprogramlama2.Models.Entity;

namespace Webprogramlama2.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl

        DB_KUTUPHANEEntities dB = new DB_KUTUPHANEEntities();
        public ActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Kayit(TBL_UYELER p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");

            }
          
                dB.TBL_UYELER.Add(p);
                dB.SaveChanges();
                return View();
            
        }

        
    }
}