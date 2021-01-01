using Models.Shared;
using Repository.Models;

namespace Repository
{
    public static class FoodExtensions
    {
        public static FoodModel ToFoodModel(this Food dbFood)
        {
            return new FoodModel()
            {
                FoodId = new FoodId() { Value = dbFood.FoodId },
                AmountInOunces = dbFood.AmountInOunces,
                FrequencyPerDay = dbFood.FrequencyPerDay,
                Created = dbFood.Created,
                Modified = dbFood.Modified,
                Deleted = dbFood.Deleted
            };
        }
    }
}