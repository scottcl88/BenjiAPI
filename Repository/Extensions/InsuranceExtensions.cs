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
                Created = dbInsurance.Created,
                Modified = dbInsurance.Modified,
                Deleted = dbInsurance.Deleted
            };
        }
    }
}