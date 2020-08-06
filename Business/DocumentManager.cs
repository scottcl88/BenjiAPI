using DataExtensions;
using Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class DocumentManager
    {
        private readonly DocumentRepository _documentRepository;

        public DocumentManager()
        {
            _documentRepository = new DocumentRepository();
        }

        public List<DocumentModel> GetAllDocuments()
        {
            return _documentRepository.GetAllDocuments().ToList();
        }
        public DocumentModel GetDocumentById(DocumentId documentId)
        {
            return _documentRepository.GetDocumentById(documentId);
        }

        public bool CreateNewDocument(DocumentCreateRequest request)
        {
            return _documentRepository.CreateDocument(request.Document.FileName);
        }

        public bool UpdateDocument(DocumentUpdateRequest request)
        {
            return _documentRepository.UpdateDocument(request.Document);
        }
    }
}