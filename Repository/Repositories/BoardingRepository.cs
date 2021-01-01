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
    public class BoardingRepository : IRepository
    {
        public List<BoardingModel> GetAllBoardingForDog(DogId dogId)
        {
            List<BoardingModel> models = new List<BoardingModel>();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var model = session.Query<Boarding>().Where(c => !c.Deleted.HasValue && c.Dog.DogId == dogId.Value);
                models = model.Select(x => x.ToBoardingModel()).ToList(); //  Querying to get all the users
            }
            return models;
        }

        public BoardingModel GetBoardingById(BoardingId boardingId)
        {
            BoardingModel model = new BoardingModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var dbItem = session.Query<Boarding>().FirstOrDefault(c => c.BoardingId == boardingId.Value);
                if (dbItem != null)
                {
                    model = dbItem.ToBoardingModel();
                }
            }
            return model;
        }

        public bool CreateBoarding(BoardingModel model)
        {
            Boarding newBoarding = new Boarding
            {
                Comments = model.Comments,
                Company = model.Company,
                Address = model.Address,
                Reason = model.Reason,
                PaymentAmount = model.PaymentAmount,
                Website = model.Website,
                StartDateTime = model.StartDateTime,
                EndDateTime = model.EndDateTime,
                Created = model.Created,
                Modified = model.Modified,
                Deleted = model.Deleted
            };
            using (ISession session = NHibernateSession.OpenSession())
            {
                Dog foundDog = session.Query<Dog>().FirstOrDefault(u => u.DogId == model.Dog.DogId.Value);
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

        public bool UpdateBoarding(BoardingModel model)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Boarding foundBoarding = session.Query<Boarding>().FirstOrDefault(c => c.BoardingId == model.BoardingId.Value);
                if (foundBoarding == null) return false;
                foundBoarding.Modified = DateTime.UtcNow;
                foundBoarding.Comments = model.Comments;
                foundBoarding.Company = model.Company;
                foundBoarding.Address = model.Address;
                foundBoarding.Reason = model.Reason;
                foundBoarding.PaymentAmount = model.PaymentAmount;
                foundBoarding.Website = model.Website;
                foundBoarding.StartDateTime = model.StartDateTime;
                foundBoarding.EndDateTime = model.EndDateTime;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundBoarding); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool DeleteBoarding(BoardingDeleteRequest request)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Boarding foundBoarding = session.Query<Boarding>().FirstOrDefault(c => c.BoardingId == request.BoardingId.Value);
                if (foundBoarding == null) return false;
                foundBoarding.Deleted = DateTime.UtcNow;
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