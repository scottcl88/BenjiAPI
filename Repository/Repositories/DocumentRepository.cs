using Models;
using NHibernate;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class DocumentRepository : IRepository
    {
        public List<DocumentModel> GetAllDocuments()
        {
            List<DocumentModel> documentModels = new List<DocumentModel>();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var documents = session.Query<Document>().Where(c => !c.Deleted.HasValue);
                documentModels = documents.Select(x => x.ToDocumentModel()).ToList();
            }
            return documentModels;
        }
        public DocumentModel GetDocumentById(DocumentId documentId)
        {
            DocumentModel documentModel = new DocumentModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var document = session.Query<Document>().FirstOrDefault(c => c.DocumentId == documentId.Value);
                if(document != null)
                {
                    documentModel = document.ToDocumentModel();
                }
            }
            return documentModel;
        }

        public bool CreateDocument(string name)
        {
            Document newDocument = new Document
            {
                FileName = name,
                Created = DateTime.UtcNow
            };
            using (ISession session = NHibernateSession.OpenSession())
            {
                //User foundUser = session.Query<User>().FirstOrDefault(u => u.HashedLoginToken == hashedLoginToken);
                //if (foundUser == null) return false;
                //newDocument.User = foundUser;
                //newCar.UserId = foundUser.UserId;
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
            using (ISession session = NHibernateSession.OpenSession())
            {
                Document foundDocument = session.Query<Document>().FirstOrDefault(c => c.DocumentId == documentModel.DocumentId.Value);
                if (foundDocument == null) return false;
                foundDocument.FileName = documentModel.FileName;
                foundDocument.Description = documentModel.Description;
                foundDocument.Modified = DateTime.UtcNow;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundDocument); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }
    }
}