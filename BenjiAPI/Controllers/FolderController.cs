using Business;
using DataExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models.Shared;
using System.Collections.Generic;

namespace BenjiAPI
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class FolderController : ControllerBase
    {
        private readonly FolderManager _folderManager;
        private readonly ILogger<FolderController> _logger;

        public FolderController(ILogger<FolderController> logger, FolderManager folderManager)
        {
            _logger = logger;
            _folderManager = folderManager;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<FolderModel> GetAll()
        {
            return _folderManager.GetAllFolders();
        }

        [HttpGet]
        [Route("Get/{Id}")]
        [EnableCors("MyPolicy")]
        public FolderModel Get(int Id)
        {
            return _folderManager.GetFolderById(new FolderId() { Value = Id });
        }

        [HttpPost]
        [Route("Add")]
        public bool Add([FromBody] FolderCreateRequest request)
        {
            return _folderManager.CreateNewFolder(request);
        }

        [HttpPost]
        [Route("Update")]
        public bool Update([FromBody] FolderUpdateRequest request)
        {
            return _folderManager.UpdateFolder(request);
        }
    }
}