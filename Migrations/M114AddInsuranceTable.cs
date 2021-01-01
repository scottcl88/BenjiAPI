using FluentMigrator;

namespace Migrations
{
    [Migration(114)]
    public class M114AddInsuranceTable : Migration
    {
        public override void Up()
        {
            Create.Table("Insurance")
                  .WithColumn("InsuranceId").AsInt64().PrimaryKey().Identity()
                  .WithColumn("DogId").AsInt64().ForeignKey("Dog", "DogId")
                  .WithColumn("PolicyId").AsString().NotNullable()
                  .WithColumn("StartDateTime").AsDateTime().Nullable()
                  .WithColumn("EndDateTime").AsDateTime().Nullable()
                  .WithColumn("RenewalDateTime").AsDateTime().Nullable()
                  .WithColumn("PaymentAmount").AsDecimal().Nullable()
                  .WithColumn("PaymentFrequency").AsTime().Nullable()
                  .WithColumn("DeductibleAmount").AsDecimal().Nullable()
                  .WithColumn("AnnualCoverageLimit").AsDecimal().Nullable()
                  .WithColumn("ReimbursementPercentage").AsInt32().Nullable()
                  .WithColumn("Company").AsString().Nullable()
                  .WithColumn("Website").AsString().Nullable()
                  .WithColumn("Created").AsDateTime().NotNullable()
                  .WithColumn("Modified").AsDateTime().NotNullable()
                  .WithColumn("Deleted").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Insurance");
        }
    }
}