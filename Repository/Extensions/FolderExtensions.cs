using Models;
using Repository.Models;

namespace Repository
{
    public static class FolderExtensions
    {
        public static FolderModel ToFolderModel(this Folder dbFolder)
        {
            return new FolderModel()
            {
                FolderId = new FolderId() { Value = dbFolder.FolderId },
                Name = dbFolder.Name,
                Description = dbFolder.Description,
                LastViewed = dbFolder.LastViewed,
                Created = dbFolder.Created,
                Modified = dbFolder.Modified,
                Deleted = dbFolder.Deleted
            };
        }
    }
}
