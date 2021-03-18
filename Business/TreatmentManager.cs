using DataExtensions;
using Models.Shared;
using Repository;
using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public class TreatmentManager
    {
        private readonly TreatmentRepository _treatmentsRepository;

        public TreatmentManager()
        {
            _treatmentsRepository = new TreatmentRepository();
        }

        public List<TreatmentModel> GetAllTreatment(DogModel dogModel)
        {
            return _treatmentsRepository.GetAllTreatmentForDog(dogModel.DogId).ToList();
        }

        public TreatmentModel GetTreatmentById(TreatmentId TreatmentsId)
        {
            return _treatmentsRepository.GetTreatmentById(TreatmentsId);
        }

        public bool CreateNewTreatment(TreatmentCreateRequest request)
        {
            return _treatmentsRepository.CreateTreatment(request.Treatment);
        }

        public bool UpdateTreatment(TreatmentUpdateRequest request)
        {
            return _treatmentsRepository.UpdateTreatment(request.Treatment);
        }

        public bool DeleteTreatment(TreatmentDeleteRequest request)
        {
            return _treatmentsRepository.DeleteTreatment(request);
        }
    }
}