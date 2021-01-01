using System;

namespace Models.Shared
{
    public partial class VaccineId
    {
        public long Value { get; set; }
    }

    public partial class VaccineModel
    {
        public VaccineModel()
        {
        }

        public VaccineModel(VaccineModel clone)
        {
            VaccineId = clone?.VaccineId ?? new VaccineId();
            Dog = clone?.Dog ?? new DogModel();
            Title = clone?.Title;
            Expiration = clone?.Expiration;
            Received = clone?.Received;
            Doctor = clone?.Doctor;
            Company = clone?.Company;
            Address = clone?.Address;
            Comments = clone?.Comments;
            Created = clone?.Created ?? DateTime.UtcNow;
            Modified = clone?.Modified ?? DateTime.UtcNow;
            Deleted = clone?.Deleted;
        }

        public VaccineId VaccineId { get; set; }
        public DogModel Dog { get; set; }
        public string Title { get; set; }
        public DateTime? Received { get; set; }
        public DateTime? Expiration { get; set; }
        public string Doctor { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}