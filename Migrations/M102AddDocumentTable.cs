using FluentMigrator;
using System.Data.SqlTypes;

namespace Migrations
{
    [Migration(102)]
    public class M102AddDocumentTable : Migration
    {
        public override void Up()
        {
            Create.Table("Document")
                .WithColumn("DocumentId").AsInt64().PrimaryKey().Identity()
                .WithColumn("FileName").AsString().NotNullable()
                .WithColumn("Key").AsString().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Created").AsDateTime().NotNullable()
                .WithColumn("Modified").AsDateTime().NotNullable()
                .WithColumn("Deleted").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Document");
        }
    }
}