using DataExtensions;
using Models.Shared;
using NHibernate;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class VetVisitRepository
    {
        public List<VetVisitModel> GetAllVetVisitForDog(DogId dogId)
        {
            List<VetVisitModel> models;
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var model = session.Query<VetVisit>().Where(c => !c.Deleted.HasValue && c.Dog.DogId == dogId.Value);
                models = model.Select(x => x.ToVetVisitModel()).ToList(); //  Querying to get all the users
            }
            return models;
        }

        public VetVisitModel GetVetVisitById(VetVisitId VetVisitId)
        {
            VetVisitModel model = new VetVisitModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var dbItem = session.Query<VetVisit>().FirstOrDefault(c => c.VetVisitId == VetVisitId.Value);
                if (dbItem != null)
                {
                    model = dbItem.ToVetVisitModel();
                }
            }
            return model;
        }

        public bool CreateVetVisit(VetVisitModel model)
        {
            VetVisit newVetVisit = new VetVisit
            {
                Comments = model.Comments,
                Title = model.Title,
                VisitDateTime = model.VisitDateTime,
                Doctor = model.Doctor,
                Company = model.Company,
                Address = model.Address,
                Created = model.Created,
                Modified = model.Modified,
                Deleted = model.Deleted
            };
            using (ISession session = NHibernateSession.OpenSession())
            {
                Dog foundDog = session.Query<Dog>().FirstOrDefault(u => u.DogId == model.Dog.DogId.Value);
                if (foundDog == null) return false;
                newVetVisit.Dog = foundDog;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Save(newVetVisit); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool UpdateVetVisit(VetVisitModel model)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                VetVisit foundVetVisit = session.Query<VetVisit>().FirstOrDefault(c => c.VetVisitId == model.VetVisitId.Value);
                if (foundVetVisit == null) return false;
                foundVetVisit.Modified = DateTime.UtcNow;
                foundVetVisit.Comments = model.Comments;
                foundVetVisit.Title = model.Title;
                foundVetVisit.VisitDateTime = model.VisitDateTime;
                foundVetVisit.Doctor = model.Doctor;
                foundVetVisit.Company = model.Company;
                foundVetVisit.Address = model.Address;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundVetVisit); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool DeleteVetVisit(VetVisitDeleteRequest request)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                VetVisit foundVetVisit = session.Query<VetVisit>().FirstOrDefault(c => c.VetVisitId == request.VetVisitId.Value);
                if (foundVetVisit == null) return false;
                foundVetVisit.Deleted = DateTime.UtcNow;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundVetVisit); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }
    }
}