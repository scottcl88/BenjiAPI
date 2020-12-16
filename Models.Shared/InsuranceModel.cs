﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Shared
{
    public partial class InsuranceId
    {
        public long Value { get; set; }
    }
    public partial class InsurancePolicyId
    {
        public string Value { get; set; }
    }
    public partial class InsuranceModel
    {
        public InsuranceId InsuranceId { get; set; }
        [Required]
        public DogModel Dog { get; set; }
        [Required]
        public InsurancePolicyId PolicyId { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public DateTime? RenewalDateTime { get; set; }
        public decimal? PaymentAmount { get; set; }
        public TimeSpan? PaymentFrequency { get; set; }
        public decimal? DeductibleAmount { get; set; }
        public decimal? AnnualCoverageLimit { get; set; }
        public int? ReimbursementPercentage { get; set; }
        public string Company { get; set; }
        public string Website { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}