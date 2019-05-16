using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsyaSatim.Models
{
    public class Kullanici
    {
        public virtual int Id { get; set; }
        public virtual string Ad { get; set; }
        public virtual string Soyad { get; set; }
        public virtual string Email { get; set; }
        public virtual string Sifre { get; set; }

        public virtual void SetPassword(string password)
        {
            Sifre = BCrypt.Net.BCrypt.HashPassword(password, 13);
        }

        public virtual bool CheckPassword(string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, Sifre);
        }

        public static void FakeHash()
        {
            BCrypt.Net.BCrypt.HashPassword(" ", 13);
        }
        
        public class KullaniciMap : ClassMapping<Kullanici>
        {
            public KullaniciMap()
            {
                Table("Kullanici");

                Id(x => x.Id, x => x.Generator(Generators.Identity));
                Property(x => x.Ad, x => x.NotNullable(true));
                Property(x => x.Soyad, x => x.NotNullable(true));
                Property(x => x.Email, x => x.NotNullable(true));
                Property(x => x.Sifre, x => {
                    x.NotNullable(true);
                    x.Column("Sifre");
                });
            }
        }
    }
}