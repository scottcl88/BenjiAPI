using System;

namespace Models.Shared
{
    public partial class HealthId
    {
        public long Value { get; set; }
    }

    public partial class HealthModel
    {
        public HealthId HealthId { get; set; }
        public DogModel Dog { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Height { get; set; }
        public decimal? Length { get; set; }
        public decimal? Waist { get; set; }
        public decimal? TailLength { get; set; }
        public decimal? MouthCircumference { get; set; }
        public decimal? NoseEyeLength { get; set; }
        public bool FromVet { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}