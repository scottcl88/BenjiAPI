using FluentMigrator;

namespace Migrations
{
    [Migration(119)]
    public class M119AddTreatmentTable : Migration
    {
        public override void Up()
        {
            Create.Table("Treatments")
                  .WithColumn("TreatmentId").AsInt64().PrimaryKey().Identity()
                  .WithColumn("DogId").AsInt64().ForeignKey("Dog", "DogId")
                  .WithColumn("Title").AsString().Nullable()
                  .WithColumn("ReceivedDateTime").AsDateTime().Nullable()
                  .WithColumn("Doctor").AsString().Nullable()
                  .WithColumn("Amount").AsString().Nullable()
                  .WithColumn("Duration").AsTime().Nullable()
                  .WithColumn("Comments").AsString(5000).Nullable()
                  .WithColumn("Created").AsDateTime().NotNullable()
                  .WithColumn("Modified").AsDateTime().NotNullable()
                  .WithColumn("Deleted").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Treatments");
        }
    }
}