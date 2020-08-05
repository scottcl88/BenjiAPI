﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class DogId
    {
        public long Value { get; set; }
    }
    public class DogModel
    {
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


    public class HealthId
    {
        public long Value { get; set; }
    }
    public class HealthModel
    {
        public HealthId HealthId { get; set; }
        public DogModel Dog { get; set; }
        public decimal Weight { get; set; }
        public decimal Height { get; set; }
        public decimal Length { get; set; }
        public decimal Waist { get; set; }
        public DateTime? AdoptedDate { get; set; }
        public DateTime? Birthdate { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Modified { get; set; }
        public DateTime? Deleted { get; set; }
    }

    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2,
        Other = 3
    }
}