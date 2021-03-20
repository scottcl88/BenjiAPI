using FluentMigrator;

namespace Migrations
{
    [Migration(125)]
    public class M125AddBackupSproc : Migration
    {
        public override void Up()
        {
            Execute.Script("./EmbeddedScripts/AddBackupSproc.sql");
        }

        public override void Down()
        {
            Execute.Sql("DROP PROCEDURE AddBackupSproc");
        }
    }
}