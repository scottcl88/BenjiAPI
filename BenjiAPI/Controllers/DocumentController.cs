using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using DataExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;

namespace BenjiAPI
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class DocumentController : ControllerBase
    {
        private DocumentManager _documentManager;
        private readonly ILogger<DocumentController> _logger;

        public DocumentController(ILogger<DocumentController> logger, DocumentManager documentManager)
        {
            _logger = logger;
            _documentManager = documentManager;
        }

        [HttpGet]
        [Route("GetAll")]
        public List<DocumentModel> GetAll()
        {
            return _documentManager.GetAllDocuments();
        }
        [HttpGet]
        [Route("Get/{Id}")]
        [EnableCors("MyPolicy")]
        public DocumentModel Get(int Id)
        {
            return _documentManager.GetDocumentById(new DocumentId() { Value = Id });
        }
        [HttpPost]
        [Route("Add")]
        public bool Add([FromBody] DocumentCreateRequest request)
        {
            return _documentManager.CreateNewDocument(request);
        }
        [HttpPost]
        [Route("Update")]
        public bool Update([FromBody] DocumentUpdateRequest request)
        {
            return _documentManager.UpdateDocument(request);
        }
    }
}
