using FluentMigrator;
using System.Data.SqlTypes;

namespace Migrations
{
    [Migration(109)]
    public class M109ChangeHealthToNullable : Migration
    {
        public override void Up()
        {
            Alter.Column("Weight").OnTable("Health").AsDecimal().Nullable();
            Alter.Column("Height").OnTable("Health").AsDecimal().Nullable();
            Alter.Column("Length").OnTable("Health").AsDecimal().Nullable();
            Alter.Column("Waist").OnTable("Health").AsDecimal().Nullable();
            Alter.Column("TailLength").OnTable("Health").AsDecimal().Nullable();
            Alter.Column("MouthCircumference").OnTable("Health").AsDecimal().Nullable();
            Alter.Column("NoseEyeLength").OnTable("Health").AsDecimal().Nullable();
            Alter.Column("FromVet").OnTable("Health").AsDecimal().Nullable();
            Alter.Column("Deleted").OnTable("Health").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Alter.Column("Weight").OnTable("Health").AsDecimal().NotNullable();
            Alter.Column("Height").OnTable("Health").AsDecimal().NotNullable();
            Alter.Column("Length").OnTable("Health").AsDecimal().NotNullable();
            Alter.Column("Waist").OnTable("Health").AsDecimal().NotNullable();
            Alter.Column("TailLength").OnTable("Health").AsDecimal().NotNullable();
            Alter.Column("MouthCircumference").OnTable("Health").AsDecimal().NotNullable();
            Alter.Column("NoseEyeLength").OnTable("Health").AsDecimal().NotNullable();
            Alter.Column("FromVet").OnTable("Health").AsDecimal().NotNullable();
            Alter.Column("Deleted").OnTable("Health").AsDateTime().NotNullable();
        }
    }
}