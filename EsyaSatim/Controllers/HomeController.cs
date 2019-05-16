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
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new UrunlerIndex
            {
                urunler = Database.Session.Query<Urunler>().ToList()
            });
        }
    }
}