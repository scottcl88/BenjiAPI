using DataExtensions;
using Models.Shared;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class VetVisitManager
    {
        private readonly VetVisitRepository _VetVisitsRepository;

        public VetVisitManager()
        {
            _VetVisitsRepository = new VetVisitRepository();
        }

        public List<VetVisitModel> GetAllVetVisit(DogModel dogModel)
        {
            return _VetVisitsRepository.GetAllVetVisitForDog(dogModel.DogId).ToList();
        }

        public VetVisitModel GetVetVisitById(VetVisitId VetVisitsId)
        {
            return _VetVisitsRepository.GetVetVisitById(VetVisitsId);
        }

        public bool CreateNewVetVisit(VetVisitCreateRequest request)
        {
            return _VetVisitsRepository.CreateVetVisit(request.VetVisit);
        }

        public bool UpdateVetVisit(VetVisitUpdateRequest request)
        {
            return _VetVisitsRepository.UpdateVetVisit(request.VetVisit);
        }

        public bool DeleteVetVisit(VetVisitDeleteRequest request)
        {
            return _VetVisitsRepository.DeleteVetVisit(request);
        }
    }
}