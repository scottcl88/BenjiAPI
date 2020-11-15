using Models;
using Models.Shared;
using NHibernate;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class BoardingRepository : IRepository
    {
        public List<BoardingModel> GetAllBoardingForDog(DogId dogId)
        {
            List<BoardingModel> foodModels = new List<BoardingModel>();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var food = session.Query<Boarding>().Where(c => !c.Deleted.HasValue && c.Dog.DogId == dogId.Value);
                foodModels = food.Select(x => x.ToBoardingModel()).ToList(); //  Querying to get all the users
            }
            return foodModels;
        }

        public BoardingModel GetBoardingById(BoardingId foodId)
        {
            BoardingModel foodModel = new BoardingModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var food = session.Query<Boarding>().FirstOrDefault(c => c.BoardingId == foodId.Value);
                if (food != null)
                {
                    foodModel = food.ToBoardingModel();
                }
            }
            return foodModel;
        }

        public bool CreateBoarding(BoardingModel foodModel)
        {
            Boarding newBoarding = new Boarding
            {
                Created = foodModel.Created,
                Modified = foodModel.Modified
            };
            using (ISession session = NHibernateSession.OpenSession())
            {
                Dog foundDog = session.Query<Dog>().FirstOrDefault(u => u.DogId == foodModel.Dog.DogId.Value);
                if (foundDog == null) return false;
                newBoarding.Dog = foundDog;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Save(newBoarding); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool UpdateBoarding(BoardingModel foodModel)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Boarding foundBoarding = session.Query<Boarding>().FirstOrDefault(c => c.BoardingId == foodModel.BoardingId.Value);
                if (foundBoarding == null) return false;
                foundBoarding.Modified = DateTime.UtcNow;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundBoarding); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }
    }
}