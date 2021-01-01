using DataExtensions;
using Models.Shared;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class FolderManager
    {
        private readonly FolderRepository _folderRepository;

        public FolderManager()
        {
            _folderRepository = new FolderRepository();
        }

        public List<FolderModel> GetAllFolders()
        {
            return _folderRepository.GetAllFolders().ToList();
        }

        public FolderModel GetFolderById(FolderId folderId)
        {
            return _folderRepository.GetFolderById(folderId);
        }

        public bool CreateNewFolder(FolderCreateRequest request)
        {
            return _folderRepository.CreateFolder(request.Folder.Name);
        }

        public bool UpdateFolder(FolderUpdateRequest request)
        {
            return _folderRepository.UpdateFolder(request.Folder);
        }
    }
}