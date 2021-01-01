using Models.Shared;

namespace DataExtensions
{
    public partial class FolderCreateRequest
    {
        public FolderCreateRequest()
        {
            Folder = new FolderModel();
        }

        public FolderModel Folder { get; set; }
    }

    public partial class FolderUpdateRequest
    {
        public FolderUpdateRequest()
        {
            Folder = new FolderModel();
        }

        public FolderModel Folder { get; set; }
    }
}