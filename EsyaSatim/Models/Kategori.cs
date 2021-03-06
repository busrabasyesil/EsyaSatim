﻿using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsyaSatim.Models
{
    public class Kategori
    {
        public virtual int Id { get; set; }
        public virtual string Ad { get; set; }

        public class KategoriMap : ClassMapping<Kategori>
        {
            public KategoriMap()
            {
                Table("Kategori");

                Id(x => x.Id, x => x.Generator(Generators.Identity));
                Property(x => x.Ad, x => x.NotNullable(false));

            }
        }
    }
}