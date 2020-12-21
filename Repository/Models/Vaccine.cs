using System;

namespace Repository.Models
{
    public partial class Vaccine
    {
        public virtual long VaccineId { get; set; }
        public virtual Dog Dog { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime? Received { get; set; }
        public virtual DateTime? Expiration { get; set; }
        public virtual string Doctor { get; set; }
        public virtual string Company { get; set; }
        public virtual string Address { get; set; }
        public virtual string Comments { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual DateTime? Deleted { get; set; }
    }
}