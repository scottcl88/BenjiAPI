using FluentMigrator;
using System.Data.SqlTypes;

namespace Migrations
{
    [Migration(110)]
    public class M110AddIncidentTable : Migration
    {
        public override void Up()
        {
            Create.Table("Incident")
                .WithColumn("IncidentId").AsInt64().PrimaryKey().Identity()
                .WithColumn("IncidentType").AsInt32().NotNullable()
                .WithColumn("Title").AsString().Nullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("IncidentDate").AsDateTime().NotNullable()
                .WithColumn("Created").AsDateTime().NotNullable()
                .WithColumn("Modified").AsDateTime().NotNullable()
                .WithColumn("Deleted").AsDateTime().Nullable();
        }
        
        public override void Down()
        {
            Delete.Table("Incident");
        }
    }
}