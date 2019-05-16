using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsyaSatim.Migrations
{
    [Migration(3)]
    public class _003 : Migration
    {
        public override void Down()
        {
            Delete.Table("Urunler");
        }

        public override void Up()
        {
            Create.Table("Urunler")
                             .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                             .WithColumn("Ad").AsString(128)
                             .WithColumn("Resim").AsString()
                             .WithColumn("Email").AsString()
                             .WithColumn("Fiyat").AsInt32()
                             .WithColumn("Aciklama").AsString(1024)
                             .WithColumn("Tarih").AsDateTime()
                             .WithColumn("Kategori_id").AsString();


        }
    }
}