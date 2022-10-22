using Repository;
using System;

namespace Business
{
    public class BackupManager
    {
        private readonly BackupRepository _backupRepository;

        public BackupManager()
        {
            _backupRepository = new BackupRepository();
        }

        public bool AddBackup()
        {
            return _backupRepository.ExecuteBackup();
        }

        public DateTime? GetLastBackup()
        {
            return _backupRepository.GetLastBackup();
        }
    }
}