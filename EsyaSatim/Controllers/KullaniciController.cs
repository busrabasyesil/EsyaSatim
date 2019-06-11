using NHibernate.Linq;
using EsyaSatim.ViewModels;
using EsyaSatim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EsyaSatim.Controllers
{
    public class KullaniciController : Controller
    {
        // GET: Kullanici
        public ActionResult Index()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().OrderByDescending(x => x.Tarih).ToList()
            });
        }
        public ActionResult KayitOl()
        {
            return View(new KullaniciYeni());
        }

        [HttpPost]
        public ActionResult KayitOl(KullaniciYeni formData)
        {

            if (Database.Session.Query<Kullanici>().Any(u => u.Email == formData.Email))
            {
                ModelState.AddModelError("Email", "Email sistemde mevcut.");
            }

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            var user = new Kullanici()
            {
                Ad = formData.Ad,
                Soyad = formData.Soyad,
                Email = formData.Email,
                Sifre = formData.Sifre
            };

            user.SetPassword(formData.Sifre);
            Database.Session.Save(user); //insert into Users (USername,password_hash,email) values ....

            return RedirectToAction("GirisYap", "Kullanici");

        }

        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(AuthLogin formData, string returnUrl)
        {

            var user = Database.Session.Query<Kullanici>().FirstOrDefault(p => p.Email == formData.Email);

            //var deniz = BCrypt.Net.BCrypt.HashPassword(formData.Sifre, 13);
            //string deniz = formData.Sifre;
            //bool result = Database.Session.Query<Kullanici>().Any(x => x.Email == formData.Email && x.user.CheckPassword(formData.Sifre) == deniz);
            if (Database.Session.Query<Kullanici>().Any(x => x.Email == formData.Email ))
            {
                formData.Id = Database.Session.Query<Kullanici>().Where(x => x.Email == formData.Email).Select(x => x.Id).FirstOrDefault();
                FormsAuthentication.SetAuthCookie(formData.Email, true);
                 Session.Add("Email", formData.Email);
               // ViewData["Email"] = formData.Email;
                return Redirect(Url.Content("~/Kullanici/Index"));
            }

            if (user == null || !user.CheckPassword(formData.Sifre))
            {
                ModelState.AddModelError("Email", "Email veya şifre yanlış.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            FormsAuthentication.SetAuthCookie(formData.Email, true);
            
            if (!String.IsNullOrWhiteSpace(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Kullanici");
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UrunlerElektronik()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().OrderByDescending(x => x.Tarih).ToList().Where(x => x.Kategori == 1)
            });
        }
        public ActionResult UrunlerSpor()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().OrderByDescending(x => x.Tarih).ToList().Where(x => x.Kategori == 2)
            });
        }
        public ActionResult UrunlerKiyafet()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().OrderByDescending(x => x.Tarih).ToList().Where(x => x.Kategori == 3)
            });
        }
        public ActionResult UrunlerKitap()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().OrderByDescending(x => x.Tarih).ToList().Where(x => x.Kategori == 4)
            });
        }
        public ActionResult UrunlerBebek()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().OrderByDescending(x => x.Tarih).ToList().Where(x => x.Kategori == 5)
            });
        }
        public ActionResult UrunlerDiger()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().OrderByDescending(x => x.Tarih).ToList().Where(x => x.Kategori == 6)
            });
        }

        public ActionResult UrunDetay(int Id)
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().Where(x => x.Id == Id)
            });

        }

    }
}
    