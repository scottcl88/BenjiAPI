using FluentMigrator;
using System.Data.SqlTypes;

namespace Migrations
{
    [Migration(111)]
    public class M111AddDogToIncident : Migration
    {
        public override void Up()
        {
            Alter.Table("Incident")
                .AddColumn("DogId").AsInt64().ForeignKey("Dog", "DogId");
        }
        
        public override void Down()
        {
            Delete.Column("DogId").FromTable("Incident");
        }
    }
}