using Models.Shared;

namespace DataExtensions
{
    public class TreatmentCreateRequest
    {
        public TreatmentCreateRequest()
        {
            Treatment = new TreatmentModel();
        }

        public TreatmentModel Treatment { get; set; }
    }

    public class TreatmentUpdateRequest
    {
        public TreatmentUpdateRequest()
        {
            Treatment = new TreatmentModel();
        }

        public TreatmentModel Treatment { get; set; }
    }

    public class TreatmentDeleteRequest
    {
        public TreatmentId TreatmentId { get; set; }
    }
}