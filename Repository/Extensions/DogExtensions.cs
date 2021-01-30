using Models.Shared;
using Repository.Models;

namespace Repository
{
    public static class DogExtensions
    {
        public static DogModel ToDogModel(this Dog dbDog)
        {
            return new DogModel()
            {
                DogId = new DogId() { Value = dbDog.DogId },
                Name = dbDog.Name,
                Birthdate = dbDog.Birthdate,
                AdoptedDate = dbDog.AdoptedDate,
                Gender = (global::Models.Shared.Gender)dbDog.Gender,
                MicrochipNumber = dbDog.MicrochipNumber,
                RabiesTagNumber = dbDog.RabiesTagNumber,
                Fixed = dbDog.Fixed,
                Created = dbDog.Created,
                Modified = dbDog.Modified,
                Deleted = dbDog.Deleted
            };
        }

        public static HealthModel ToHealthModel(this Health dbHealth)
        {
            return new HealthModel()
            {
                Dog = dbHealth.Dog.ToDogModel(),
                HealthId = new HealthId() { Value = dbHealth.HealthId },
                Weight = dbHealth.Weight,
                Height = dbHealth.Height,
                Length = dbHealth.Length,
                Waist = dbHealth.Waist,
                FromVet = dbHealth.FromVet,
                MouthCircumference = dbHealth.MouthCircumference,
                NoseEyeLength = dbHealth.NoseEyeLength,
                TailLength = dbHealth.TailLength,
                Created = dbHealth.Created,
                Modified = dbHealth.Modified,
                Deleted = dbHealth.Deleted
            };
        }
    }
}