using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate.Linq;
using EsyaSatim.ViewModels;
using EsyaSatim.Models;

namespace EsyaSatim.Controllers
{
    public class UrunlerController : Controller
    {
        // GET: Urunler
      
        public ActionResult Urunler()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().ToList()
            });
        }

        public ActionResult UrunEkle()
        {
            return View("urunekle");
         
        }

        [HttpPost]
        public ActionResult UrunEkle(UrunlerYeni formData)
        {

            if (ModelState.IsValid)
            {
                return Redirect(Url.Content("~/Urunler/UrunEkle"));
            }

            //var kullanici = Database.Session.Query<Kullanici>.Where(a => a.Email == email).Select(s => new Kullanici() { Id = s.Id }).ToList();
            //string deniz = Session["Email"].ToString();

            var urun = new Urunler()
            {
                Ad = formData.Ad,
                Fiyat = formData.Fiyat,
                Aciklama = formData.Aciklama,
                Email = Session["Email"].ToString(),
                Kategori_id = formData.Kategori_id,
                Resim = formData.Resim,
                Tarih = DateTime.Now

            };
            //user.SetPassword(formData.Password);
            Database.Session.Save(urun);
            //return View(formData);
            return RedirectToAction("Urunler", "Urunler");

        }

        public ActionResult Duzenle(int Id)
        {
            var urun = Database.Session.Load<Urunler>(Id);

            if (urun == null)
            {
                return HttpNotFound();
            }


            return View(
                new UrunDuzenle()
                {
                    Ad = urun.Ad,
                    Fiyat = urun.Fiyat,
                    Aciklama = urun.Aciklama,
                    Kategori = urun.Kategori_id,
                    Resim = urun.Resim,
                }
            );
        }

        [HttpPost]
        public ActionResult Duzenle(int Id, UrunDuzenle formData)
        {

            var urun = Database.Session.Load<Urunler>(Id);
            if (urun == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(formData);
            }

            urun.Ad = formData.Ad;
            urun.Fiyat = formData.Fiyat;
            urun.Aciklama = formData.Aciklama;
            urun.Resim = formData.Resim;
            urun.Kategori_id = formData.Kategori;
            Database.Session.Update(urun); //insert into Users (USername,password_hash,email) values ....
            //Database.Session.Flush();
            return RedirectToAction("Urunler");


        }

    }
}
