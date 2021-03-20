using Models.Shared;
using Repository.Models;

namespace Repository
{
    public static class InsuranceExtensions
    {
        public static InsuranceModel ToInsuranceModel(this Insurance dbInsurance)
        {
            return new InsuranceModel()
            {
                InsuranceId = new InsuranceId() { Value = dbInsurance.InsuranceId },
                AnnualCoverageLimit = dbInsurance.AnnualCoverageLimit,
                UnlimitedAnnualCoverageLimit = dbInsurance.UnlimitedAnnualCoverageLimit,
                DeductibleAmount = dbInsurance.DeductibleAmount,
                EndDateTime = dbInsurance.EndDateTime,
                PaymentAmount = dbInsurance.PaymentAmount,
                PaymentFrequencyDays = dbInsurance.PaymentFrequency?.Days ?? 0,
                Company = dbInsurance.Company,
                PolicyId = new InsurancePolicyId() { Value = dbInsurance.PolicyId },
                ReimbursementPercentage = dbInsurance.ReimbursementPercentage,
                RenewalDateTime = dbInsurance.RenewalDateTime,
                StartDateTime = dbInsurance.StartDateTime,
                Website = dbInsurance.Website,
                Created = dbInsurance.Created,
                Modified = dbInsurance.Modified,
                Deleted = dbInsurance.Deleted
            };
        }
    }
}