using Models.Shared;
using NHibernate;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Gender = Repository.Models.Gender;

namespace Repository
{
    public class DogRepository
    {
        public List<DogModel> GetAllDogs()
        {
            List<DogModel> dogModels;
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var dogs = session.Query<Dog>().Where(c => !c.Deleted.HasValue);
                dogModels = dogs.Select(x => x.ToDogModel()).ToList();
            }
            return dogModels;
        }

        public DogModel GetDogById(DogId dogId)
        {
            DogModel dogModel = new DogModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var dog = session.Query<Dog>().FirstOrDefault(c => c.DogId == dogId.Value);
                if (dog != null)
                {
                    dogModel = dog.ToDogModel();
                }
            }
            return dogModel;
        }

        public DogModel GetDefaultDog()
        {
            DogModel dogModel = new DogModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var dog = session.Query<Dog>().FirstOrDefault(c => !c.Deleted.HasValue);
                if (dog != null)
                {
                    dogModel = dog.ToDogModel();
                }
            }
            return dogModel;
        }

        public bool CreateDog(DogModel dogModel)
        {
            Dog newDog = new Dog
            {
                Name = dogModel.Name,
                AdoptedDate = dogModel.AdoptedDate,
                Birthdate = dogModel.Birthdate,
                Gender = (Gender)dogModel.Gender,
                Created = DateTime.UtcNow,
                Modified = DateTime.UtcNow
            };
            using (ISession session = NHibernateSession.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Save(newDog); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool UpdateDog(DogModel dogModel)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Dog foundDog = session.Query<Dog>().FirstOrDefault(c => c.DogId == dogModel.DogId.Value);
                if (foundDog == null) return false;
                foundDog.Name = dogModel.Name;
                foundDog.AdoptedDate = dogModel.AdoptedDate;
                foundDog.Birthdate = dogModel.Birthdate;
                foundDog.Gender = (Models.Gender)dogModel.Gender;
                foundDog.Modified = DateTime.UtcNow;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundDog); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }
    }
}