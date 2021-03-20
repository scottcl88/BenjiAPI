using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Shared
{
    public partial class DocumentId
    {
        public long Value { get; set; }
    }

    public partial class DocumentModel
    {
        public DocumentModel()
        {
            Tags = new List<DocumentTagModel>();
        }

        [Required]
        public DocumentId DocumentId { get; set; }

        [Required]
        public string FileName { get; set; }

        public string Description { get; set; }
        public string ContentType { get; set; }
        public int ByteSize { get; set; }
        public byte[] Bytes { get; set; }

        [Required]
        public FolderModel Folder { get; set; }

        [Required]
        public Guid DocumentKey { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime LastViewed { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
        public IList<DocumentTagModel> Tags { get; set; }
        public static readonly long MaxSize = 26214400;//20 MB
    }

    public partial class DocumentTagId
    {
        public long Value { get; set; }
    }

    public partial class DocumentTagModel
    {
        [Required]
        public DocumentTagId DocumentTagId { get; set; }

        [Required]
        public string TagName { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }

    public partial class FolderId
    {
        public long Value { get; set; }
    }

    public partial class FolderModel
    {
        public FolderId FolderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LastViewed { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}