using NHibernate;
using System;

namespace Repository
{
    public class BackupRepository
    {
        public bool ExecuteBackup()
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
                {
                    var query = session.CreateSQLQuery("exec AddBackupSproc");
                    var obj = query.UniqueResult();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DateTime? GetLastBackup()
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
                {
                    var query = session.CreateSQLQuery("select * from msdb..backupset where database_name=N'BenjiDB' and backup_set_id=(select max(backup_set_id) from msdb..backupset where database_name=N'BenjiDB' )");
                    var obj = query.UniqueResult<object[]>();
                    return (DateTime)obj[26];
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}