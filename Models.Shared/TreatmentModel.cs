using System;

namespace Models.Shared
{
    public partial class TreatmentId
    {
        public long Value { get; set; }
    }

    public partial class TreatmentModel
    {
        public TreatmentModel()
        {
        }

        public TreatmentModel(TreatmentModel clone)
        {
            TreatmentId = clone?.TreatmentId ?? new TreatmentId();
            Dog = clone?.Dog ?? new DogModel();
            Title = clone?.Title;
            ReceivedDateTime = clone?.ReceivedDateTime;
            Doctor = clone?.Doctor;
            Amount = clone?.Amount;
            ExpirationDateTime = clone?.ExpirationDateTime;
            Comments = clone?.Comments;
            Created = clone?.Created ?? DateTime.UtcNow;
            Modified = clone?.Modified ?? DateTime.UtcNow;
            Deleted = clone?.Deleted;
        }

        public TreatmentId TreatmentId { get; set; }
        public DogModel Dog { get; set; }
        public string Title { get; set; }
        public DateTime? ReceivedDateTime { get; set; }
        public string Doctor { get; set; }
        public string Amount { get; set; }
        public DateTime? ExpirationDateTime { get; set; }
        public string Comments { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}