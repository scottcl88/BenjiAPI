using DataExtensions;
using Models.Shared;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

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