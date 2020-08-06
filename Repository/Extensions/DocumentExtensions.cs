using Models;
using Repository.Models;

namespace Repository
{
    public static class DocumentExtensions
    {
        public static DocumentModel ToDocumentModel(this Document dbDocument)
        {
            return new DocumentModel()
            {
                DocumentId = new DocumentId() { Value = dbDocument.DocumentId },
                FileName = dbDocument.FileName,
                Description = dbDocument.Description,
                Key = dbDocument.Key,
                Created = dbDocument.Created,
                Modified = dbDocument.Modified,
                Deleted = dbDocument.Deleted
            };
        }
    }
}
