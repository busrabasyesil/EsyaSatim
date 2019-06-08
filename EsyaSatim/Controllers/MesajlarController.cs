using EsyaSatim.Models;
using EsyaSatim.ViewModels;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EsyaSatim.Controllers
{
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MesajGonder(MesajlarYeni formData)
        {
            if (ModelState.IsValid)
            {
                return Redirect(Url.Content("~/Mesajlar/MesajGonder"));
            }
             var mesaj = new Mesajlar()
                {
                    Mesaj = formData.Mesaj,
                    Gonderen_id = Session["Email"].ToString(),
                    Alici_id = formData.Alici_id,
                    Tarih = DateTime.Now
                };
            
            Database.Session.Save(mesaj);
            return RedirectToAction("Index", "Kullanici");
        }

        public ActionResult MesajGonder()
        {
            return View();

        }
        public ActionResult Mesajlar()
        {
            return View(new MesajlarIndex
            {
                Mesajlar = Database.Session.Query<Mesajlar>().Where(x => x.Gonderen_id == Session["Email"].ToString() || x.Alici_id == Session["Email"].ToString())

            });
        }
    }
}