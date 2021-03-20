using FluentMigrator;

namespace Migrations
{
    [Migration(123)]
    public class M123InsurancePaymentFrequency : Migration
    {
        public override void Up()
        {
            Alter.Table("Insurance").AlterColumn("PaymentFrequency").AsInt64().Nullable();
        }

        public override void Down()
        {
            Alter.Table("Insurance").AlterColumn("PaymentFrequency").AsTime().Nullable();
        }
    }
}