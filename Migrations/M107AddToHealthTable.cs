using FluentMigrator;
using System.Data.SqlTypes;

namespace Migrations
{
    [Migration(107)]
    public class M107AddToHealthTable : Migration
    {
        public override void Up()
        {
            Alter.Table("Health")
                .AddColumn("TailLength").AsDecimal()
                .AddColumn("MouthCircumference").AsDecimal()
                .AddColumn("NoseEyeLength").AsDecimal()
                .AddColumn("FromVet").AsBoolean();
        }

        public override void Down()
        {
            Delete.Column("TailLength").FromTable("Health");
            Delete.Column("MouthCircumference").FromTable("Health");
            Delete.Column("NoseEyeLength").FromTable("Health");
            Delete.Column("FromVet").FromTable("Health");
        }
    }
}