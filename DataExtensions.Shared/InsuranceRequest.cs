using Models.Shared;

namespace DataExtensions
{
    public class InsuranceCreateRequest
    {
        public InsuranceCreateRequest()
        {
            Insurance = new InsuranceModel();
        }

        public InsuranceModel Insurance { get; set; }
    }

    public class InsuranceUpdateRequest
    {
        public InsuranceUpdateRequest()
        {
            Insurance = new InsuranceModel();
        }

        public InsuranceModel Insurance { get; set; }
    }
    public class InsuranceDeleteRequest
    {
        public InsuranceId InsuranceId { get; set; }
    }
}