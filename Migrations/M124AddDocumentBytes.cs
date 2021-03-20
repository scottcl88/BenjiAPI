using FluentMigrator;

namespace Migrations
{
    [Migration(124)]
    public class M124AddDocumentBytes : Migration
    {
        public override void Up()
        {
            Alter.Table("Document").AddColumn("Bytes").AsBinary(26214400).Nullable();
        }

        public override void Down()
        {
            Delete.Column("Bytes").FromTable("Document");
        }
    }
}