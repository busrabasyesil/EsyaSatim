using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using EsyaSatim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static EsyaSatim.Models.Kullanici;
using static EsyaSatim.Models.Urunler;
using static EsyaSatim.Models.Kategori;
using static EsyaSatim.Models.Mesajlar;

namespace EsyaSatim
{
    public static class Database
    {
        private static ISessionFactory _sessionFactory;

        public static ISession Session
        {
            get
            {
                return (ISession)HttpContext.Current.Items["Session"];
            }
        }


        public static void Configure()
        {
            var config = new Configuration();
            config.Configure();

            var mapper = new ModelMapper();
            mapper.AddMapping<KullaniciMap>();
            mapper.AddMapping<UrunlerMap>();
            mapper.AddMapping<KategoriMap>();
            mapper.AddMapping<MesajMap>();


            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            _sessionFactory = config.BuildSessionFactory();
        }
        public static void OpenSession()
        {
            HttpContext.Current.Items["Session"] = _sessionFactory.OpenSession();
        }

        public static void CloseSession()
        {

            var session = HttpContext.Current.Items["Session"] as ISession;
            if (session != null)
            {
                session.Close();
            }

            HttpContext.Current.Items.Remove("SessionFactory");

        }
    }
}