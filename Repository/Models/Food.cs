using System;

namespace Repository.Models
{
    public class Food
    {
        public virtual long FoodId { get; set; }
        public virtual Dog Dog { get; set; }
        public virtual decimal AmountInOunces { get; set; }
        public virtual int FrequencyPerDay { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual DateTime? Deleted { get; set; }
    }
}