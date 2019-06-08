using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace EsyaSatim.Models
{
    public class Urunler
    {

        public virtual int Id { get; set; }
        public virtual string Ad { get; set; }
        public virtual string Fiyat { get; set; }
        public virtual string ResimYolu { get; set; }
        public virtual string Aciklama { get; set; }
        public virtual string Email { get; set; }
        public virtual int Kategori { get; set; }
        public virtual DateTime Tarih { get; set; }
        
        public class UrunlerMap : ClassMapping<Urunler>
        {
            public UrunlerMap()
            {
                Table("Urunler");

                Id(x => x.Id, x => x.Generator(Generators.Identity));
                Property(x => x.Ad, x => x.NotNullable(true));
                Property(x => x.Fiyat, x => x.NotNullable(true));
                Property(x => x.ResimYolu, x => x.NotNullable(true));
                Property(x => x.Aciklama, x => x.NotNullable(true));
                Property(x => x.Email, x => x.NotNullable(true));
                Property(x => x.Kategori, x => x.NotNullable(true));
                Property(x => x.Tarih, x => x.NotNullable(true));
                
            }
        }
        
    }
}