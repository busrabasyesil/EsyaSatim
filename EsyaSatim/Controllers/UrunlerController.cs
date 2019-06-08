using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
                urunler = Database.Session.Query<Urunler>().Where(x => x.Email == Session["Email"].ToString())
            });
        }

        public ActionResult UrunEkle()
        {
            return View("urunekle");

        }

        [HttpPost]
        public ActionResult UrunEkle(UrunlerYeni formData, HttpPostedFileBase ResimYolu)
        {
            string path = Path.Combine(Server.MapPath("~/Esyalar"), ResimYolu.FileName);
            ResimYolu.SaveAs(path);

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
                Kategori = formData.Kategori,
                ResimYolu = ResimYolu.FileName,
                //ResimYolu = formData.ResimYolu,
                Tarih = DateTime.Now

            };
            //user.SetPassword(formData.Password);
            Database.Session.Save(urun);
            //return View(formData);
            return RedirectToAction("Index", "Kullanici");

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
                    Kategori = urun.Kategori,
                    ResimYolu = urun.ResimYolu,
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
            urun.ResimYolu = formData.ResimYolu;
            urun.Kategori = formData.Kategori;
            Database.Session.Update(urun); //insert into Users (USername,password_hash,email) values ....
            Database.Session.Flush();
            return RedirectToAction("Urunler", "Urunler");


        }

        public ActionResult Sil(int Id)
        {
            var urun = Database.Session.Load<Urunler>(Id);
            if (urun == null)
            {
                return HttpNotFound();
            }

            Database.Session.Delete(urun);
            Database.Session.Flush();

            return RedirectToAction("Urunler", "Urunler");

        }

        public ActionResult UrunlerElektronik()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().Where(x => x.Kategori == Convert.ToInt32(Enums.Kategoriler.Elektronik))
            });
        }
        public ActionResult UrunlerSpor()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().Where(x => x.Kategori == Convert.ToInt32(Enums.Kategoriler.Spor))
            });
        }
        public ActionResult UrunlerKiyafet()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().Where(x => x.Kategori == Convert.ToInt32(Enums.Kategoriler.Kiyafet))
            });
        }
        public ActionResult UrunlerKitap()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().Where(x => x.Kategori == Convert.ToInt32(Enums.Kategoriler.Kitap))
            });
        }
        public ActionResult UrunlerDiger()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().Where(x => x.Kategori == Convert.ToInt32(Enums.Kategoriler.Diger))
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