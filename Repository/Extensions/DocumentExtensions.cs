using Models.Shared;
using Repository.Models;
using System.Linq;

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
                Bytes = dbDocument.Bytes,
                Description = dbDocument.Description,
                ContentType = dbDocument.ContentType,
                ByteSize = dbDocument.ByteSize,
                Folder = dbDocument.Folder.ToFolderModel(),
                DocumentKey = dbDocument.DocumentKey,
                LastViewed = dbDocument.LastViewed,
                Created = dbDocument.Created,
                Modified = dbDocument.Modified,
                Deleted = dbDocument.Deleted,
                Tags = dbDocument.Tags?.Select(x => x.ToDocumenTagModel())?.ToList()
            };
        }

        public static DocumentTagModel ToDocumenTagModel(this DocumentTag dbDocumentTag)
        {
            return new DocumentTagModel()
            {
                DocumentTagId = new DocumentTagId() { Value = dbDocumentTag.DocumentTagId },
                TagName = dbDocumentTag.TagName,
                Description = dbDocumentTag.Description,
                Created = dbDocumentTag.Created,
                Modified = dbDocumentTag.Modified,
                Deleted = dbDocumentTag.Deleted
            };
        }
    }
}