using FluentMigrator;
using System.Data.SqlTypes;

namespace Migrations
{
    [Migration(115)]
    public class M115AddBoardingTable : Migration
    {
        public override void Up()
        {
            Create.Table("Boarding")
                  .WithColumn("BoardingId").AsInt64().PrimaryKey().Identity()
                  .WithColumn("DogId").AsInt64().ForeignKey("Dog", "DogId")
                  .WithColumn("StartDateTime").AsDateTime().Nullable()
                  .WithColumn("EndDateTime").AsDateTime().Nullable()
                  .WithColumn("PaymentAmount").AsDecimal().Nullable()
                  .WithColumn("Company").AsString().Nullable()
                  .WithColumn("Address").AsString().Nullable()
                  .WithColumn("Comments").AsString().Nullable()
                  .WithColumn("Website").AsString().Nullable()
                  .WithColumn("Reason").AsString().Nullable()
                  .WithColumn("Created").AsDateTime().NotNullable()
                  .WithColumn("Modified").AsDateTime().NotNullable()
                  .WithColumn("Deleted").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Boarding");
        }
    }
}