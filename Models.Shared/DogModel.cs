using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Shared
{
    public partial class DogId
    {
        public long Value { get; set; }
    }

    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2,
        Other = 3
    }
    public partial class DogModel
    {
        public DogModel()
        {
        }

        public DogModel(DogModel clone)
        {
            DogId = clone?.DogId ?? new DogId();
            Name = clone?.Name;
            AdoptedDate = clone?.AdoptedDate;
            Birthdate = clone?.Birthdate;
            Gender = clone?.Gender ?? Gender.Unknown;
            Created = clone?.Created ?? DateTime.UtcNow;
            Modified = clone?.Modified ?? DateTime.UtcNow;
            Deleted = clone?.Deleted;
        }

        [Required]
        public DogId DogId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public DateTime? AdoptedDate { get; set; }
        public DateTime? Birthdate { get; set; }

        [Required]
        public DateTime? Created { get; set; }

        [Required]
        public DateTime? Modified { get; set; }

        public DateTime? Deleted { get; set; }
    }
}