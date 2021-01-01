using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Shared
{
    public partial class FoodId
    {
        public long Value { get; set; }
    }

    public partial class FoodModel
    {
        public FoodId FoodId { get; set; }

        [Required]
        public DogModel Dog { get; set; }

        [Required]
        public decimal AmountInOunces { get; set; }

        [Required]
        public int FrequencyPerDay { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }
}