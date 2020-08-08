using System;

namespace Repository.Models
{
    public class Document
    {
        public virtual long DocumentId { get; set; }
        public virtual string FileName { get; set; }
        public virtual string Description { get; set; }
        public virtual string Type { get; set; }
        public virtual int ByteSize { get; set; }
        public virtual Folder Folder { get; set; }
        public virtual Guid Key { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime LastViewed { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual DateTime? Deleted { get; set; }
    }

}