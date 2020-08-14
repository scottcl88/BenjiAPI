using FluentMigrator;
using System.Data.SqlTypes;

namespace Migrations
{
    [Migration(104)]
    public class M104RenameDocumentKey : Migration
    {
        public override void Up()
        {
            Execute.Sql("EXEC sp_rename 'Document.Key', 'DocumentKey', 'COLUMN';");
        }
        
        public override void Down()
        {
            Execute.Sql("EXEC sp_rename 'Document.DocumentKey', 'Key', 'COLUMN';");
        }
    }
}