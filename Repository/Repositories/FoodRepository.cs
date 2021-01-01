using Models.Shared;
using NHibernate;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class FoodRepository
    {
        public List<FoodModel> GetAllFoodForDog(DogId dogId)
        {
            List<FoodModel> foodModels;
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var food = session.Query<Food>().Where(c => !c.Deleted.HasValue && c.Dog.DogId == dogId.Value);
                foodModels = food.Select(x => x.ToFoodModel()).ToList(); //  Querying to get all the users
            }
            return foodModels;
        }

        public FoodModel GetFoodById(FoodId foodId)
        {
            FoodModel foodModel = new FoodModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var food = session.Query<Food>().FirstOrDefault(c => c.FoodId == foodId.Value);
                if (food != null)
                {
                    foodModel = food.ToFoodModel();
                }
            }
            return foodModel;
        }

        public bool CreateFood(FoodModel foodModel)
        {
            Food newFood = new Food
            {
                Created = foodModel.Created,
                Modified = foodModel.Modified,
                AmountInOunces = foodModel.AmountInOunces,
                FrequencyPerDay = foodModel.FrequencyPerDay
            };
            using (ISession session = NHibernateSession.OpenSession())
            {
                Dog foundDog = session.Query<Dog>().FirstOrDefault(u => u.DogId == foodModel.Dog.DogId.Value);
                if (foundDog == null) return false;
                newFood.Dog = foundDog;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Save(newFood); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool UpdateFood(FoodModel foodModel)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Food foundFood = session.Query<Food>().FirstOrDefault(c => c.FoodId == foodModel.FoodId.Value);
                if (foundFood == null) return false;
                foundFood.Modified = DateTime.UtcNow;
                foundFood.AmountInOunces = foodModel.AmountInOunces;
                foundFood.FrequencyPerDay = foodModel.FrequencyPerDay;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundFood); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }
    }
}