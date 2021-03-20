using System;

namespace Repository.Models
{
    public partial class Insurance
    {
        public virtual long InsuranceId { get; set; }
        public virtual Dog Dog { get; set; }
        public virtual string PolicyId { get; set; }
        public virtual DateTime? StartDateTime { get; set; }
        public virtual DateTime? EndDateTime { get; set; }
        public virtual DateTime? RenewalDateTime { get; set; }
        public virtual decimal? PaymentAmount { get; set; }
        public virtual TimeSpan? PaymentFrequency { get; set; }
        public virtual decimal? DeductibleAmount { get; set; }
        public virtual decimal? AnnualCoverageLimit { get; set; }
        public virtual bool UnlimitedAnnualCoverageLimit { get; set; }
        public virtual int? ReimbursementPercentage { get; set; }
        public virtual string Company { get; set; }
        public virtual string Website { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual DateTime? Deleted { get; set; }
    }
}