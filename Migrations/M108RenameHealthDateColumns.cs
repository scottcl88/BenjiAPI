using FluentMigrator;

namespace Migrations
{
    [Migration(108)]
    public class M108RenameHealthDateColumns : Migration
    {
        public override void Up()
        {
            Execute.Sql("EXEC sp_rename 'Health.CreationDateTime', 'Created', 'COLUMN';");
            Execute.Sql("EXEC sp_rename 'Health.ModificationDateTime', 'Modified', 'COLUMN';");
            Execute.Sql("EXEC sp_rename 'Health.DeletionDateTime', 'Deleted', 'COLUMN';");
        }

        public override void Down()
        {
            Execute.Sql("EXEC sp_rename 'Health.Created', 'CreationDateTime', 'COLUMN';");
            Execute.Sql("EXEC sp_rename 'Health.Modified', 'ModificationDateTime', 'COLUMN';");
            Execute.Sql("EXEC sp_rename 'Health.Deleted', 'DeletionDateTime', 'COLUMN';");
        }
    }
}