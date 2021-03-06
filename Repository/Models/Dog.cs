﻿using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public class Dog
    {
        public virtual long DogId { get; set; }
        public virtual string Name { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual DateTime? Birthdate { get; set; }
        public virtual DateTime? AdoptedDate { get; set; }
        public virtual string MicrochipNumber { get; set; }
        public virtual string RabiesTagNumber { get; set; }
        public virtual bool Fixed { get; set; }
        public virtual DateTime Created { get; set; }
        public virtual DateTime Modified { get; set; }
        public virtual DateTime? Deleted { get; set; }
        public virtual IList<Boarding> BoardingList { get; set; }
    }

    public enum Gender
    {
        Unknown = 0,
        Male = 1,
        Female = 2,
        Other = 3
    }
}