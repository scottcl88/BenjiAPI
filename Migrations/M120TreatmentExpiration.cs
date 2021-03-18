using FluentMigrator;

namespace Migrations
{
    [Migration(120)]
    public class M120TreatmentExpiration : Migration
    {
        public override void Up()
        {
            Alter.Table("Treatments").AddColumn("ExpirationDateTime").AsDateTime().Nullable();
            Delete.Column("Duration").FromTable("Treatments");
        }

        public override void Down()
        {
            Delete.Column("ExpirationDateTime").FromTable("Treatments");
            Alter.Table("Treatments").AddColumn("Duration").AsTime().Nullable();
        }
    }
}