using System;

namespace Repository.Models
{
    public class Incident
    {
        public virtual long IncidentId { get; set; }
        public virtual Dog Dog { get; set; }
        public virtual IncidentType IncidentType { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime IncidentDate { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual DateTime? Deleted { get; set; }
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