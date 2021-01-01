using FluentMigrator;

namespace Migrations
{
    [Migration(113)]
    public class M113RenameFoodDateColumns : Migration
    {
        public override void Up()
        {
            Execute.Sql("EXEC sp_rename 'Food.CreationDateTime', 'Created', 'COLUMN';");
            Execute.Sql("EXEC sp_rename 'Food.ModificationDateTime', 'Modified', 'COLUMN';");
            Execute.Sql("EXEC sp_rename 'Food.DeletionDateTime', 'Deleted', 'COLUMN';");
        }

        public override void Down()
        {
            Execute.Sql("EXEC sp_rename 'Food.Created', 'CreationDateTime', 'COLUMN';");
            Execute.Sql("EXEC sp_rename 'Food.Modified', 'ModificationDateTime', 'COLUMN';");
            Execute.Sql("EXEC sp_rename 'Food.Deleted', 'DeletionDateTime', 'COLUMN';");
        }
    }
}