using System;

namespace Models.Shared
{
    public partial class BoardingId
    {
        public long Value { get; set; }
    }

    public partial class BoardingModel
    {
        public BoardingModel()
        {
        }

        public BoardingModel(BoardingModel clone)
        {
            BoardingId = clone?.BoardingId ?? new BoardingId();
            Dog = clone?.Dog ?? new DogModel();
            StartDateTime = clone?.StartDateTime;
            EndDateTime = clone?.EndDateTime;
            PaymentAmount = clone?.PaymentAmount;
            Company = clone?.Company;
            Address = clone?.Address;
            Comments = clone?.Comments;
            Website = clone?.Website;
            Reason = clone?.Reason;
            Created = clone?.Created ?? DateTime.UtcNow;
            Modified = clone?.Modified ?? DateTime.UtcNow;
            Deleted = clone?.Deleted;
        }

        public BoardingId BoardingId { get; set; }
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