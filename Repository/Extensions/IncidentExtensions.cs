using Models;
using Models.Shared;
using Repository.Models;
using System.Linq;

namespace Repository
{
    public static class IncidentExtensions
    {
        public static IncidentModel ToIncidentModel(this Incident dbIncident)
        {
            return new IncidentModel()
            {
                IncidentId = new IncidentId() { Value = dbIncident.IncidentId },
                Title = dbIncident.Title,
                Description = dbIncident.Description,
                IncidentType = (global::Models.Shared.IncidentType)dbIncident.IncidentType,
                IncidentDate = dbIncident.IncidentDate,
                Created = dbIncident.Created,
                Modified = dbIncident.Modified,
                Deleted = dbIncident.Deleted
            };
        }
    }
}
