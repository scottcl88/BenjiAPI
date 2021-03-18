using DataExtensions;
using Models.Shared;
using NHibernate;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class TreatmentRepository
    {
        public List<TreatmentModel> GetAllTreatmentForDog(DogId dogId)
        {
            List<TreatmentModel> models;
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var model = session.Query<Treatment>().Where(c => !c.Deleted.HasValue && c.Dog.DogId == dogId.Value);
                models = model.Select(x => x.ToTreatmentModel()).ToList(); //  Querying to get all the users
            }
            return models;
        }

        public TreatmentModel GetTreatmentById(TreatmentId TreatmentId)
        {
            TreatmentModel model = new TreatmentModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var dbItem = session.Query<Treatment>().FirstOrDefault(c => c.TreatmentId == TreatmentId.Value);
                if (dbItem != null)
                {
                    model = dbItem.ToTreatmentModel();
                }
            }
            return model;
        }

        public bool CreateTreatment(TreatmentModel model)
        {
            Treatment newTreatment = new Treatment
            {
                Comments = model.Comments,
                Title = model.Title,
                ReceivedDateTime = model.ReceivedDateTime,
                Doctor = model.Doctor,
                Amount = model.Amount,
                ExpirationDateTime = model.ExpirationDateTime,
                Created = model.Created,
                Modified = model.Modified,
                Deleted = model.Deleted
            };
            using (ISession session = NHibernateSession.OpenSession())
            {
                Dog foundDog = session.Query<Dog>().FirstOrDefault(u => u.DogId == model.Dog.DogId.Value);
                if (foundDog == null) return false;
                newTreatment.Dog = foundDog;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Save(newTreatment); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool UpdateTreatment(TreatmentModel model)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Treatment foundTreatment = session.Query<Treatment>().FirstOrDefault(c => c.TreatmentId == model.TreatmentId.Value);
                if (foundTreatment == null) return false;
                foundTreatment.Modified = DateTime.UtcNow;
                foundTreatment.Comments = model.Comments;
                foundTreatment.Title = model.Title;
                foundTreatment.ReceivedDateTime = model.ReceivedDateTime;
                foundTreatment.Doctor = model.Doctor;
                foundTreatment.Amount = model.Amount;
                foundTreatment.ExpirationDateTime = model.ExpirationDateTime;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundTreatment); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool DeleteTreatment(TreatmentDeleteRequest request)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Treatment foundTreatment = session.Query<Treatment>().FirstOrDefault(c => c.TreatmentId == request.TreatmentId.Value);
                if (foundTreatment == null) return false;
                foundTreatment.Deleted = DateTime.UtcNow;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundTreatment); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }
    }
}