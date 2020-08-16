using Models;
using NHibernate;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class HealthRepository : IRepository
    {
        public List<HealthModel> GetAllHealthForDog(DogId dogId)
        {
            List<HealthModel> healthModels = new List<HealthModel>();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var health = session.Query<Health>().Where(c => !c.Deleted.HasValue && c.Dog.DogId == dogId.Value);
                healthModels = health.Select(x => x.ToHealthModel()).ToList(); //  Querying to get all the users
            }
            return healthModels;
        }

        public HealthModel GetHealthById(HealthId healthId)
        {
            HealthModel healthModel = new HealthModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var health = session.Query<Health>().FirstOrDefault(c => c.HealthId == healthId.Value);
                if (health != null)
                {
                    healthModel = health.ToHealthModel();
                }
            }
            return healthModel;
        }

        public bool CreateHealth(HealthModel healthModel)
        {
            Health newHealth = new Health
            {
                Created = healthModel.Created,
                Modified = healthModel.Modified,
                FromVet = healthModel.FromVet,
                Height = healthModel.Height,
                Length = healthModel.Length,
                MouthCircumference = healthModel.MouthCircumference,
                NoseEyeLength = healthModel.NoseEyeLength,
                TailLength = healthModel.TailLength,
                Waist = healthModel.Waist,
                Weight = healthModel.Weight
            };
            using (ISession session = NHibernateSession.OpenSession())
            {
                Dog foundDog = session.Query<Dog>().FirstOrDefault(u => u.DogId == healthModel.Dog.DogId.Value);
                if (foundDog == null) return false;
                newHealth.Dog = foundDog;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Save(newHealth); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool UpdateHealth(HealthModel healthModel)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Health foundHealth = session.Query<Health>().FirstOrDefault(c => c.HealthId == healthModel.HealthId.Value);
                if (foundHealth == null) return false;
                foundHealth.Modified = DateTime.UtcNow;
                foundHealth.FromVet = healthModel.FromVet;
                foundHealth.Height = healthModel.Height;
                foundHealth.Length = healthModel.Length;
                foundHealth.MouthCircumference = healthModel.MouthCircumference;
                foundHealth.NoseEyeLength = healthModel.NoseEyeLength;
                foundHealth.TailLength = healthModel.TailLength;
                foundHealth.Waist = healthModel.Waist;
                foundHealth.Weight = healthModel.Weight;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundHealth); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }
    }
}