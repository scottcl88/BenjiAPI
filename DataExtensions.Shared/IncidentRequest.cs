using Models.Shared;

namespace DataExtensions
{
    public class IncidentCreateRequest
    {
        public IncidentCreateRequest()
        {
            Incident = new IncidentModel();
        }

        public IncidentModel Incident { get; set; }
    }

    public class IncidentUpdateRequest
    {
        public IncidentUpdateRequest()
        {
            Incident = new IncidentModel();
        }

        public IncidentModel Incident { get; set; }
    }

    public class IncidentDeleteRequest
    {
        public IncidentId IncidentId { get; set; }
    }
}