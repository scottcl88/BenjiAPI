using Models;
using System;

namespace DataExtensions
{
    public partial class DocumentCreateRequest
    {
        public DocumentCreateRequest()
        {
            Document = new DocumentModel();
        }
        public DocumentModel Document { get; set; }
    }
    public partial class DocumentUpdateRequest
    {
        public DocumentUpdateRequest()
        {
            Document = new DocumentModel();
        }
        public DocumentModel Document { get; set; }
    }
}