using System;

namespace Repository.Models
{
    public partial class Boarding
    {
        public virtual long BoardingId { get; set; }
        public virtual Dog Dog { get; set; }
        public virtual DateTime? StartDateTime { get; set; }
        public virtual DateTime? EndDateTime { get; set; }
        public virtual decimal? PaymentAmount { get; set; }
        public virtual string Company { get; set; }
        public virtual string Address { get; set; }
        public virtual string Comments { get; set; }
        public virtual string Reason { get; set; }
        public virtual string Website { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual DateTime? Deleted { get; set; }
    }
}