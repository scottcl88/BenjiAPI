using DataExtensions;
using Models;
using Models.Shared;
using NHibernate;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class VaccineRepository : IRepository
    {
        public List<VaccineModel> GetAllVaccineForDog(DogId dogId)
        {
            List<VaccineModel> models = new List<VaccineModel>();
            try
            {
                using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
                {
                    var model = session.Query<Vaccine>().Where(c => !c.Deleted.HasValue && c.Dog.DogId == dogId.Value);
                    models = model.Select(x => x.ToVaccineModel()).ToList(); //  Querying to get all the users
                }
            }
            catch (Exception ex)
            {
            }
            return models;
        }

        public VaccineModel GetVaccineById(VaccineId vaccineId)
        {
            VaccineModel model = new VaccineModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var dbItem = session.Query<Vaccine>().FirstOrDefault(c => c.VaccineId == vaccineId.Value);
                if (dbItem != null)
                {
                    model = dbItem.ToVaccineModel();
                }
            }
            return model;
        }

        public bool CreateVaccine(VaccineModel model)
        {
            Vaccine newvaccine = new Vaccine
            {
                Comments = model.Comments,
                Title = model.Title,
                Expiration = model.Expiration,
                Received = model.Received,
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
                newvaccine.Dog = foundDog;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Save(newvaccine); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool UpdateVaccine(VaccineModel model)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Vaccine foundvaccine = session.Query<Vaccine>().FirstOrDefault(c => c.VaccineId == model.VaccineId.Value);
                if (foundvaccine == null) return false;
                foundvaccine.Modified = DateTime.UtcNow;
                foundvaccine.Comments = model.Comments;
                foundvaccine.Title = model.Title;
                foundvaccine.Expiration = model.Expiration;
                foundvaccine.Received = model.Received;
                foundvaccine.Doctor = model.Doctor;
                foundvaccine.Company = model.Company;
                foundvaccine.Address = model.Address;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundvaccine); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool DeleteVaccine(VaccineDeleteRequest request)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Vaccine foundvaccine = session.Query<Vaccine>().FirstOrDefault(c => c.VaccineId == request.VaccineId.Value);
                if (foundvaccine == null) return false;
                foundvaccine.Deleted = DateTime.UtcNow;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundvaccine); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }
    }
}