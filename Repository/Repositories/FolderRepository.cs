using Models.Shared;
using NHibernate;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class FolderRepository
    {
        public List<FolderModel> GetAllFolders()
        {
            List<FolderModel> folderModels;
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var folders = session.Query<Folder>().Where(c => !c.Deleted.HasValue);
                folderModels = folders.Select(x => x.ToFolderModel()).ToList();
            }
            return folderModels;
        }

        public FolderModel GetFolderById(FolderId folderId)
        {
            FolderModel folderModel = new FolderModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var folder = session.Query<Folder>().FirstOrDefault(c => c.FolderId == folderId.Value);
                if (folder != null)
                {
                    folderModel = folder.ToFolderModel();
                }
            }
            return folderModel;
        }

        public bool CreateFolder(string name)
        {
            Folder newFolder = new Folder
            {
                Name = name,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                LastViewed = DateTime.UtcNow
            };
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Save(newFolder); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool UpdateFolder(FolderModel folderModel)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Folder foundFolder = session.Query<Folder>().FirstOrDefault(c => c.FolderId == folderModel.FolderId.Value);
                if (foundFolder == null) return false;
                foundFolder.Name = folderModel.Name;
                foundFolder.Description = folderModel.Description;
                foundFolder.Modified = DateTime.UtcNow;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundFolder); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }
    }
}