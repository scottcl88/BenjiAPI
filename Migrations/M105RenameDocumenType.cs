using FluentMigrator;
using System.Data.SqlTypes;

namespace Migrations
{
    [Migration(105)]
    public class M105RenameDocumenType : Migration
    {
        public override void Up()
        {
            Execute.Sql("EXEC sp_rename 'Document.Type', 'ContentType', 'COLUMN';");
        }
        
        public override void Down()
        {
            Execute.Sql("EXEC sp_rename 'Document.ContentType', 'Type', 'COLUMN';");
        }
    }
}