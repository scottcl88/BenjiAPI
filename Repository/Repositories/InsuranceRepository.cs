using DataExtensions;
using Models.Shared;
using NHibernate;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository
{
    public class InsuranceRepository
    {
        public List<InsuranceModel> GetAllInsuranceForDog(DogId dogId)
        {
            List<InsuranceModel> models;
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var model = session.Query<Insurance>().Where(c => !c.Deleted.HasValue && c.Dog.DogId == dogId.Value);
                models = model.Select(x => x.ToInsuranceModel()).ToList(); //  Querying to get all the users
            }
            return models;
        }

        public InsuranceModel GetDefaultInsurance()
        {
            InsuranceModel insuranceModel = new InsuranceModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var insurance = session.Query<Insurance>().FirstOrDefault(c => !c.Deleted.HasValue);
                if (insurance != null)
                {
                    insuranceModel = insurance.ToInsuranceModel();
                }
            }
            return insuranceModel;
        }
        public InsuranceModel GetInsuranceById(InsuranceId InsuranceId)
        {
            InsuranceModel model = new InsuranceModel();
            using (ISession session = NHibernateSession.OpenSession())  // Open a session to conect to the database
            {
                var dbItem = session.Query<Insurance>().FirstOrDefault(c => c.InsuranceId == InsuranceId.Value);
                if (dbItem != null)
                {
                    model = dbItem.ToInsuranceModel();
                }
            }
            return model;
        }

        public bool CreateInsurance(InsuranceModel model)
        {
            Insurance newInsurance = new Insurance
            {
                AnnualCoverageLimit = model.AnnualCoverageLimit,
                UnlimitedAnnualCoverageLimit = model.UnlimitedAnnualCoverageLimit,
                DeductibleAmount = model.DeductibleAmount,
                EndDateTime = model.EndDateTime,
                PaymentAmount = model.PaymentAmount,
                Company = model.Company,
                PolicyId = model.PolicyId?.Value,
                ReimbursementPercentage = model.ReimbursementPercentage,
                RenewalDateTime = model.RenewalDateTime,
                StartDateTime = model.StartDateTime,
                Website = model.Website,
                Created = model.Created,
                Modified = model.Modified,
                Deleted = model.Deleted
            };
            newInsurance.PaymentFrequency = !model.PaymentFrequencyDays.HasValue ? null : new TimeSpan(model.PaymentFrequencyDays.Value, 0, 0, 0);
            using (ISession session = NHibernateSession.OpenSession())
            {
                Dog foundDog = session.Query<Dog>().FirstOrDefault(u => u.DogId == model.Dog.DogId.Value);
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

        public bool UpdateInsurance(InsuranceModel model)
        {
            try
            {
                using (ISession session = NHibernateSession.OpenSession())
                {
                    Insurance foundInsurance = session.Query<Insurance>().FirstOrDefault(c => c.InsuranceId == model.InsuranceId.Value);
                    if (foundInsurance == null) return false;
                    foundInsurance.Modified = DateTime.UtcNow;

                    foundInsurance.UnlimitedAnnualCoverageLimit = model.UnlimitedAnnualCoverageLimit;
                    foundInsurance.AnnualCoverageLimit = model.AnnualCoverageLimit;
                    foundInsurance.DeductibleAmount = model.DeductibleAmount;
                    foundInsurance.EndDateTime = model.EndDateTime;
                    foundInsurance.PaymentAmount = model.PaymentAmount;
                    foundInsurance.PaymentFrequency = !model.PaymentFrequencyDays.HasValue ? null : new TimeSpan(model.PaymentFrequencyDays.Value, 0, 0, 0);
                    foundInsurance.Company = model.Company;
                    foundInsurance.PolicyId = model.PolicyId?.Value;
                    foundInsurance.ReimbursementPercentage = model.ReimbursementPercentage;
                    foundInsurance.RenewalDateTime = model.RenewalDateTime;
                    foundInsurance.StartDateTime = model.StartDateTime;
                    foundInsurance.Website = model.Website;
                    using (ITransaction transaction = session.BeginTransaction())   //  Begin a transaction
                    {
                        session.Update(foundInsurance); //  Save the user in session
                        transaction.Commit();   //  Commit the changes to the database
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return true;
        }

        public bool DeleteInsurance(InsuranceDeleteRequest request)
        {
            using (ISession session = NHibernateSession.OpenSession())
            {
                Insurance foundInsurance = session.Query<Insurance>().FirstOrDefault(c => c.InsuranceId == request.InsuranceId.Value);
                if (foundInsurance == null) return false;
                foundInsurance.Deleted = DateTime.UtcNow;
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