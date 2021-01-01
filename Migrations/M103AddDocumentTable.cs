using FluentMigrator;

namespace Migrations
{
    [Migration(103)]
    public class M103AddDocumentTable : Migration
    {
        public override void Up()
        {
            Create.Table("Document")
                .WithColumn("DocumentId").AsInt64().PrimaryKey().Identity()
                .WithColumn("FileName").AsString().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("Type").AsString().NotNullable()
                .WithColumn("ByteSize").AsInt32().NotNullable()
                .WithColumn("FolderId").AsInt64().ForeignKey("Folder", "FolderId")
                .WithColumn("Key").AsString().NotNullable()
                .WithColumn("LastViewed").AsDateTime().NotNullable()
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