using Business;
using DataExtensions;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MimeTypes;
using Models.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BenjiAPI
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("MyPolicy")]
    public class DocumentController : ControllerBase
    {
        private readonly DocumentManager _documentManager;
        private readonly FolderManager _folderManager;
        private readonly ILogger<DocumentController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly string[] permittedExtensions = new string[] { ".txt", ".pdf" };
        private readonly long _fileSizeLimit = 26214400;
                                               
        public DocumentController(ILogger<DocumentController> logger, DocumentManager documentManager, FolderManager folderManager, IWebHostEnvironment environment)
        {
            _logger = logger;
            _documentManager = documentManager;
            _folderManager = folderManager;
            _hostingEnvironment = environment;
        }

        [HttpGet]
        [Route("GetAll")]
        [EnableCors("MyPolicy")]
        public List<DocumentModel> GetAll()
        {
            return _documentManager.GetAllDocuments();
        }

        [HttpGet]
        [Route("Get/{id}")]
        [EnableCors("MyPolicy")]
        public DocumentModel Get(long id)
        {
            return _documentManager.GetDocumentById(new DocumentId() { Value = id });
        }

        [HttpGet]
        [Route("Download/{documentId}")]
        [EnableCors("MyPolicy")]
        public FileResult Download(long documentId)
        {
            var doc = _documentManager.GetDocumentById(new DocumentId() { Value = documentId });
            //string filePath = GetFilePath(doc.DocumentKey, doc.Folder.Name, doc.ContentType, doc.Created);
            return File(doc.Bytes, doc.ContentType, doc.FileName);
        }

        [HttpPost]
        [Route("Add")]
        [EnableCors("MyPolicy")]
        public bool Add([FromBody] DocumentCreateRequest request)
        {
            return _documentManager.CreateNewDocument(request);
        }

        [HttpPost]
        [Route("Update")]
        [EnableCors("MyPolicy")]
        public bool Update([FromBody] DocumentUpdateRequest request)
        {
            //var originalDoc = _documentManager.GetDocumentById(request.Document.DocumentId);
            var result = _documentManager.UpdateDocument(request);
            //if (result)
            //{
            //    var newDoc = _documentManager.GetDocumentById(request.Document.DocumentId);
            //    //string originalFilePath = GetFilePath(originalDoc.DocumentKey, originalDoc.Folder.Name, originalDoc.ContentType, originalDoc.Created);
            //    //string newFilePath = GetFilePath(newDoc.DocumentKey, newDoc.Folder.Name, newDoc.ContentType, newDoc.Created);
            //    //System.IO.File.Move(originalFilePath, newFilePath);
            //}
            return result;
        }

        [HttpPost]
        [Route("upload/multiple/{folderId}")]
        [EnableCors("MyPolicy")]
        public async Task<IActionResult> Multiple(IFormFile[] files, int folderId)
        {
            try
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        var ext = Path.GetExtension(file.FileName).ToLowerInvariant();

                        if (string.IsNullOrEmpty(ext) || !permittedExtensions.Contains(ext))
                        {
                            return StatusCode(500, "Invalid extension");
                        }
                        if (file.Length > _fileSizeLimit)
                        {
                            return StatusCode(500, "Exceeds file limit");
                        }
                        var folder = _folderManager.GetFolderById(new FolderId() { Value = folderId });
                        if (folder == null)
                        {
                            return StatusCode(500, "Invalid folder id");
                        }
                        var documentKey = Guid.NewGuid();
                        string untrustedFileName = file.FileName;
                        DateTime createdDate = DateTime.UtcNow;
                        //string filePath = GetFilePath(documentKey, folder.Name, file.ContentType, createdDate);
                        //using (var fileStream = new FileStream(filePath, FileMode.CreateNew))
                        //{
                        //    await file.CopyToAsync(fileStream);
                        //}
                        byte[] fileBytes = new byte[0];
                        if (file.Length > 0)
                        {
                            using (var ms = file.OpenReadStream())
                            {
                                using (var ms2 = new MemoryStream())
                                {
                                    await ms.CopyToAsync(ms2);
                                    fileBytes = ms2.ToArray();
                                }
                            }
                        }
                        var request = new DocumentCreateRequest()
                        {
                            Document = new DocumentModel()
                            {
                                ByteSize = (int)file.Length,
                                Bytes = fileBytes,
                                FileName = untrustedFileName,
                                ContentType = file.ContentType,
                                Folder = folder,
                                DocumentKey = documentKey,
                                Modified = DateTime.UtcNow,
                                LastViewed = DateTime.UtcNow,
                                Created = createdDate
                            }
                        };
                        var result = _documentManager.CreateNewDocument(request);
                        if (!result)
                        {
                            return StatusCode(500, "Failed to save document");
                        }
                    }
                }
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //private string GetFilePath(Guid docKey, string folderName, string contentType, DateTime createdDate)
        //{
        //    var uploads = Path.Combine(Directory.GetCurrentDirectory(), "uploads", folderName);
        //    Directory.CreateDirectory(uploads);
        //    var safeFileName = $"{createdDate:yyyy-MM-dd}_{docKey}{MimeTypeMap.GetExtension(contentType)}";
        //    return Path.Combine(uploads, safeFileName);
        //}
    }
}