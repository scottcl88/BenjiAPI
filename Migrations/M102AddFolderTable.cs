using FluentMigrator;

namespace Migrations
{
    [Migration(102)]
    public class M102AddFolderTable : Migration
    {
        public override void Up()
        {
            Create.Table("Folder")
                .WithColumn("FolderId").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Description").AsString().Nullable()
                .WithColumn("LastViewed").AsDateTime().NotNullable()
                .WithColumn("Created").AsDateTime().NotNullable()
                .WithColumn("Modified").AsDateTime().NotNullable()
                .WithColumn("Deleted").AsDateTime().Nullable();
        }

        public override void Down()
        {
            Delete.Table("Folder");
        }
    }
}