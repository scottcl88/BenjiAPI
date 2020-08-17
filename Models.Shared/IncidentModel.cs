using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Shared
{
    public partial class IncidentId
    {
        public long Value { get; set; }
    }
    public partial class IncidentModel
    {
        public IncidentId IncidentId { get; set; }
        public DogModel Dog { get; set; }
        public IncidentType IncidentType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime IncidentDate { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
    public enum IncidentType
    {
        Unknown = 0,
        Pee = 1,
        Poop = 2,
        Diarrhea = 3,
        ThrowUp = 4,
        Hurt = 5,
        RanAway = 6
    }
}
