using Models.Shared;
using NHibernate;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DocumentRepository
    {
        public List<DocumentModel> GetAllDocuments()
        {
            List<DocumentModel> documentModels = new List<DocumentModel>();
            try
            {
                using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
                {
                    var documents = session.Query<Document>().Where(c => !c.Deleted.HasValue);
                    documentModels = documents.Select(x => x.ToDocumentModel(false)).ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return documentModels;
        }

        public DocumentModel GetDocumentById(DocumentId documentId)
        {
            DocumentModel documentModel = new DocumentModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var document = session.Query<Document>().FirstOrDefault(c => c.DocumentId == documentId.Value);
                if (document != null)
                {
                    documentModel = document.ToDocumentModel(true);
                }
            }
            return documentModel;
        }

        public bool CreateDocument(DocumentModel model)
        {
            Document newDocument = new Document
            {
                Bytes = model.Bytes,
                FileName = model.FileName,
                Created = model.Created,
                ContentType = model.ContentType,
                ByteSize = model.ByteSize,
                Description = model.Description,
                DocumentKey = model.DocumentKey,
                LastViewed = model.LastViewed,
                Modified = model.Modified
            };
            using (ISession session = NHibernateSession.OpenSession())
            {
                Folder foundFolder = session.Query<Folder>().FirstOrDefault(f => f.FolderId == model.Folder.FolderId.Value);
                if (foundFolder == null) return false;
                newDocument.Folder = foundFolder;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Save(newDocument); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool UpdateDocument(DocumentModel documentModel)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    Document foundDocument = session.Query<Document>().FirstOrDefault(c => c.DocumentId == documentModel.DocumentId.Value);
                    if (foundDocument == null) return false;
                    foundDocument.FileName = documentModel.FileName;
                    foundDocument.Description = documentModel.Description;
                    foundDocument.Modified = DateTime.UtcNow;
                    Folder foundFolder = session.Query<Folder>().FirstOrDefault(f => f.FolderId == documentModel.Folder.FolderId.Value);
                    if (foundFolder == null) return false;
                    foundDocument.Folder = foundFolder;
                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Update(foundDocument); //  Save the user in session
                        transaction.Commit();   //  Commit the changes to the database
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}