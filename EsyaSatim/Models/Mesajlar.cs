using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsyaSatim.Models
{
    public class Mesajlar
    {

        public virtual int Id { get; set; }
        public virtual string Gonderen_id { get; set; }
        public virtual string Alici_id { get; set; }
        public virtual DateTime Tarih { get; set; }
        public virtual string Mesaj { get; set; }

        public class MesajMap : ClassMapping<Mesajlar>
        {
            public MesajMap()
            {
                Table("Mesajlar");

                Id(x => x.Id, x => x.Generator(Generators.Identity));
                Property(x => x.Gonderen_id, x => x.NotNullable(false));
                Property(x => x.Alici_id, x => x.NotNullable(false));
                Property(x => x.Tarih, x => x.NotNullable(false));
                Property(x => x.Mesaj, x => x.NotNullable(false));

            }
        }
    }
}