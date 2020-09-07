using FluentMigrator;
using System.Data.SqlTypes;

namespace Migrations
{
    [Migration(112)]
    public class M112AddFoodTable : Migration
    {
        public override void Up()
        {
            Create.Table("Food")
                .WithColumn("FoodId").AsInt64().PrimaryKey().Identity()
                .WithColumn("DogId").AsInt64().ForeignKey("Dog", "DogId")
                .WithColumn("AmountInOunces").AsDecimal().NotNullable()
                .WithColumn("FrequencyPerDay").AsDecimal().NotNullable()
                .WithColumn("Created").AsDateTime().NotNullable()
                .WithColumn("Modified").AsDateTime().NotNullable()
                .WithColumn("Deleted").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Food");
        }
    }
}