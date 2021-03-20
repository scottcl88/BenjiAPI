using FluentMigrator;

namespace Migrations
{
    [Migration(121)]
    public class M121VarCharMax : Migration
    {
        public override void Up()
        {
            Alter.Column("Comments").OnTable("Boarding").AsString(SQLDefaults.MAX_STRING_SIZE).Nullable();
            Alter.Column("Description").OnTable("DocumentTag").AsString(SQLDefaults.MAX_STRING_SIZE).Nullable();
            Alter.Column("Description").OnTable("Folder").AsString(SQLDefaults.MAX_STRING_SIZE).Nullable();
            Alter.Column("Description").OnTable("Incident").AsString(SQLDefaults.MAX_STRING_SIZE).Nullable(); 
            Alter.Column("Comments").OnTable("Treatments").AsString(SQLDefaults.MAX_STRING_SIZE).Nullable();
            Alter.Column("Comments").OnTable("Vaccines").AsString(SQLDefaults.MAX_STRING_SIZE).Nullable();
            Alter.Column("Comments").OnTable("VetVisits").AsString(SQLDefaults.MAX_STRING_SIZE).Nullable();
        }

        public override void Down()
        {
            Alter.Column("Comments").OnTable("Boarding").AsString(SQLDefaults.DEFAULT_STRING_SIZE).Nullable();
            Alter.Column("Description").OnTable("DocumentTag").AsString(SQLDefaults.DEFAULT_STRING_SIZE).Nullable();
            Alter.Column("Description").OnTable("Folder").AsString(SQLDefaults.DEFAULT_STRING_SIZE).Nullable();
            Alter.Column("Description").OnTable("Incident").AsString(SQLDefaults.DEFAULT_STRING_SIZE).Nullable();
            Alter.Column("Comments").OnTable("Treatments").AsString(SQLDefaults.DEFAULT_STRING_SIZE).Nullable();
            Alter.Column("Comments").OnTable("Vaccines").AsString(SQLDefaults.DEFAULT_STRING_SIZE).Nullable();
            Alter.Column("Comments").OnTable("VetVisits").AsString(SQLDefaults.DEFAULT_STRING_SIZE).Nullable();
        }
    }
}