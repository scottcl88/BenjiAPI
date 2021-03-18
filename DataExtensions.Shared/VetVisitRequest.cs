using Models.Shared;

namespace DataExtensions
{
    public class VetVisitCreateRequest
    {
        public VetVisitCreateRequest()
        {
            VetVisit = new VetVisitModel();
        }

        public VetVisitModel VetVisit { get; set; }
    }

    public class VetVisitUpdateRequest
    {
        public VetVisitUpdateRequest()
        {
            VetVisit = new VetVisitModel();
        }

        public VetVisitModel VetVisit { get; set; }
    }

    public class VetVisitDeleteRequest
    {
        public VetVisitId VetVisitId { get; set; }
    }
}