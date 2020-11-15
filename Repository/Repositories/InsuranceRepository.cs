using Models;
using Models.Shared;
using NHibernate;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class InsuranceRepository : IRepository
    {
        public List<InsuranceModel> GetAllInsuranceForDog(DogId dogId)
        {
            List<InsuranceModel> foodModels = new List<InsuranceModel>();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var food = session.Query<Insurance>().Where(c => !c.Deleted.HasValue && c.Dog.DogId == dogId.Value);
                foodModels = food.Select(x => x.ToInsuranceModel()).ToList(); //  Querying to get all the users
            }
            return foodModels;
        }

        public InsuranceModel GetInsuranceById(InsuranceId foodId)
        {
            InsuranceModel foodModel = new InsuranceModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var food = session.Query<Insurance>().FirstOrDefault(c => c.InsuranceId == foodId.Value);
                if (food != null)
                {
                    foodModel = food.ToInsuranceModel();
                }
            }
            return foodModel;
        }

        public bool CreateInsurance(InsuranceModel foodModel)
        {
            Insurance newInsurance = new Insurance
            {
                Created = foodModel.Created,
                Modified = foodModel.Modified
            };
            using (ISession session = NHibernateSession.OpenSession())
            {
                Dog foundDog = session.Query<Dog>().FirstOrDefault(u => u.DogId == foodModel.Dog.DogId.Value);
                if (foundDog == null) return false;
                newInsurance.Dog = foundDog;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Save(newInsurance); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool UpdateInsurance(InsuranceModel foodModel)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Insurance foundInsurance = session.Query<Insurance>().FirstOrDefault(c => c.InsuranceId == foodModel.InsuranceId.Value);
                if (foundInsurance == null) return false;
                foundInsurance.Modified = DateTime.UtcNow;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundInsurance); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }
    }
}