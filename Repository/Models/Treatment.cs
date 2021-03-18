using System;

namespace Repository.Models
{
    public partial class Treatment
    {
        public virtual long TreatmentId { get; set; }
        public virtual Dog Dog { get; set; }
        public virtual string Title { get; set; }
        public virtual DateTime? ReceivedDateTime { get; set; }
        public virtual string Doctor { get; set; }
        public virtual string Amount { get; set; }
        public virtual DateTime? ExpirationDateTime { get; set; }
        public virtual string Comments { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual DateTime? Deleted { get; set; }
    }
}