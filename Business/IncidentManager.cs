using DataExtensions;
using Models;
using Models.Shared;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class IncidentManager
    {
        private readonly IncidentRepository _incidentRepository;

        public IncidentManager()
        {
            _incidentRepository = new IncidentRepository();
        }

        public List<IncidentModel> GetAllIncident(DogModel dogModel)
        {
            return _incidentRepository.GetAllIncidentForDog(dogModel.DogId).ToList();
        }

        public IncidentModel GetIncidentById(IncidentId incidentId)
        {
            return _incidentRepository.GetIncidentById(incidentId);
        }

        public bool CreateNewIncident(IncidentCreateRequest request)
        {
            return _incidentRepository.CreateIncident(request.Incident);
        }

        public bool UpdateIncident(IncidentUpdateRequest request)
        {
            return _incidentRepository.UpdateIncident(request.Incident);
        }

        public bool DeleteIncident(IncidentDeleteRequest request)
        {
            return _incidentRepository.DeleteIncident(request);
        }
    }
}