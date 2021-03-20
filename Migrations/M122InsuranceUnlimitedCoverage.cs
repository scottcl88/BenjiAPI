using FluentMigrator;

namespace Migrations
{
    [Migration(122)]
    public class M122InsuranceUnlimitedCoverage : Migration
    {
        public override void Up()
        {
            Alter.Table("Insurance").AddColumn("UnlimitedAnnualCoverageLimit").AsBoolean().WithDefaultValue(false);
        }

        public override void Down()
        {
            Delete.Column("UnlimitedAnnualCoverageLimit").FromTable("Insurance");
        }
    }
}