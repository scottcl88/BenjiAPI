using FluentMigrator;
using System.Data.SqlTypes;

namespace Migrations
{
    [Migration(106)]
    public class M106AddDocumentTag : Migration
    {
        public override void Up()
        {
            Create.Table("DocumentTag")
                .WithColumn("DocumentTagId").AsInt64().PrimaryKey().Identity()
                .WithColumn("TagName").AsString().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Created").AsDateTime().NotNullable()
                .WithColumn("Modified").AsDateTime().NotNullable()
                .WithColumn("Deleted").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("DocumentTag");
        }
    }
}