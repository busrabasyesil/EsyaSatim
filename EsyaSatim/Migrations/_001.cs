using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsyaSatim.Migrations
{
    [Migration(1)]
    public class _001 : Migration
    {
        public override void Down()
        {
            Delete.Table("Kullanici");
        }

        public override void Up()
        {
            Create.Table("Kullanici")
                            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                            .WithColumn("Ad").AsString(128)
                            .WithColumn("Soyad").AsString(128)
                            .WithColumn("Email").AsCustom("VARCHAR(256)")
                            .WithColumn("Sifre").AsString(128);
        }
    }
}