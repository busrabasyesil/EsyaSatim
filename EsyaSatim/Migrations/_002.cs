using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EsyaSatim.Migrations
{
    [Migration(2)]
    public class _002 : Migration
    {
        public override void Down()
        {
            Delete.Table("Kategori");
        }

        public override void Up()
        {
            Create.Table("Kategori")
                           .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                           .WithColumn("Ad").AsString(128);
            

        }
    }
}