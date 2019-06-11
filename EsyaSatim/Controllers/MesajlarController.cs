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

            var kullanici_email = Database.Session.Query<Urunler>().Where(x => x.Id == Convert.ToInt32(formData.Alici_id)).ToList()[0].Email;
            var kullanici_id = Database.Session.Query<Kullanici>().Where(x => x.Email == kullanici_email).ToList()[0].Id;
            var mesaj = new Mesajlar()
            {
                Mesaj = formData.Mesaj,
                Gonderen_id = Session["Email"].ToString(),
                Alici_id = kullanici_id.ToString(),
                Tarih = DateTime.Now
            };

            Database.Session.Save(mesaj);
            return RedirectToAction("Mesajlar", "Mesajlar");
        }

        public ActionResult MesajGonder(int id)
        {
            ViewData["id"] = id;
            return View();

        }

        public ActionResult Mesajlar()
        {

            string kullanici_Email = Session["Email"].ToString();
            int kullanici_Id = Database.Session.Query<Kullanici>().Where(x => x.Email == kullanici_Email).ToList()[0].Id;
            List<Mesajlar> mesajlar = Database.Session.Query<Mesajlar>().OrderByDescending(x => x.Tarih).ToList().Where(x => x.Alici_id == kullanici_Id.ToString() || x.Gonderen_id == kullanici_Email).ToList();
            foreach (var item in mesajlar as List<Mesajlar>)
            {
                item.Alici_id = Database.Session.Query<Kullanici>().Where(x => x.Id.ToString() == item.Alici_id).ToList()[0].Email;
            }
            ViewData["mesajlar"] = mesajlar;
            return View(new MesajlarIndex
            {
                Mesajlar = Database.Session.Query<Mesajlar>().Where(x => x.Alici_id == kullanici_Id.ToString())
            });
        }

        [HttpPost]
        public ActionResult Cevapla(MesajlarYeni formData)
        {
            if (ModelState.IsValid)
            {
                return Redirect(Url.Content("~/Mesajlar/Cevapla"));
            }

            var kullanici_email = Database.Session.Query<Mesajlar>().Where(x => x.Id == Convert.ToInt32(formData.Alici_id)).ToList()[0].Gonderen_id;
            var kullanici_id = Database.Session.Query<Kullanici>().Where(x => x.Email == kullanici_email).ToList()[0].Id;
            var mesaj = new Mesajlar()
            {
                Mesaj = formData.Mesaj,
                Gonderen_id = Session["Email"].ToString(),
                Alici_id = kullanici_id.ToString(),
                Tarih = DateTime.Now
            };

            Database.Session.Save(mesaj);
            return Redirect(Url.Content("~/Mesajlar/Mesajlar"));
        }

        public ActionResult Cevapla(int id)
        {
            ViewData["id"] = id;
            return View();

        }

    }
}