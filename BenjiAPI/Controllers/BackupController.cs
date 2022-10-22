using Business;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace BenjiAPI
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class BackupController : ControllerBase
    {
        private readonly BackupManager _backupManager;
        private readonly ILogger<BackupController> _logger;

        public BackupController(ILogger<BackupController> logger, BackupManager backupManager)
        {
            _logger = logger;
            _backupManager = backupManager;
        }

        [HttpGet]
        [Route("GetLastBackup")]
        [EnableCors("MyPolicy")]
        public DateTime? GetLastBackup()
        {
            return _backupManager.GetLastBackup();
        }

        [HttpGet]
        [Route("AddBackup")]
        [EnableCors("MyPolicy")]
        public bool AddBackup()
        {
            return _backupManager.AddBackup();
        }
    }
}