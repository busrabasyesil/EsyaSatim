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
                urunler = Database.Session.Query<Urunler>().OrderByDescending(x => x.Tarih).ToList().Where(x => x.Email == Session["Email"].ToString())
            });
        }

        public ActionResult UrunEkle()
        {
            ViewBag.kategori = new SelectList(Database.Session.Query<Kategori>(), "Id", "Ad" );
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

            var urun = new Urunler()
            {
                Ad = formData.Ad,
                Fiyat = formData.Fiyat,
                Aciklama = formData.Aciklama,
                Email = Session["Email"].ToString(),
                Kategori = formData.Kategori,
                ResimYolu = ResimYolu.FileName,
                Tarih = DateTime.Now


        };
            ViewBag.kategori = new SelectList(Database.Session.Query<Kategori>(), "Id", "Ad", urun.Kategori);

            Database.Session.Save(urun);
            return RedirectToAction("Index", "Kullanici");

        }

        public ActionResult Duzenle(int Id)
        {
            var urun = Database.Session.Load<Urunler>(Id);

            if (urun == null)
            {
                return HttpNotFound();
            }
            ViewBag.kategori = new SelectList(Database.Session.Query<Kategori>(), "Id", "Ad", urun.Kategori);

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
        public ActionResult Duzenle(int Id, UrunDuzenle formData, HttpPostedFileBase ResimYolu)
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
            if (ResimYolu != null)
            {
                var path = Path.Combine(Server.MapPath("~/Esyalar"), ResimYolu.FileName);
                ResimYolu.SaveAs(path);
                urun.Ad = formData.Ad;
                urun.Fiyat = formData.Fiyat;
                urun.Aciklama = formData.Aciklama;
                urun.ResimYolu = ResimYolu.FileName;
                urun.Kategori = formData.Kategori;
            }
            urun.Ad = formData.Ad;
            urun.Fiyat = formData.Fiyat;
            urun.Aciklama = formData.Aciklama;
            urun.Kategori = formData.Kategori;
            ViewBag.kategori = new SelectList(Database.Session.Query<Kategori>(), "Id", "Ad", urun.Kategori);
            Database.Session.Update(urun);
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