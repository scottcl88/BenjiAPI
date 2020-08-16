using System;

namespace Repository.Models
{
    public class DocumentTag
    {
        public virtual long DocumentTagId { get; set; }
        public virtual string TagName { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual DateTime? Deleted { get; set; }
    }

}