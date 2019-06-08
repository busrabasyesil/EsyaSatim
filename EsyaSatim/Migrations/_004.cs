using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsyaSatim.Migrations
{
    [Migration(4)]
    public class _004 : Migration
    {
        public override void Down()
        {
            Delete.Table("Mesajlar");
        }

        public override void Up()
        {
            Create.Table("Mesajlar")
                            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                            .WithColumn("Gonderen_id").AsString()
                            .WithColumn("Alici_id").AsString()
                            .WithColumn("Tarih").AsDateTime()
                            .WithColumn("Mesaj").AsString(1024);
        }
    }
}