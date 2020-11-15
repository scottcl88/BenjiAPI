using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Models.Shared
{
    public partial class BoardingId
    {
        public long Value { get; set; }
    }
    public partial class BoardingModel
    {
        public BoardingId BoardingId { get; set; }
        [Required]
        public DogModel Dog { get; set; }
        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
        public string Website { get; set; }
        public string Reason { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}