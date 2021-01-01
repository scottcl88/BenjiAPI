using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public class Document
    {
        public virtual long DocumentId { get; set; }
        public virtual string FileName { get; set; }
        public virtual string Description { get; set; }
        public virtual string ContentType { get; set; }
        public virtual int ByteSize { get; set; }
        public virtual Folder Folder { get; set; }
        public virtual Guid DocumentKey { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime LastViewed { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual DateTime? Deleted { get; set; }
        public virtual IList<DocumentTag> Tags { get; set; }
    }
}