using FluentMigrator;

namespace Migrations
{
    [Migration(117)]
    public class M117AddMicrochipRabiesAndFixedToDog : Migration
    {
        public override void Up()
        {
            Alter.Table("Dog")
                .AddColumn("MicrochipNumber").AsString().Nullable()
                .AddColumn("RabiesTagNumber").AsString().Nullable()
                .AddColumn("Fixed").AsBoolean().Nullable();
        }

        public override void Down()
        {
            Delete.Column("MicrochipNumber").FromTable("Dog");
            Delete.Column("RabiesTagNumber").FromTable("Dog");
            Delete.Column("Fixed").FromTable("Dog");
        }
    }
}