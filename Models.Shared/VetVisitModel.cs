using System;

namespace Models.Shared
{
    public partial class VetVisitId
    {
        public long Value { get; set; }
    }

    public partial class VetVisitModel
    {
        public VetVisitModel()
        {
        }

        public VetVisitModel(VetVisitModel clone)
        {
            VetVisitId = clone?.VetVisitId ?? new VetVisitId();
            Dog = clone?.Dog ?? new DogModel();
            Title = clone?.Title;
            VisitDateTime = clone?.VisitDateTime;
            Doctor = clone?.Doctor;
            Company = clone?.Company;
            Address = clone?.Address;
            Comments = clone?.Comments;
            Created = clone?.Created ?? DateTime.UtcNow;
            Modified = clone?.Modified ?? DateTime.UtcNow;
            Deleted = clone?.Deleted;
        }

        public VetVisitId VetVisitId { get; set; }
        public DogModel Dog { get; set; }
        public string Title { get; set; }
        public DateTime? VisitDateTime { get; set; }
        public string Doctor { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string Comments { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}