using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Shared
{
    public partial class FoodId
    {
        public long Value { get; set; }
    }
    public partial class FoodModel
    {
        public FoodId FoodId { get; set; }
        public DogModel Dog { get; set; }
        public decimal AmountInOunces { get; set; }
        public int FrequencyPerDay { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
