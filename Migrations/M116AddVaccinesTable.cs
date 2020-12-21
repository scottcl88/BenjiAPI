using FluentMigrator;
using System.Data.SqlTypes;

namespace Migrations
{
    [Migration(116)]
    public class M116AddVaccinesTable : Migration
    {
        public override void Up()
        {
            Create.Table("Vaccines")
                  .WithColumn("VaccineId").AsInt64().PrimaryKey().Identity()
                  .WithColumn("DogId").AsInt64().ForeignKey("Dog", "DogId")
                  .WithColumn("Title").AsString().Nullable()
                  .WithColumn("Received").AsDateTime().Nullable()
                  .WithColumn("Expiration").AsDateTime().Nullable()
                  .WithColumn("Doctor").AsString().Nullable()
                  .WithColumn("Company").AsString().Nullable()
                  .WithColumn("Address").AsString().Nullable()
                  .WithColumn("Comments").AsString().Nullable()
                  .WithColumn("Created").AsDateTime().NotNullable()
                  .WithColumn("Modified").AsDateTime().NotNullable()
                  .WithColumn("Deleted").AsDateTime().Nullable();
        }
        public override void Down()
        {
            Delete.Table("Vaccines");
        }
    }
}