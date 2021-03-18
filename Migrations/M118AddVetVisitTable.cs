using FluentMigrator;

namespace Migrations
{
    [Migration(118)]
    public class M118AddVetVisitTable : Migration
    {
        public override void Up()
        {
            Create.Table("VetVisits")
                  .WithColumn("VetVisitId").AsInt64().PrimaryKey().Identity()
                  .WithColumn("DogId").AsInt64().ForeignKey("Dog", "DogId")
                  .WithColumn("Title").AsString().Nullable()
                  .WithColumn("VisitDateTime").AsDateTime().Nullable()
                  .WithColumn("Doctor").AsString().Nullable()
                  .WithColumn("Company").AsString().Nullable()
                  .WithColumn("Address").AsString().Nullable()
                  .WithColumn("Comments").AsString(5000).Nullable()
                  .WithColumn("Created").AsDateTime().NotNullable()
                  .WithColumn("Modified").AsDateTime().NotNullable()
                  .WithColumn("Deleted").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("VetVisits");
        }
    }
}