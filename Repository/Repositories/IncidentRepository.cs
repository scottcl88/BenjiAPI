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
    public class IncidentRepository : IRepository
    {
        public List<IncidentModel> GetAllIncidentForDog(DogId dogId)
        {
            List<IncidentModel> incidentModels = new List<IncidentModel>();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var incident = session.Query<Incident>().Where(c => !c.Deleted.HasValue && c.Dog.DogId == dogId.Value);
                incidentModels = incident.Select(x => x.ToIncidentModel()).ToList(); //  Querying to get all the users
            }
            return incidentModels;
        }

        public IncidentModel GetIncidentById(IncidentId incidentId)
        {
            IncidentModel incidentModel = new IncidentModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var incident = session.Query<Incident>().FirstOrDefault(c => c.IncidentId == incidentId.Value);
                if (incident != null)
                {
                    incidentModel = incident.ToIncidentModel();
                }
            }
            return incidentModel;
        }

        public bool CreateIncident(IncidentModel incidentModel)
        {
            Incident newIncident = new Incident
            {
                Created = incidentModel.Created,
                Modified = incidentModel.Modified,
                Description = incidentModel.Description,
                IncidentDate = incidentModel.IncidentDate,
                IncidentType = (Models.IncidentType)incidentModel.IncidentType,
                Title = incidentModel.Title
            };
            using (ISession session = NHibernateSession.OpenSession())
            {
                Dog foundDog = session.Query<Dog>().FirstOrDefault(u => u.DogId == incidentModel.Dog.DogId.Value);
                if (foundDog == null) return false;
                newIncident.Dog = foundDog;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Save(newIncident); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool UpdateIncident(IncidentModel incidentModel)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Incident foundIncident = session.Query<Incident>().FirstOrDefault(c => c.IncidentId == incidentModel.IncidentId.Value);
                if (foundIncident == null) return false;
                foundIncident.Modified = DateTime.UtcNow;
                foundIncident.Description = incidentModel.Description;
                foundIncident.IncidentDate = incidentModel.IncidentDate;
                foundIncident.IncidentType = (Models.IncidentType)incidentModel.IncidentType;
                foundIncident.Title = incidentModel.Title;
                using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                {
                    session.Update(foundIncident); //  Save the user in session
                    transaction.Commit();   //  Commit the changes to the database
                }
            }
            return true;
        }

        public bool DeleteIncident(IncidentDeleteRequest request)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Incident foundvaccine = session.Query<Incident>().FirstOrDefault(c => c.IncidentId == request.IncidentId.Value);
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