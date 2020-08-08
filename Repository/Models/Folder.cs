using System;

namespace Repository.Models
{
    public class Folder
    {
        public virtual long FolderId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime LastViewed { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual DateTime? Deleted { get; set; }
    }

}