using Models;

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

    public partial class DocumentDeleteRequest
    {
        public DocumentId DocumentId { get; set; }
    }
}